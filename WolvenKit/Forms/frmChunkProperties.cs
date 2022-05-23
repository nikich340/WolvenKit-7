using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Dfust.Hotkeys;
using WeifenLuo.WinFormsUI.Docking;
using WolvenKit.App;
using WolvenKit.App.Commands;
using WolvenKit.App.Model;
using WolvenKit.App.ViewModels;
using WolvenKit.Common.Services;
using WolvenKit.CR2W;
using WolvenKit.CR2W.Reflection;
using WolvenKit.CR2W.Types;
using WolvenKit.Extensions;
using WolvenKit.Forms.Editors;
using WolvenKit.Services;
using WolvenKit.Utility;

namespace WolvenKit.Forms
{
    public partial class frmChunkProperties : DockContent, IThemedContent
    {
        private bool showOnlySerialized = false;
        //private HotkeyCollection hotkeys;
        private readonly CR2WDocumentViewModel viewModel;

        public frmChunkProperties(CR2WDocumentViewModel _viewmodel)
        {
            InitializeComponent();
            ApplyCustomTheme();

            treeView.CanExpandGetter = x =>
            {
                var root = showOnlySerialized
                    ? ((IEditableVariable)x).GetEditableVariables().Where(_ => _.IsSerialized)
                    : ((IEditableVariable)x).GetEditableVariables();
                return root?.Any() ?? false;
            };
            treeView.ChildrenGetter = x =>
            {
                var root = showOnlySerialized
                    ? ((IEditableVariable)x).GetEditableVariables().Where(_ => _.IsSerialized)
                    : ((IEditableVariable)x).GetEditableVariables();
                return root;
            };

            toolStripButtonShowSerialized.Text = showOnlySerialized
                ? "Show all variables"
                : "Show edited variables";

            //hotkeys = new HotkeyCollection(Dfust.Hotkeys.Enums.Scope.Application);

            //RegisterHotkeys();

            viewModel = _viewmodel;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        #region Properties
        
        public event EventHandler<RequestByteArrayFileOpenArgs> RequestBytesOpen;

        private CR2WExportWrapper Chunk => 
            (viewModel.SelectedChunks != null && viewModel.SelectedChunks.Count > 0) ? viewModel.SelectedChunks.First() : null;

        private List<IEditableVariable> GetSelectedObjects()
        {
            return (from IEditableVariable item in treeView.SelectedObjects where item != null select item).ToList();
        }
        #endregion


        #region UI Methods
        private void CopyVariable(HotKeyEventArgs e)
        {
            if (GetSelectedObjects().Count > 0)
                CopyController.Source = GetSelectedObjects();
        }

        private void PasteVariable(HotKeyEventArgs e)
        {
            if (GetSelectedObjects().Count > 0)
                CopyController.Target = GetSelectedObjects().First();
            viewModel.PasteVariableCommand.SafeExecute();
        }

        private void UpdateTreeListView()
        {
            if (Chunk == null)
            {
                treeView.Roots = null;
                return;
            }

            var root = showOnlySerialized 
                ? Chunk.GetEditableVariables().Where(_ => _.IsSerialized) 
                : Chunk.GetEditableVariables();

            treeView.Roots = root;

            // filter
            this.treeView.ModelFilter = !string.IsNullOrEmpty(toolStripSearchBox.Text.ToUpper()) 
                ? TextMatchFilter.Contains(treeView, toolStripSearchBox.Text.ToUpper()) 
                : null;

            foreach (var treeViewObject in treeView.Objects)
            {
                treeView.Expand(treeViewObject);
                treeView.RefreshObject(treeViewObject);
            }

        }

        private void treeView_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (!(e.RowObject is IEditableVariable editableVariable)) return;
            switch (e.Column.AspectName)
            {
                //var variable = (e.RowObject as VariableListNode).Variable;
                case "REDValue":
                {
                    // if variant is null, ask the user to create a new wrapped cvar
                    if (editableVariable is IVariantAccessor ivariant && ivariant.Variant == null)
                    {
                        var availableTypes = CR2WManager.GetAvailableTypes(nameof(IReferencable)).Select(_ => _.Name);
                        var variantType = new Utility.ProductionWindowFactory().ShowAddChunkFormModal(availableTypes);

                        var variant = CR2WTypeManager.Create(variantType, "Variant", editableVariable.cr2w,
                            (CVariable)editableVariable);
                        variant.IsSerialized = true;
                        ivariant.Variant = variant;
                        editableVariable.IsSerialized = true;
                    }

                    e.Control = EditorHandler.GetEditor(editableVariable);
                    if (e.Control != null)
                    {

                        e.Control.Location = new Point(e.CellBounds.Location.X, e.CellBounds.Location.Y - 1);
                        e.Control.Width = e.CellBounds.Width;

                        // update references for pointer type variables
                        if (editableVariable is IChunkPtrAccessor iptr && e.Control is ComboBox editor)
                        {
                            editor.SelectedIndexChanged += delegate(object o, EventArgs _e)
                            {
                                var ptrcomboitem = (PtrComboItem) ((ComboBox) o).SelectedItem;
                                if (ptrcomboitem != null)
                                {
                                    if (ptrcomboitem.Text == $"<Add new chunk ...>")
                                    {
                                        // raise event
                                        viewModel.AddNewChunkFor(iptr);

                                        // select item
                                        editor.UpdateComboBoxWith(iptr);
                                    }
                                    else
                                    {
                                        iptr.Reference = ptrcomboitem.Value;
                                    }
                                }
                            };
                        }

                        if (e.Control is ByteArrayEditor byteArrayEditor)
                            byteArrayEditor.RequestBytesOpen += ByteArrayEditor_RequestBytesOpen;
                        if (e.Control is ArrayEditor arrayEditor)
                        {
                            arrayEditor.parentref = this;
                            arrayEditor.RequestBytesOpen += ByteArrayEditor_RequestBytesOpen;
                        }
                    }

                    e.Cancel = e.Control == null;
                    break;
                }
                case "REDName":
                    //Normal textbox is good for this.
                    break;
                default:
                    e.Cancel = true;
                    break;
            }
        }

        

