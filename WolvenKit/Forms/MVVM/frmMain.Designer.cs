﻿using System;
using System.ComponentModel;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WolvenKit
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                hotkeys?.Dispose();
                rwlock?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolbarToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNewMod = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnOpenMod = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSaveAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnAssetbrowser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLexarMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnPack = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnRunGame = new System.Windows.Forms.ToolStripDropDownButton();
            this.launchGameForDebuggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchWithCustomParametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packProjectAndRunGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packProjectAndLaunchGameCustomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripBtnImportUtil = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnRadishUtil = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCr2wToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractCollisioncacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.w2rigjsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.w2animsjsonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ModscriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modwwise = new System.Windows.Forms.ToolStripMenuItem();
            this.ModchunkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dlcwwise = new System.Windows.Forms.ToolStripMenuItem();
            this.DLCChunkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileFromBundleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileFromOtherModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderW2meshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verifyFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packAndInstallModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createPackedInstallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupModProjectToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.openBackupFolderToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.commandPromptHereToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchModkitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringsEncoderGUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packageInstallerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cR2WToTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.experimentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terrainViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDStoTextureCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openModFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDlcFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.unbundleGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncookGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.openUncookedFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.saveExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameDebuggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importUtilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.radishUtilitytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.resetDocumentLayoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joinOurDiscordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportABugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordStepsToReproduceBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutRedkit2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.witcherIIIModdingToolLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maximizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minimizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DLCScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.statusToolStrip = new System.Windows.Forms.ToolStrip();
            this.statusLBL = new System.Windows.Forms.ToolStripLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.wkitVersionToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.modNameToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButtonGit = new System.Windows.Forms.ToolStripDropDownButton();
            this.backupModProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.openBackupFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandPromptHereToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richpresenceworker = new System.ComponentModel.BackgroundWorker();
            this.visualStudioToolStripExtender1 = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.MainBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.visualStudioToolStripExtender2 = new WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender(this.components);
            this.watcher = new System.IO.FileSystemWatcher();
            this.toolbarToolStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watcher)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbarToolStrip
            // 
            this.toolbarToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolbarToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNewMod,
            this.toolStripBtnOpenMod,
            this.toolStripBtnOpenFile,
            this.toolStripSeparator1,
            this.toolStripBtnSave,
            this.toolStripBtnSaveAll,
            this.toolStripBtnAssetbrowser,
            this.toolStripButtonLexarMode,
            this.toolStripSeparator2,
            this.toolStripBtnPack,
            this.toolStripBtnRunGame,
            this.toolStripSeparator10,
            this.toolStripBtnImportUtil,
            this.toolStripBtnRadishUtil});
            this.toolbarToolStrip.Location = new System.Drawing.Point(0, 28);
            this.toolbarToolStrip.Name = "toolbarToolStrip";
            this.toolbarToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.toolbarToolStrip.Size = new System.Drawing.Size(1836, 27);
            this.toolbarToolStrip.Stretch = true;
            this.toolbarToolStrip.TabIndex = 6;
            this.toolbarToolStrip.Text = "topTS";
            // 
            // toolStripBtnNewMod
            // 
            this.toolStripBtnNewMod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnNewMod.Image = global::WolvenKit.Properties.Resources.NewSolutionFolder_16x;
            this.toolStripBtnNewMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNewMod.Name = "toolStripBtnNewMod";
            this.toolStripBtnNewMod.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnNewMod.Text = "New Mod";
            this.toolStripBtnNewMod.Click += new System.EventHandler(this.newModToolStripMenuItem_Click);
            // 
            // toolStripBtnOpenMod
            // 
            this.toolStripBtnOpenMod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnOpenMod.Image = global::WolvenKit.Properties.Resources.OpenFolder_16x;
            this.toolStripBtnOpenMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnOpenMod.Name = "toolStripBtnOpenMod";
            this.toolStripBtnOpenMod.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnOpenMod.Text = "Open Mod";
            this.toolStripBtnOpenMod.Click += new System.EventHandler(this.openModToolStripMenuItem_Click);
            // 
            // toolStripBtnOpenFile
            // 
            this.toolStripBtnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnOpenFile.Image = global::WolvenKit.Properties.Resources.OpenFile_16x;
            this.toolStripBtnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnOpenFile.Name = "toolStripBtnOpenFile";
            this.toolStripBtnOpenFile.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnOpenFile.Text = "Open CR2W File";
            this.toolStripBtnOpenFile.Click += new System.EventHandler(this.tbtOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripBtnSave
            // 
            this.toolStripBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSave.Image = global::WolvenKit.Properties.Resources.SaveStatusBar1_16x_c;
            this.toolStripBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSave.Name = "toolStripBtnSave";
            this.toolStripBtnSave.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnSave.Text = "Save";
            this.toolStripBtnSave.Click += new System.EventHandler(this.tbtSave_Click);
            // 
            // toolStripBtnSaveAll
            // 
            this.toolStripBtnSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnSaveAll.Image = global::WolvenKit.Properties.Resources.SaveAll_16x;
            this.toolStripBtnSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSaveAll.Name = "toolStripBtnSaveAll";
            this.toolStripBtnSaveAll.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnSaveAll.Text = "Save All";
            this.toolStripBtnSaveAll.ToolTipText = "Save All";
            this.toolStripBtnSaveAll.Click += new System.EventHandler(this.tbtSaveAll_Click);
            // 
            // toolStripBtnAssetbrowser
            // 
            this.toolStripBtnAssetbrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnAssetbrowser.Image = global::WolvenKit.Properties.Resources.Asset_Browser_16x;
            this.toolStripBtnAssetbrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAssetbrowser.Name = "toolStripBtnAssetbrowser";
            this.toolStripBtnAssetbrowser.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnAssetbrowser.Text = "Asset Browser";
            this.toolStripBtnAssetbrowser.ToolTipText = "Asset Browser";
            this.toolStripBtnAssetbrowser.Click += new System.EventHandler(this.OpenDepotAssetBrowserToolStripMenuItem_Click);
            // 
            // toolStripButtonLexarMode
            // 
            this.toolStripButtonLexarMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLexarMode.Image = global::WolvenKit.Properties.Resources.Asset_Browser_Other_Mod_16x;
            this.toolStripButtonLexarMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLexarMode.Name = "toolStripButtonLexarMode";
            this.toolStripButtonLexarMode.Size = new System.Drawing.Size(29, 24);
            this.toolStripButtonLexarMode.Text = "Lexar Mode";
            this.toolStripButtonLexarMode.ToolTipText = "Lexar Mode";
            this.toolStripButtonLexarMode.Click += new System.EventHandler(this.OpenModAssetBrowserToolStripMenuItem_Click_1);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripBtnPack
            // 
            this.toolStripBtnPack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnPack.Image = global::WolvenKit.Properties.Resources.package_16xLG;
            this.toolStripBtnPack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnPack.Name = "toolStripBtnPack";
            this.toolStripBtnPack.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnPack.Text = "Pack and Install Mod";
            this.toolStripBtnPack.ToolTipText = "Pack and Install Mod";
            this.toolStripBtnPack.Click += new System.EventHandler(this.toolStripBtnPack_Click);
            // 
            // toolStripBtnRunGame
            // 
            this.toolStripBtnRunGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnRunGame.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchGameForDebuggingToolStripMenuItem,
            this.launchWithCustomParametersToolStripMenuItem,
            this.packProjectToolStripMenuItem,
            this.packProjectAndRunGameToolStripMenuItem,
            this.packProjectAndLaunchGameCustomToolStripMenuItem});
            this.toolStripBtnRunGame.Image = global::WolvenKit.Properties.Resources.witcher3;
            this.toolStripBtnRunGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnRunGame.Name = "toolStripBtnRunGame";
            this.toolStripBtnRunGame.Size = new System.Drawing.Size(34, 24);
            this.toolStripBtnRunGame.Text = "Launch Game";
            // 
            // launchGameForDebuggingToolStripMenuItem
            // 
            this.launchGameForDebuggingToolStripMenuItem.Name = "launchGameForDebuggingToolStripMenuItem";
            this.launchGameForDebuggingToolStripMenuItem.Size = new System.Drawing.Size(459, 26);
            this.launchGameForDebuggingToolStripMenuItem.Text = "Launch Game for Debugging";
            this.launchGameForDebuggingToolStripMenuItem.Click += new System.EventHandler(this.LaunchGameForDebuggingToolStripMenuItem_Click);
            // 
            // launchWithCustomParametersToolStripMenuItem
            // 
            this.launchWithCustomParametersToolStripMenuItem.Name = "launchWithCustomParametersToolStripMenuItem";
            this.launchWithCustomParametersToolStripMenuItem.Size = new System.Drawing.Size(459, 26);
            this.launchWithCustomParametersToolStripMenuItem.Text = "Launch Game With Custom Parameters";
            this.launchWithCustomParametersToolStripMenuItem.Click += new System.EventHandler(this.launchWithCostumParametersToolStripMenuItem_Click);
            // 
            // packProjectToolStripMenuItem
            // 
            this.packProjectToolStripMenuItem.Name = "packProjectToolStripMenuItem";
            this.packProjectToolStripMenuItem.Size = new System.Drawing.Size(459, 26);
            this.packProjectToolStripMenuItem.Text = "Pack Project";
            this.packProjectToolStripMenuItem.Click += new System.EventHandler(this.packProjectToolStripMenuItem_Click);
            // 
            // packProjectAndRunGameToolStripMenuItem
            // 
            this.packProjectAndRunGameToolStripMenuItem.Name = "packProjectAndRunGameToolStripMenuItem";
            this.packProjectAndRunGameToolStripMenuItem.Size = new System.Drawing.Size(459, 26);
            this.packProjectAndRunGameToolStripMenuItem.Text = "Pack Project and Launch Game";
            this.packProjectAndRunGameToolStripMenuItem.Click += new System.EventHandler(this.PackProjectAndRunGameToolStripMenuItem_Click);
            // 
            // packProjectAndLaunchGameCustomToolStripMenuItem
            // 
            this.packProjectAndLaunchGameCustomToolStripMenuItem.Name = "packProjectAndLaunchGameCustomToolStripMenuItem";
            this.packProjectAndLaunchGameCustomToolStripMenuItem.Size = new System.Drawing.Size(459, 26);
            this.packProjectAndLaunchGameCustomToolStripMenuItem.Text = "Pack Project and Launch Game With Custom Parameters";
            this.packProjectAndLaunchGameCustomToolStripMenuItem.Click += new System.EventHandler(this.packProjectAndLaunchGameCustomToolStripMenuItem_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripBtnImportUtil
            // 
            this.toolStripBtnImportUtil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnImportUtil.Image = global::WolvenKit.Properties.Resources.ImportPackage_16x;
            this.toolStripBtnImportUtil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnImportUtil.Name = "toolStripBtnImportUtil";
            this.toolStripBtnImportUtil.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnImportUtil.Text = "Import Utility";
            this.toolStripBtnImportUtil.Click += new System.EventHandler(this.toolStripButtonImportUtil_Click);
            // 
            // toolStripBtnRadishUtil
            // 
            this.toolStripBtnRadishUtil.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripBtnRadishUtil.Image = global::WolvenKit.Properties.Resources.radish_32x;
            this.toolStripBtnRadishUtil.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnRadishUtil.Name = "toolStripBtnRadishUtil";
            this.toolStripBtnRadishUtil.Size = new System.Drawing.Size(29, 24);
            this.toolStripBtnRadishUtil.Text = "Radish Utility";
            this.toolStripBtnRadishUtil.Click += new System.EventHandler(this.toolStripButtonRadishUtil_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.modToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.gameToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.maximizeToolStripMenuItem,
            this.minimizeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1836, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "topMS";
            this.menuStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.menuStrip1_MouseDown_1);
            // 
            // iconToolStripMenuItem
            // 
            this.iconToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.iconToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.WK_Logo2_32;
            this.iconToolStripMenuItem.Name = "iconToolStripMenuItem";
            this.iconToolStripMenuItem.Size = new System.Drawing.Size(34, 24);
            this.iconToolStripMenuItem.Click += new System.EventHandler(this.iconToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newModToolStripMenuItem,
            this.openModToolStripMenuItem,
            this.openFileToolStripMenuItem,
            this.recentFilesToolStripMenuItem,
            this.toolStripSeparator6,
            this.exportToolStripMenuItem,
            this.importToolStripMenuItem,
            this.newFileToolStripMenuItem,
            this.addFileFromBundleToolStripMenuItem,
            this.addFileFromOtherModToolStripMenuItem,
            this.addFileToolStripMenuItem,
            this.toolStripSeparator8,
            this.saveToolStripMenuItem,
            this.saveAllToolStripMenuItem,
            this.toolStripSeparator3,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // newModToolStripMenuItem
            // 
            this.newModToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.NewSolutionFolder_16x;
            this.newModToolStripMenuItem.Name = "newModToolStripMenuItem";
            this.newModToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.newModToolStripMenuItem.Text = "New Mod";
            this.newModToolStripMenuItem.Click += new System.EventHandler(this.tbtNewMod_Click);
            // 
            // openModToolStripMenuItem
            // 
            this.openModToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.OpenFolder_16x;
            this.openModToolStripMenuItem.Name = "openModToolStripMenuItem";
            this.openModToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.openModToolStripMenuItem.Text = "Open Mod";
            this.openModToolStripMenuItem.Click += new System.EventHandler(this.tbtOpenMod_Click);
            // 
            // openFileToolStripMenuItem
            // 
            this.openFileToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.OpenFile_16x;
            this.openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            this.openFileToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.openFileToolStripMenuItem.Text = "Open CR2W File";
            this.openFileToolStripMenuItem.Click += new System.EventHandler(this.openFileToolStripMenuItem_Click);
            // 
            // recentFilesToolStripMenuItem
            // 
            this.recentFilesToolStripMenuItem.Enabled = false;
            this.recentFilesToolStripMenuItem.Name = "recentFilesToolStripMenuItem";
            this.recentFilesToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.recentFilesToolStripMenuItem.Text = "Recent Files";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(258, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportCr2wToolStripMenuItem,
            this.extractCollisioncacheToolStripMenuItem});
            this.exportToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.wooden_box__arrow;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // exportCr2wToolStripMenuItem
            // 
            this.exportCr2wToolStripMenuItem.Name = "exportCr2wToolStripMenuItem";
            this.exportCr2wToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.exportCr2wToolStripMenuItem.Text = "Export Cr2w";
            this.exportCr2wToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // extractCollisioncacheToolStripMenuItem
            // 
            this.extractCollisioncacheToolStripMenuItem.Name = "extractCollisioncacheToolStripMenuItem";
            this.extractCollisioncacheToolStripMenuItem.Size = new System.Drawing.Size(237, 26);
            this.extractCollisioncacheToolStripMenuItem.Text = "Extract collision.cache";
            this.extractCollisioncacheToolStripMenuItem.Click += new System.EventHandler(this.extractCollisioncacheToolStripMenuItem_Click);
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.w2rigjsonToolStripMenuItem,
            this.w2animsjsonToolStripMenuItem});
            this.importToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.box__arrow;
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.importToolStripMenuItem.Text = "Import";
            // 
            // w2rigjsonToolStripMenuItem
            // 
            this.w2rigjsonToolStripMenuItem.Name = "w2rigjsonToolStripMenuItem";
            this.w2rigjsonToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.w2rigjsonToolStripMenuItem.Text = "w2rig.json";
            this.w2rigjsonToolStripMenuItem.Click += new System.EventHandler(this.w2rigjsonToolStripMenuItem_Click);
            // 
            // w2animsjsonToolStripMenuItem
            // 
            this.w2animsjsonToolStripMenuItem.Name = "w2animsjsonToolStripMenuItem";
            this.w2animsjsonToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.w2animsjsonToolStripMenuItem.Text = "w2anims.json";
            this.w2animsjsonToolStripMenuItem.Click += new System.EventHandler(this.w2animsjsonToolStripMenuItem_Click);
            // 
            // newFileToolStripMenuItem
            // 
            this.newFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modToolStripMenuItem1,
            this.dLCToolStripMenuItem});
            this.newFileToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.FileGroup_10135_16x;
            this.newFileToolStripMenuItem.Name = "newFileToolStripMenuItem";
            this.newFileToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.newFileToolStripMenuItem.Text = "New File";
            // 
            // modToolStripMenuItem1
            // 
            this.modToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModscriptToolStripMenuItem,
            this.modwwise,
            this.ModchunkToolStripMenuItem});
            this.modToolStripMenuItem1.Name = "modToolStripMenuItem1";
            this.modToolStripMenuItem1.Size = new System.Drawing.Size(123, 26);
            this.modToolStripMenuItem1.Text = "Mod";
            // 
            // ModscriptToolStripMenuItem
            // 
            this.ModscriptToolStripMenuItem.Name = "ModscriptToolStripMenuItem";
            this.ModscriptToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.ModscriptToolStripMenuItem.Text = "Script";
            this.ModscriptToolStripMenuItem.Click += new System.EventHandler(this.ModscriptToolStripMenuItem_Click);
            // 
            // modwwise
            // 
            this.modwwise.Name = "modwwise";
            this.modwwise.Size = new System.Drawing.Size(221, 26);
            this.modwwise.Text = "Wwise sound(bank)";
            this.modwwise.Click += new System.EventHandler(this.ModWwiseNew_Click);
            // 
            // ModchunkToolStripMenuItem
            // 
            this.ModchunkToolStripMenuItem.Name = "ModchunkToolStripMenuItem";
            this.ModchunkToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.ModchunkToolStripMenuItem.Text = "Chunk file";
            this.ModchunkToolStripMenuItem.Click += new System.EventHandler(this.ModchunkToolStripMenuItem_Click);
            // 
            // dLCToolStripMenuItem
            // 
            this.dLCToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dlcwwise,
            this.DLCChunkToolStripMenuItem});
            this.dLCToolStripMenuItem.Name = "dLCToolStripMenuItem";
            this.dLCToolStripMenuItem.Size = new System.Drawing.Size(123, 26);
            this.dLCToolStripMenuItem.Text = "DLC";
            // 
            // dlcwwise
            // 
            this.dlcwwise.Name = "dlcwwise";
            this.dlcwwise.Size = new System.Drawing.Size(221, 26);
            this.dlcwwise.Text = "Wwise sound(bank)";
            this.dlcwwise.Click += new System.EventHandler(this.DLCWwise_Click);
            // 
            // DLCChunkToolStripMenuItem
            // 
            this.DLCChunkToolStripMenuItem.Name = "DLCChunkToolStripMenuItem";
            this.DLCChunkToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.DLCChunkToolStripMenuItem.Text = "Chunk file";
            this.DLCChunkToolStripMenuItem.Click += new System.EventHandler(this.DLCChunkToolStripMenuItem_Click);
            // 
            // addFileFromBundleToolStripMenuItem
            // 
            this.addFileFromBundleToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.Asset_Browser_16x;
            this.addFileFromBundleToolStripMenuItem.Name = "addFileFromBundleToolStripMenuItem";
            this.addFileFromBundleToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.addFileFromBundleToolStripMenuItem.Text = "Asset Browser";
            this.addFileFromBundleToolStripMenuItem.ToolTipText = "Browse bundled assets directly from game installation";
            this.addFileFromBundleToolStripMenuItem.Click += new System.EventHandler(this.OpenDepotAssetBrowserToolStripMenuItem_Click);
            // 
            // addFileFromOtherModToolStripMenuItem
            // 
            this.addFileFromOtherModToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.Asset_Browser_Other_Mod_16x;
            this.addFileFromOtherModToolStripMenuItem.Name = "addFileFromOtherModToolStripMenuItem";
            this.addFileFromOtherModToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.addFileFromOtherModToolStripMenuItem.Text = "Add File From Other Mod";
            this.addFileFromOtherModToolStripMenuItem.ToolTipText = "Browse user-generated bundles from Mods and DLC game folders";
            this.addFileFromOtherModToolStripMenuItem.Click += new System.EventHandler(this.OpenModAssetBrowserToolStripMenuItem_Click_1);
            // 
            // addFileToolStripMenuItem
            // 
            this.addFileToolStripMenuItem.Enabled = false;
            this.addFileToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.FindInFile_16x;
            this.addFileToolStripMenuItem.Name = "addFileToolStripMenuItem";
            this.addFileToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.addFileToolStripMenuItem.Text = "Add File";
            this.addFileToolStripMenuItem.ToolTipText = "Add generic file to project";
            this.addFileToolStripMenuItem.Click += new System.EventHandler(this.addFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(258, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.SaveStatusBar1_16x_c;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+S";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.SaveAll_16x;
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+S";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.saveAllToolStripMenuItem.Text = "Save All";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(258, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(261, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderW2meshToolStripMenuItem,
            this.verifyFileToolStripMenuItem,
            this.toolStripSeparator5,
            this.optionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // renderW2meshToolStripMenuItem
            // 
            this.renderW2meshToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.ui_check_box_uncheck;
            this.renderW2meshToolStripMenuItem.Name = "renderW2meshToolStripMenuItem";
            this.renderW2meshToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.renderW2meshToolStripMenuItem.Tag = "false";
            this.renderW2meshToolStripMenuItem.Text = "Render w2mesh";
            this.renderW2meshToolStripMenuItem.ToolTipText = "Choose to automatically render w2mesh files when opened";
            this.renderW2meshToolStripMenuItem.Click += new System.EventHandler(this.renderW2meshToolStripMenuItem_Click);
            // 
            // verifyFileToolStripMenuItem
            // 
            this.verifyFileToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.ValidateDocument_16x;
            this.verifyFileToolStripMenuItem.Name = "verifyFileToolStripMenuItem";
            this.verifyFileToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.verifyFileToolStripMenuItem.Text = "Verify File";
            this.verifyFileToolStripMenuItem.ToolTipText = "Fixes bugged CR2W files from old WolvenKit saving method.";
            this.verifyFileToolStripMenuItem.Click += new System.EventHandler(this.verifyFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(194, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.Settings_Inverse_16x;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.optionsToolStripMenuItem.Text = "Preferences";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // modToolStripMenuItem
            // 
            this.modToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.packAndInstallModToolStripMenuItem,
            this.createPackedInstallerToolStripMenuItem,
            this.reloadProjectToolStripMenuItem,
            this.backupModProjectToolStripMenuItem1,
            this.toolStripSeparator4,
            this.settingsToolStripMenuItem});
            this.modToolStripMenuItem.Name = "modToolStripMenuItem";
            this.modToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.modToolStripMenuItem.Text = "Project";
            this.modToolStripMenuItem.DropDownOpening += new System.EventHandler(this.modToolStripMenuItem_DropDownOpening);
            // 
            // packAndInstallModToolStripMenuItem
            // 
            this.packAndInstallModToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.package_16xLG;
            this.packAndInstallModToolStripMenuItem.Name = "packAndInstallModToolStripMenuItem";
            this.packAndInstallModToolStripMenuItem.ShortcutKeyDisplayString = "F5";
            this.packAndInstallModToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.packAndInstallModToolStripMenuItem.Text = "Pack and Install Mod";
            this.packAndInstallModToolStripMenuItem.Click += new System.EventHandler(this.toolStripBtnPack_Click);
            // 
            // createPackedInstallerToolStripMenuItem
            // 
            this.createPackedInstallerToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.box__arrow;
            this.createPackedInstallerToolStripMenuItem.Name = "createPackedInstallerToolStripMenuItem";
            this.createPackedInstallerToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.createPackedInstallerToolStripMenuItem.Text = "Create Packed Installer";
            this.createPackedInstallerToolStripMenuItem.Click += new System.EventHandler(this.createPackedInstallerToolStripMenuItem_Click);
            // 
            // reloadProjectToolStripMenuItem
            // 
            this.reloadProjectToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.Refresh_16x;
            this.reloadProjectToolStripMenuItem.Name = "reloadProjectToolStripMenuItem";
            this.reloadProjectToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.reloadProjectToolStripMenuItem.Text = "Reload Project";
            this.reloadProjectToolStripMenuItem.Click += new System.EventHandler(this.ReloadProjectToolStripMenuItem_Click);
            // 
            // backupModProjectToolStripMenuItem1
            // 
            this.backupModProjectToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.toolStripSeparator14,
            this.openBackupFolderToolStripMenuItem1,
            this.commandPromptHereToolStripMenuItem1});
            this.backupModProjectToolStripMenuItem1.Image = global::WolvenKit.Properties.Resources.git;
            this.backupModProjectToolStripMenuItem1.Name = "backupModProjectToolStripMenuItem1";
            this.backupModProjectToolStripMenuItem1.Size = new System.Drawing.Size(252, 26);
            this.backupModProjectToolStripMenuItem1.Text = "Backup Mod Project";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.git;
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.backupToolStripMenuItem.Text = "Backup Now";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupModProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(247, 6);
            // 
            // openBackupFolderToolStripMenuItem1
            // 
            this.openBackupFolderToolStripMenuItem1.Image = global::WolvenKit.Properties.Resources.Open_16x;
            this.openBackupFolderToolStripMenuItem1.Name = "openBackupFolderToolStripMenuItem1";
            this.openBackupFolderToolStripMenuItem1.Size = new System.Drawing.Size(250, 26);
            this.openBackupFolderToolStripMenuItem1.Text = "Open Backup Folder";
            this.openBackupFolderToolStripMenuItem1.Click += new System.EventHandler(this.openBackupFolderToolStripMenuItem_Click);
            // 
            // commandPromptHereToolStripMenuItem1
            // 
            this.commandPromptHereToolStripMenuItem1.Image = global::WolvenKit.Properties.Resources.Console_16x;
            this.commandPromptHereToolStripMenuItem1.Name = "commandPromptHereToolStripMenuItem1";
            this.commandPromptHereToolStripMenuItem1.Size = new System.Drawing.Size(250, 26);
            this.commandPromptHereToolStripMenuItem1.Text = "Command Prompt Here";
            this.commandPromptHereToolStripMenuItem1.Click += new System.EventHandler(this.commandPromptHereToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(249, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.properties_16xLG;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(252, 26);
            this.settingsToolStripMenuItem.Text = "Mod Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.modSettingsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.launchModkitToolStripMenuItem,
            this.stringsEncoderGUIToolStripMenuItem,
            this.menuCreatorToolStripMenuItem,
            this.packageInstallerToolStripMenuItem,
            this.cR2WToTextToolStripMenuItem,
            this.experimentalToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.toolsToolStripMenuItem_DropDownOpening);
            // 
            // launchModkitToolStripMenuItem
            // 
            this.launchModkitToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.WCC_32x;
            this.launchModkitToolStripMenuItem.Name = "launchModkitToolStripMenuItem";
            this.launchModkitToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.launchModkitToolStripMenuItem.Text = "Modkit";
            this.launchModkitToolStripMenuItem.ToolTipText = "Interface for all wcc_lite commands";
            this.launchModkitToolStripMenuItem.Click += new System.EventHandler(this.witcher3ModkitToolStripMenuItem_Click);
            // 
            // stringsEncoderGUIToolStripMenuItem
            // 
            this.stringsEncoderGUIToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.Strings_Encoder_16x;
            this.stringsEncoderGUIToolStripMenuItem.Name = "stringsEncoderGUIToolStripMenuItem";
            this.stringsEncoderGUIToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.stringsEncoderGUIToolStripMenuItem.Text = "Strings Encoder";
            this.stringsEncoderGUIToolStripMenuItem.ToolTipText = "Encodes w3strings from pre-existing strings or CSV files";
            this.stringsEncoderGUIToolStripMenuItem.Click += new System.EventHandler(this.StringsGUIToolStripMenuItem_Click);
            // 
            // menuCreatorToolStripMenuItem
            // 
            this.menuCreatorToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.ui_menu_blue;
            this.menuCreatorToolStripMenuItem.Name = "menuCreatorToolStripMenuItem";
            this.menuCreatorToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.menuCreatorToolStripMenuItem.Text = "Menu Creator";
            this.menuCreatorToolStripMenuItem.Click += new System.EventHandler(this.menuCreatorToolStripMenuItem_Click);
            // 
            // packageInstallerToolStripMenuItem
            // 
            this.packageInstallerToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.box;
            this.packageInstallerToolStripMenuItem.Name = "packageInstallerToolStripMenuItem";
            this.packageInstallerToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.packageInstallerToolStripMenuItem.Text = "Package Installer";
            this.packageInstallerToolStripMenuItem.Click += new System.EventHandler(this.packageInstallerToolStripMenuItem_Click);
            // 
            // cR2WToTextToolStripMenuItem
            // 
            this.cR2WToTextToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.UserCode_16x;
            this.cR2WToTextToolStripMenuItem.Name = "cR2WToTextToolStripMenuItem";
            this.cR2WToTextToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.cR2WToTextToolStripMenuItem.Text = "CR2W To Text";
            this.cR2WToTextToolStripMenuItem.Click += new System.EventHandler(this.cR2WToTextToolStripMenuItem_Click);
            // 
            // experimentalToolStripMenuItem
            // 
            this.experimentalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terrainViewerToolStripMenuItem,
            this.bulkEditorToolStripMenuItem,
            this.sceneViewerToolStripMenuItem,
            this.dDStoTextureCacheToolStripMenuItem});
            this.experimentalToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.Test_16x;
            this.experimentalToolStripMenuItem.Name = "experimentalToolStripMenuItem";
            this.experimentalToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.experimentalToolStripMenuItem.Text = "Experimental";
            // 
            // terrainViewerToolStripMenuItem
            // 
            this.terrainViewerToolStripMenuItem.Name = "terrainViewerToolStripMenuItem";
            this.terrainViewerToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.terrainViewerToolStripMenuItem.Text = "Terrain Viewer";
            this.terrainViewerToolStripMenuItem.Click += new System.EventHandler(this.terrainViewerToolStripMenuItem_Click_1);
            // 
            // bulkEditorToolStripMenuItem
            // 
            this.bulkEditorToolStripMenuItem.Name = "bulkEditorToolStripMenuItem";
            this.bulkEditorToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.bulkEditorToolStripMenuItem.Text = "Bulk Editor";
            this.bulkEditorToolStripMenuItem.Click += new System.EventHandler(this.bulkEditorToolStripMenuItem_Click);
            // 
            // sceneViewerToolStripMenuItem
            // 
            this.sceneViewerToolStripMenuItem.Name = "sceneViewerToolStripMenuItem";
            this.sceneViewerToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.sceneViewerToolStripMenuItem.Text = "Scene Viewer";
            this.sceneViewerToolStripMenuItem.Click += new System.EventHandler(this.sceneViewerToolStripMenuItem_Click);
            // 
            // dDStoTextureCacheToolStripMenuItem
            // 
            this.dDStoTextureCacheToolStripMenuItem.Name = "dDStoTextureCacheToolStripMenuItem";
            this.dDStoTextureCacheToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.dDStoTextureCacheToolStripMenuItem.Text = "DDS-to-TextureCache";
            this.dDStoTextureCacheToolStripMenuItem.Click += new System.EventHandler(this.dDStoTextureCacheToolStripMenuItem_Click);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openModFolderToolStripMenuItem,
            this.openDlcFolderToolStripMenuItem,
            this.toolStripSeparator15,
            this.unbundleGameToolStripMenuItem,
            this.uncookGameToolStripMenuItem,
            this.toolStripSeparator12,
            this.openUncookedFolderToolStripMenuItem,
            this.toolStripSeparator16,
            this.saveExplorerToolStripMenuItem,
            this.GameDebuggerToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.gameToolStripMenuItem.Text = "Game";
            this.gameToolStripMenuItem.DropDownOpening += new System.EventHandler(this.gameToolStripMenuItem_DropDownOpening);
            // 
            // openModFolderToolStripMenuItem
            // 
            this.openModFolderToolStripMenuItem.Name = "openModFolderToolStripMenuItem";
            this.openModFolderToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.openModFolderToolStripMenuItem.Text = "Open Mod Folder";
            this.openModFolderToolStripMenuItem.Click += new System.EventHandler(this.openModFolderToolStripMenuItem_Click);
            // 
            // openDlcFolderToolStripMenuItem
            // 
            this.openDlcFolderToolStripMenuItem.Name = "openDlcFolderToolStripMenuItem";
            this.openDlcFolderToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.openDlcFolderToolStripMenuItem.Text = "Open Dlc Folder";
            this.openDlcFolderToolStripMenuItem.Click += new System.EventHandler(this.openDlcFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(242, 6);
            // 
            // unbundleGameToolStripMenuItem
            // 
            this.unbundleGameToolStripMenuItem.Name = "unbundleGameToolStripMenuItem";
            this.unbundleGameToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.unbundleGameToolStripMenuItem.Text = "Unbundle Game";
            this.unbundleGameToolStripMenuItem.ToolTipText = "Extracts compressed files from installed game";
            this.unbundleGameToolStripMenuItem.Click += new System.EventHandler(this.unbundleGameToolStripMenuItem_Click);
            // 
            // uncookGameToolStripMenuItem
            // 
            this.uncookGameToolStripMenuItem.Name = "uncookGameToolStripMenuItem";
            this.uncookGameToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.uncookGameToolStripMenuItem.Text = "Uncook Game";
            this.uncookGameToolStripMenuItem.ToolTipText = "Extracts compressed files from installed game, and \"un-compresses\" the files (e.g" +
    ". combines mesh and buffer files into single w2mesh)";
            this.uncookGameToolStripMenuItem.Click += new System.EventHandler(this.uncookGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(242, 6);
            // 
            // openUncookedFolderToolStripMenuItem
            // 
            this.openUncookedFolderToolStripMenuItem.Name = "openUncookedFolderToolStripMenuItem";
            this.openUncookedFolderToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.openUncookedFolderToolStripMenuItem.Text = "Open Uncooked Folder";
            this.openUncookedFolderToolStripMenuItem.ToolTipText = "Opens r4data folder location";
            this.openUncookedFolderToolStripMenuItem.Click += new System.EventHandler(this.openUncookedFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(242, 6);
            // 
            // saveExplorerToolStripMenuItem
            // 
            this.saveExplorerToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.witcher3;
            this.saveExplorerToolStripMenuItem.Name = "saveExplorerToolStripMenuItem";
            this.saveExplorerToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.saveExplorerToolStripMenuItem.Text = "Save Explorer";
            this.saveExplorerToolStripMenuItem.Click += new System.EventHandler(this.saveExplorerToolStripMenuItem_Click);
            // 
            // GameDebuggerToolStripMenuItem
            // 
            this.GameDebuggerToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.bug;
            this.GameDebuggerToolStripMenuItem.Name = "GameDebuggerToolStripMenuItem";
            this.GameDebuggerToolStripMenuItem.Size = new System.Drawing.Size(245, 26);
            this.GameDebuggerToolStripMenuItem.Text = "Game Debugger";
            this.GameDebuggerToolStripMenuItem.Click += new System.EventHandler(this.GameDebuggerToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modExplorerToolStripMenuItem,
            this.outputToolStripMenuItem,
            this.consoleToolStripMenuItem,
            this.scriptToolStripMenuItem,
            this.importUtilityToolStripMenuItem,
            this.radishUtilitytoolStripMenuItem,
            this.toolStripSeparator9,
            this.resetDocumentLayoutToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.viewToolStripMenuItem_DropDownOpening);
            // 
            // modExplorerToolStripMenuItem
            // 
            this.modExplorerToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.RemoteServer_16x;
            this.modExplorerToolStripMenuItem.Name = "modExplorerToolStripMenuItem";
            this.modExplorerToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.modExplorerToolStripMenuItem.Text = "Mod Explorer";
            this.modExplorerToolStripMenuItem.Click += new System.EventHandler(this.modExplorerToolStripMenuItem_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.Output_16x;
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.outputToolStripMenuItem.Text = "Output";
            this.outputToolStripMenuItem.Click += new System.EventHandler(this.OutputToolStripMenuItem_Click);
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.Console_16x;
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.consoleToolStripMenuItem.Text = "Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // scriptToolStripMenuItem
            // 
            this.scriptToolStripMenuItem.Enabled = false;
            this.scriptToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.PlayStep_16x;
            this.scriptToolStripMenuItem.Name = "scriptToolStripMenuItem";
            this.scriptToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.scriptToolStripMenuItem.Text = "Script Manager";
            this.scriptToolStripMenuItem.Click += new System.EventHandler(this.scriptToolStripMenuItem_Click);
            // 
            // importUtilityToolStripMenuItem
            // 
            this.importUtilityToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.ImportPackage_16x;
            this.importUtilityToolStripMenuItem.Name = "importUtilityToolStripMenuItem";
            this.importUtilityToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.importUtilityToolStripMenuItem.Text = "Import Utility";
            this.importUtilityToolStripMenuItem.ToolTipText = "Utility for importing raw assets to CR2W files (e.g. FBX to w2mesh)";
            this.importUtilityToolStripMenuItem.Click += new System.EventHandler(this.importUtilityToolStripMenuItem_Click);
            // 
            // radishUtilitytoolStripMenuItem
            // 
            this.radishUtilitytoolStripMenuItem.Image = global::WolvenKit.Properties.Resources.radish_32x;
            this.radishUtilitytoolStripMenuItem.Name = "radishUtilitytoolStripMenuItem";
            this.radishUtilitytoolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.radishUtilitytoolStripMenuItem.Text = "Radish Utility";
            this.radishUtilitytoolStripMenuItem.ToolTipText = "Utility for managing Radish project directory (installed separately)";
            this.radishUtilitytoolStripMenuItem.Click += new System.EventHandler(this.RadishUtilitytoolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(246, 6);
            // 
            // resetDocumentLayoutToolStripMenuItem
            // 
            this.resetDocumentLayoutToolStripMenuItem.Name = "resetDocumentLayoutToolStripMenuItem";
            this.resetDocumentLayoutToolStripMenuItem.Size = new System.Drawing.Size(249, 26);
            this.resetDocumentLayoutToolStripMenuItem.Text = "Reset Document Layout";
            this.resetDocumentLayoutToolStripMenuItem.Click += new System.EventHandler(this.resetDocumentLayoutToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joinOurDiscordToolStripMenuItem,
            this.reportABugToolStripMenuItem,
            this.recordStepsToReproduceBugToolStripMenuItem,
            this.tutorialsToolStripMenuItem,
            this.toolStripSeparator7,
            this.aboutRedkit2ToolStripMenuItem,
            this.witcherIIIModdingToolLicenseToolStripMenuItem,
            this.donateToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.aboutToolStripMenuItem.Text = "Help";
            // 
            // joinOurDiscordToolStripMenuItem
            // 
            this.joinOurDiscordToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.Discord_32x;
            this.joinOurDiscordToolStripMenuItem.Name = "joinOurDiscordToolStripMenuItem";
            this.joinOurDiscordToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.joinOurDiscordToolStripMenuItem.Text = "Join Our Discord";
            this.joinOurDiscordToolStripMenuItem.Click += new System.EventHandler(this.joinOurDiscordToolStripMenuItem_Click_1);
            // 
            // reportABugToolStripMenuItem
            // 
            this.reportABugToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.MailOpen_16x;
            this.reportABugToolStripMenuItem.Name = "reportABugToolStripMenuItem";
            this.reportABugToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.reportABugToolStripMenuItem.Text = "Report a Bug";
            this.reportABugToolStripMenuItem.Click += new System.EventHandler(this.ReportABugToolStripMenuItem_Click);
            // 
            // recordStepsToReproduceBugToolStripMenuItem
            // 
            this.recordStepsToReproduceBugToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.StatusNotStarted_red_16x;
            this.recordStepsToReproduceBugToolStripMenuItem.Name = "recordStepsToReproduceBugToolStripMenuItem";
            this.recordStepsToReproduceBugToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.recordStepsToReproduceBugToolStripMenuItem.Text = "Record Steps to Reproduce a Bug";
            this.recordStepsToReproduceBugToolStripMenuItem.Click += new System.EventHandler(this.RecordStepsToReproduceBugToolStripMenuItem_Click);
            // 
            // tutorialsToolStripMenuItem
            // 
            this.tutorialsToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.StatusInformation_exp_16x;
            this.tutorialsToolStripMenuItem.Name = "tutorialsToolStripMenuItem";
            this.tutorialsToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.tutorialsToolStripMenuItem.Text = "Witcherscript Documentation";
            this.tutorialsToolStripMenuItem.Click += new System.EventHandler(this.WitcherScriptToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(312, 6);
            // 
            // aboutRedkit2ToolStripMenuItem
            // 
            this.aboutRedkit2ToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.WK_Logo2_32;
            this.aboutRedkit2ToolStripMenuItem.Name = "aboutRedkit2ToolStripMenuItem";
            this.aboutRedkit2ToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.aboutRedkit2ToolStripMenuItem.Text = "About WolvenKit";
            this.aboutRedkit2ToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click);
            // 
            // witcherIIIModdingToolLicenseToolStripMenuItem
            // 
            this.witcherIIIModdingToolLicenseToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.witcher3;
            this.witcherIIIModdingToolLicenseToolStripMenuItem.Name = "witcherIIIModdingToolLicenseToolStripMenuItem";
            this.witcherIIIModdingToolLicenseToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.witcherIIIModdingToolLicenseToolStripMenuItem.Text = "Witcher 3 Modding Tool License";
            this.witcherIIIModdingToolLicenseToolStripMenuItem.Click += new System.EventHandler(this.witcherIIIModdingToolLicenseToolStripMenuItem_Click);
            // 
            // donateToolStripMenuItem
            // 
            this.donateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("donateToolStripMenuItem.Image")));
            this.donateToolStripMenuItem.Name = "donateToolStripMenuItem";
            this.donateToolStripMenuItem.Size = new System.Drawing.Size(315, 26);
            this.donateToolStripMenuItem.Text = "Donate";
            this.donateToolStripMenuItem.Click += new System.EventHandler(this.donateToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.window_close_24x;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(34, 24);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.ToolTipText = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // maximizeToolStripMenuItem
            // 
            this.maximizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.maximizeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.maximizeToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.window_maximize_24x;
            this.maximizeToolStripMenuItem.Name = "maximizeToolStripMenuItem";
            this.maximizeToolStripMenuItem.Size = new System.Drawing.Size(34, 24);
            this.maximizeToolStripMenuItem.Text = "Maximize";
            this.maximizeToolStripMenuItem.ToolTipText = "Restore";
            this.maximizeToolStripMenuItem.Click += new System.EventHandler(this.RestoreToolStripMenuItem_Click);
            // 
            // minimizeToolStripMenuItem
            // 
            this.minimizeToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.minimizeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.minimizeToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.window_minimize_24x;
            this.minimizeToolStripMenuItem.Name = "minimizeToolStripMenuItem";
            this.minimizeToolStripMenuItem.Size = new System.Drawing.Size(34, 24);
            this.minimizeToolStripMenuItem.Text = "Minimize";
            this.minimizeToolStripMenuItem.ToolTipText = "Minimize";
            this.minimizeToolStripMenuItem.Click += new System.EventHandler(this.MinimizeToolStripMenuItem_Click);
            // 
            // DLCScriptToolStripMenuItem
            // 
            this.DLCScriptToolStripMenuItem.Name = "DLCScriptToolStripMenuItem";
            this.DLCScriptToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.DLCScriptToolStripMenuItem.Text = "Script";
            this.DLCScriptToolStripMenuItem.Click += new System.EventHandler(this.DLCScriptToolStripMenuItem_Click);
            // 
            // dockPanel
            // 
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.DocumentStyle = WeifenLuo.WinFormsUI.Docking.DocumentStyle.DockingWindow;
            this.dockPanel.Location = new System.Drawing.Point(0, 55);
            this.dockPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.ShowDocumentIcon = true;
            this.dockPanel.Size = new System.Drawing.Size(1836, 797);
            this.dockPanel.TabIndex = 9;
            this.dockPanel.ActiveDocumentChanged += new System.EventHandler(this.dockPanel_ActiveDocumentChanged);
            // 
            // statusToolStrip
            // 
            this.statusToolStrip.BackColor = System.Drawing.SystemColors.HotTrack;
            this.statusToolStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.statusToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.statusToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLBL,
            this.toolStripProgressBar1,
            this.wkitVersionToolStripLabel,
            this.modNameToolStripLabel,
            this.toolStripSeparator11,
            this.toolStripDropDownButtonGit});
            this.statusToolStrip.Location = new System.Drawing.Point(0, 852);
            this.statusToolStrip.Name = "statusToolStrip";
            this.statusToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.statusToolStrip.Size = new System.Drawing.Size(1836, 28);
            this.statusToolStrip.TabIndex = 12;
            this.statusToolStrip.Text = "bottomTS";
            // 
            // statusLBL
            // 
            this.statusLBL.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.statusLBL.Name = "statusLBL";
            this.statusLBL.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.statusLBL.Size = new System.Drawing.Size(62, 25);
            this.statusLBL.Text = "Ready";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.toolStripProgressBar1.Size = new System.Drawing.Size(133, 25);
            // 
            // wkitVersionToolStripLabel
            // 
            this.wkitVersionToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.wkitVersionToolStripLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.wkitVersionToolStripLabel.Name = "wkitVersionToolStripLabel";
            this.wkitVersionToolStripLabel.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.wkitVersionToolStripLabel.Size = new System.Drawing.Size(91, 25);
            this.wkitVersionToolStripLabel.Text = "Build Date";
            // 
            // modNameToolStripLabel
            // 
            this.modNameToolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.modNameToolStripLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.modNameToolStripLabel.Name = "modNameToolStripLabel";
            this.modNameToolStripLabel.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.modNameToolStripLabel.Size = new System.Drawing.Size(96, 25);
            this.modNameToolStripLabel.Text = "Mod Name";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripDropDownButtonGit
            // 
            this.toolStripDropDownButtonGit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripDropDownButtonGit.AutoToolTip = false;
            this.toolStripDropDownButtonGit.BackColor = System.Drawing.Color.Transparent;
            this.toolStripDropDownButtonGit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupModProjectToolStripMenuItem,
            this.toolStripSeparator13,
            this.openBackupFolderToolStripMenuItem,
            this.commandPromptHereToolStripMenuItem});
            this.toolStripDropDownButtonGit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolStripDropDownButtonGit.Image = global::WolvenKit.Properties.Resources.git;
            this.toolStripDropDownButtonGit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonGit.Name = "toolStripDropDownButtonGit";
            this.toolStripDropDownButtonGit.Size = new System.Drawing.Size(176, 25);
            this.toolStripDropDownButtonGit.Text = "Backup Mod Project";
            // 
            // backupModProjectToolStripMenuItem
            // 
            this.backupModProjectToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.git;
            this.backupModProjectToolStripMenuItem.Name = "backupModProjectToolStripMenuItem";
            this.backupModProjectToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.backupModProjectToolStripMenuItem.Text = "Backup Now";
            this.backupModProjectToolStripMenuItem.ToolTipText = "Backup Mod Project";
            this.backupModProjectToolStripMenuItem.Click += new System.EventHandler(this.backupModProjectToolStripMenuItem_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(247, 6);
            // 
            // openBackupFolderToolStripMenuItem
            // 
            this.openBackupFolderToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.Open_16x;
            this.openBackupFolderToolStripMenuItem.Name = "openBackupFolderToolStripMenuItem";
            this.openBackupFolderToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.openBackupFolderToolStripMenuItem.Text = "Open Backup Folder";
            this.openBackupFolderToolStripMenuItem.Click += new System.EventHandler(this.openBackupFolderToolStripMenuItem_Click);
            // 
            // commandPromptHereToolStripMenuItem
            // 
            this.commandPromptHereToolStripMenuItem.Image = global::WolvenKit.Properties.Resources.Console_16x;
            this.commandPromptHereToolStripMenuItem.Name = "commandPromptHereToolStripMenuItem";
            this.commandPromptHereToolStripMenuItem.Size = new System.Drawing.Size(250, 26);
            this.commandPromptHereToolStripMenuItem.Text = "Command Prompt Here";
            this.commandPromptHereToolStripMenuItem.Click += new System.EventHandler(this.commandPromptHereToolStripMenuItem_Click);
            // 
            // richpresenceworker
            // 
            this.richpresenceworker.WorkerSupportsCancellation = true;
            this.richpresenceworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.richpresenceworker_DoWork);
            this.richpresenceworker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.richpresenceworker_ProgressChanged);
            this.richpresenceworker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.richpresenceworker_RunWorkerCompleted);
            // 
            // visualStudioToolStripExtender1
            // 
            this.visualStudioToolStripExtender1.DefaultRenderer = null;
            // 
            // visualStudioToolStripExtender2
            // 
            this.visualStudioToolStripExtender2.DefaultRenderer = null;
            // 
            // watcher
            // 
            this.watcher.EnableRaisingEvents = true;
            this.watcher.IncludeSubdirectories = true;
            this.watcher.NotifyFilter = ((System.IO.NotifyFilters)((((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName) 
            | System.IO.NotifyFilters.LastWrite) 
            | System.IO.NotifyFilters.LastAccess)));
            this.watcher.SynchronizingObject = this;
            this.watcher.Created += new System.IO.FileSystemEventHandler(this.Watcher_FileCreated);
            this.watcher.Deleted += new System.IO.FileSystemEventHandler(this.FileChanges_Detected);
            this.watcher.Renamed += new System.IO.RenamedEventHandler(this.FileRenames_Detected);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1836, 880);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolbarToolStrip);
            this.Controls.Add(this.statusToolStrip);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(767, 449);
            this.Name = "frmMain";
            this.Text = "WolvenKit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMain_MdiChildActivate);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.toolbarToolStrip.ResumeLayout(false);
            this.toolbarToolStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusToolStrip.ResumeLayout(false);
            this.statusToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.watcher)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolbarToolStrip;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newModToolStripMenuItem;
        private ToolStripMenuItem openModToolStripMenuItem;
        private ToolStripMenuItem modToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem modExplorerToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutRedkit2ToolStripMenuItem;
        private ToolStripMenuItem joinOurDiscordToolStripMenuItem;
        private ToolStripButton toolStripBtnNewMod;
        private ToolStripButton toolStripBtnOpenMod;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripBtnOpenFile;
        private ToolStripButton toolStripBtnSave;
        private ToolStripButton toolStripBtnSaveAll;
        private ToolStripButton toolStripBtnAssetbrowser;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripBtnPack;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem outputToolStripMenuItem;
        private ToolStripMenuItem tutorialsToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem reloadProjectToolStripMenuItem;
        private ToolStripMenuItem createPackedInstallerToolStripMenuItem;
        private ToolStripMenuItem witcherIIIModdingToolLicenseToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem newFileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAllToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripDropDownButton toolStripBtnRunGame;
        private ToolStripMenuItem launchWithCustomParametersToolStripMenuItem;
        private ToolStripMenuItem launchGameForDebuggingToolStripMenuItem;
        private ToolStripMenuItem addFileFromBundleToolStripMenuItem;
        private ToolStripMenuItem addFileFromOtherModToolStripMenuItem;
        private ToolStripMenuItem openFileToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem stringsEncoderGUIToolStripMenuItem;
        private ToolStripMenuItem menuCreatorToolStripMenuItem;
        private ToolStripMenuItem recordStepsToReproduceBugToolStripMenuItem;
        private ToolStripMenuItem reportABugToolStripMenuItem;
        private ToolStripMenuItem packageInstallerToolStripMenuItem;
        private ToolStrip statusToolStrip;
        private ToolStripLabel statusLBL;
        private ToolStripProgressBar toolStripProgressBar1;
        private ToolStripMenuItem packProjectToolStripMenuItem;
        private ToolStripMenuItem modToolStripMenuItem1;
        private ToolStripMenuItem ModscriptToolStripMenuItem;
        private ToolStripMenuItem ModchunkToolStripMenuItem;
        private ToolStripMenuItem dLCToolStripMenuItem;
        private ToolStripMenuItem DLCChunkToolStripMenuItem;
        private ToolStripMenuItem recentFilesToolStripMenuItem;
        private ToolStripMenuItem donateToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem modwwise;
        private ToolStripMenuItem dlcwwise;
        private BackgroundWorker richpresenceworker;
        private ToolStripMenuItem packProjectAndLaunchGameCustomToolStripMenuItem;
        private ToolStripMenuItem packProjectAndRunGameToolStripMenuItem;
        private ToolStripMenuItem exportCr2wToolStripMenuItem;
        private ToolStripMenuItem extractCollisioncacheToolStripMenuItem;
        private VisualStudioToolStripExtender visualStudioToolStripExtender1;
        private ToolStripMenuItem addFileToolStripMenuItem;
        private ToolStripMenuItem iconToolStripMenuItem;
        private ToolStripMenuItem minimizeToolStripMenuItem;
        private ToolStripMenuItem maximizeToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem experimentalToolStripMenuItem;
        private ToolStripMenuItem terrainViewerToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem consoleToolStripMenuItem;
        private ToolStripMenuItem scriptToolStripMenuItem;
        private ToolStripMenuItem w2rigjsonToolStripMenuItem;
        private ToolStripMenuItem w2animsjsonToolStripMenuItem;
        private ToolStripMenuItem importUtilityToolStripMenuItem;
        private DockPanel dockPanel;
        private ToolStripMenuItem DLCScriptToolStripMenuItem;
        private ToolStripMenuItem radishUtilitytoolStripMenuItem;
        private BackgroundWorker MainBackgroundWorker;
        private ToolStripSeparator toolStripSeparator10;
        private ToolStripButton toolStripBtnImportUtil;
        private ToolStripButton toolStripBtnRadishUtil;
        private VisualStudioToolStripExtender visualStudioToolStripExtender2;
        private ToolStripMenuItem bulkEditorToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem cR2WToTextToolStripMenuItem;
        private ToolStripMenuItem verifyFileToolStripMenuItem;
        private ToolStripMenuItem packAndInstallModToolStripMenuItem;
        private ToolStripMenuItem renderW2meshToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem GameDebuggerToolStripMenuItem;
        private ToolStripMenuItem saveExplorerToolStripMenuItem;
        private ToolStripMenuItem unbundleGameToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem openUncookedFolderToolStripMenuItem;
        private ToolStripMenuItem uncookGameToolStripMenuItem;
        private ToolStripMenuItem launchModkitToolStripMenuItem;
        private ToolStripLabel modNameToolStripLabel;
        private ToolStripLabel wkitVersionToolStripLabel;
        private System.IO.FileSystemWatcher watcher;
        private ToolStripMenuItem sceneViewerToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripDropDownButton toolStripDropDownButtonGit;
        private ToolStripMenuItem backupModProjectToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem openBackupFolderToolStripMenuItem;
        private ToolStripMenuItem commandPromptHereToolStripMenuItem;
        private ToolStripMenuItem backupModProjectToolStripMenuItem1;
        private ToolStripMenuItem backupToolStripMenuItem;
        private ToolStripMenuItem openBackupFolderToolStripMenuItem1;
        private ToolStripMenuItem commandPromptHereToolStripMenuItem1;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripButton toolStripButtonLexarMode;
        private ToolStripMenuItem dDStoTextureCacheToolStripMenuItem;
        private ToolStripMenuItem resetDocumentLayoutToolStripMenuItem;
        private ToolStripMenuItem openModFolderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripMenuItem openDlcFolderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator16;
    }
}