        private void treeView_CellEditFinished(object sender, CellEditEventArgs e)
        {
            // change the model's isserialized property to true when the user edits it,
            // this is to make sure only user-edited properties will get serialized
            var model = e.ListViewItem.RowObject as IEditableVariable;
            if (model is CVariable cvar)
                cvar.SetIsSerialized();

            if (e.Control is ByteArrayEditor byteArrayEditor)
                byteArrayEditor.RequestBytesOpen -= ByteArrayEditor_RequestBytesOpen;
            if (e.Control is ArrayEditor arrayEditor)
                arrayEditor.RequestBytesOpen -= ByteArrayEditor_RequestBytesOpen;
        }

        private void ByteArrayEditor_RequestBytesOpen(object sender, RequestByteArrayFileOpenArgs e) =>
            RequestBytesOpen?.Invoke(this, e);

        public void ApplyCustomTheme()
        {
            UIController.Get().ToolStripExtender.SetStyle(toolStrip1, VisualStudioToolStripExtender.VsVersion.Vs2015, UIController.GetThemeBase());

            this.treeView.BackColor = UIController.GetBackColor();
            this.treeView.AlternateRowBackColor = UIController.GetPalette().OverflowButtonHovered.Background;

            this.treeView.ForeColor = UIController.GetForeColor();

            this.treeView.HeaderFormatStyle = UIController.GetHeaderFormatStyle();
            treeView.UnfocusedSelectedBackColor = UIController.GetPalette().CommandBarToolbarButtonPressed.Background;

            this.toolStripSearchBox.BackColor = UIController.GetPalette().ToolWindowCaptionButtonInactiveHovered.Background;
            this.toolStripSearchBox.ForeColor = UIController.GetForeColor();
        }
        #endregion

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(viewModel.SelectedChunks))
            {
                UpdateTreeListView();
            }
        }

        private void DeleteChunkTarget(HotKeyEventArgs e)
        {
            // remove target chunks
            if (viewModel.File is CR2WFile file)
            {
                file.RemoveChunks(
                    treeView.SelectedObjects.Cast<IChunkPtrAccessor>().Select(_ => _.Reference).ToList(),
                    false,
                    (CR2WFile.EChunkDisplayMode)viewModel.chunkDisplayMode);
            }
        }

        private void RemoveListElement(HotKeyEventArgs e)
        {
            // removing variables from arrays
            if (treeView.SelectedObjects.Count <= 0)
                return;

            var temp = new IEditableVariable[treeView.SelectedObjects.Count];
            treeView.SelectedObjects.CopyTo(temp,0);

            // remove target chunks if any ptr
            var toberemovedchunks = new List<CR2WExportWrapper>();
            foreach ( var selectedobject in treeView.SelectedObjects)
            {
                if (selectedobject is IChunkPtrAccessor chunkptraccessor &&
                    chunkptraccessor.ParentVar != null &&
                    chunkptraccessor.ParentVar.CanRemoveVariable(chunkptraccessor) &&
                    chunkptraccessor.Reference != null)
                {
                    toberemovedchunks.Add(chunkptraccessor.Reference);
                }
            }

            if (toberemovedchunks.Any())
            {
                if (viewModel.File is CR2WFile file)
                {
                    file.RemoveChunks(
                        toberemovedchunks,
                        false,
                        (CR2WFile.EChunkDisplayMode)viewModel.chunkDisplayMode);
                }
            }

            foreach (var node in temp)
            {
                node.ParentVar.RemoveVariable(node);
            }

            UpdateTreeListView();
        }


        #region Events
        private void addVariableToolStripMenuItem_Click(object sender, EventArgs e)
        {
             if (treeView.SelectedObject is IEditableVariable editableVariable)
                 viewModel.AddListElement(editableVariable);
        }

        private void removeVariableToolStripMenuItem_Click(object sender, EventArgs e) => RemoveListElement(null);

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            var selectedNodes = treeView.SelectedObjects.Cast<IEditableVariable>().ToList();
            if (selectedNodes.ToArray().Length <= 0)
            {
                e.Cancel = true;
                return;
            }

            // for carrays
            addVariableToolStripMenuItem.Enabled = selectedNodes.All(x => x.CanAddVariable(null));
            removeVariableToolStripMenuItem.Enabled = selectedNodes.All(x => x.ParentVar != null && x.ParentVar.CanRemoveVariable(x));

            //  paste variable is active if any one variable has been copied and if the one selected variable is of the same type
            pasteToolStripMenuItem.Enabled = IsPastingAllowed();


            goToChunkToolStripMenuItem.Enabled = selectedNodes.Count == 1 && selectedNodes.All(x => x is IChunkPtrAccessor);
            deleteChunkToolStripMenuItem.Enabled = selectedNodes.Count == 1 && selectedNodes.All(x => x is IChunkPtrAccessor);

            bool IsPastingAllowed()
            {
                if (CopyController.Source == null) return false;
                if (CopyController.Source.Count <= 0) return false;

                var firstcopy = CopyController.Source.FirstOrDefault();
                var areOfTheSameType = (firstcopy != null) && CopyController.Source.All(_ => _ is CVariable) 
                                              && CopyController.Source.All(p => p.REDType == firstcopy.REDType);
                // all copied files are CVariables
                if (areOfTheSameType && selectedNodes.Count == 1 && selectedNodes.First() is CVariable ctarget)
                {
                    // if only one variable was copied and that one variable is of the same type as the selected variable
                    if (CopyController.Source.Count == 1 
                        && CopyController.Source.First() is CVariable ccopy 
                        /*&& ctarget.GetType() == ccopy.GetType()*/)
                    {
                        // check if source type is subtype of targettype
                        if (ctarget.GetType().IsSubclassOf(ccopy.GetType()))
                            return true;
                        if (ccopy.GetType().IsSubclassOf(ctarget.GetType()))
                            return false;

                        return true;
                    }

                    // check if the target is an array and the elementtype is of the same type as the selected nodes
                    if (ctarget is IArrayAccessor targetarray && targetarray.Elementtype == firstcopy.REDType)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        internal void RefreshObject(IEditableVariable model) => treeView.RefreshObject(model);

        private void expandAllToolStripMenuItem_Click(object sender, EventArgs e) => treeView.ExpandAll();

        private void expandAllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = (IEditableVariable) treeView.SelectedObject;
            if (node != null)
            {
                treeView.Expand(node);
            }
        }

        private void collapseAllToolStripMenuItem_Click(object sender, EventArgs e) => treeView.CollapseAll();

        private void collapseAllChildrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = (IEditableVariable) treeView.SelectedObject;
            if (node != null)
            {
                treeView.Collapse(node);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => CopyVariable(null);

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) => PasteVariable(null);

        private void treeView_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Column == null || e.Item == null)
                return;

            if (e.ModifierKeys == Keys.Alt)
            {
                if (e.Model is IPtrAccessor ptr)
                {
                    viewModel.SelectedChunks = new List<CR2WExportWrapper>() { ptr.Reference };
                    //OnChunkRequest?.Invoke(this, new SelectChunkArgs() {Chunk =  } );
                    return;
                }
            }

            if (e.Column.AspectName == nameof(IEditableVariable.REDValue))
            {
                treeView.StartCellEdit(e.Item, olvColumn4.Index);
            }
        }

        private void GotoChunkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = (IEditableVariable)treeView.SelectedObject;
            if (node is IChunkPtrAccessor iptr && iptr.Reference != null)
            {
                viewModel.SelectedChunks = new List<CR2WExportWrapper>() { iptr.Reference };
            }
        }

        private void DeleteChunkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteChunkTarget(null);
        }


        private void copyTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = (IEditableVariable) treeView.SelectedObject;
            if (node != null)
            {
                if (string.IsNullOrEmpty(node.REDValue))
                    Clipboard.SetText($"{node.REDName} <{node.REDType}>");
                else
                    Clipboard.SetText($"{node.REDName} <{node.REDType}> = {node.REDValue}");
            }
        }

        private void treeView_ItemsChanged(object sender, ItemsChangedEventArgs e) => MainController.Get().ProjectUnsaved = true;

        private void treeView_FormatRow(object sender, FormatRowEventArgs e)
        {
            IEditableVariable model = (IEditableVariable)e.Model;
            if (model != null && (model.IsSerialized))
            {
                //if (!showOnlySerialized)
                {
                    int themeID = (int)UIController.Get().Configuration.ColorTheme;
                    var forecolor = Color.FromArgb(UIController.Get().Configuration.CustomHighlightColor[themeID]);
                    e.Item.ForeColor = forecolor;
                }
            }
            else
            {
                
            }

            // check for errors
            // do this here until we have a proper error log 
            if ((model is IPtrAccessor ptr && ptr.Reference == null) 
                || (model is IHandleAccessor handle && handle.ChunkHandle && handle.Reference == null))
            {
                if (model.IsSerialized)
                    e.Item.ForeColor = Color.Red;
            }
        }

        private void toolStripClearButton_Click(object sender, EventArgs e)
        {
            toolStripSearchBox.Clear();
            treeView.ModelFilter = null;
        }

        private void toolStripSearchBox_KeyUp(object sender, KeyEventArgs e)
        {
            treeView.ModelFilter = !string.IsNullOrEmpty(toolStripSearchBox.Text) 
                ? TextMatchFilter.Contains(treeView, toolStripSearchBox.Text.ToUpper()) 
                : null;
        }

        private void toolStripButtonShowSerialized_Click(object sender, EventArgs e)
        {
            // toggle
            showOnlySerialized = !showOnlySerialized;

            toolStripButtonShowSerialized.Text = showOnlySerialized
                ? "Show all variables"
                : "Show edited variables";

            UpdateTreeListView();
        }

        private void toolStripButtonColorPicker_Click(object sender, EventArgs e)
        {
            int themeID = (int)UIController.Get().Configuration.ColorTheme;
            Color forecolor = Color.FromArgb(UIController.Get().Configuration.CustomHighlightColor[themeID]);


            ColorDialog myDialog = new ColorDialog
            {
                AllowFullOpen = true,
                ShowHelp = true,
                Color = forecolor
            };

            // Update the text box color if the user clicks OK 
            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                UIController.Get().Configuration.CustomHighlightColor[themeID] = myDialog.Color.ToArgb();
                UIController.Get().Configuration.Save();
            }
        }

        #endregion

        private void ExpandBTN_Click(object sender, EventArgs e) => treeView.ExpandAll();

        private void CollapseBTN_Click(object sender, EventArgs e) => treeView.CollapseAll();

        private void changeHandleTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var node = (IEditableVariable)treeView.SelectedObject;
            if (node is IHandleAccessor ihdl)
            {
                ihdl.ChangeHandleType();
            }
        }
    }
}
