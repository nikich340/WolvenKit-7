using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using WolvenKit.App;
using WolvenKit.App.ViewModels;
using WolvenKit.Common.Model;

namespace WolvenKit.Forms
{
    public partial class frmSettings : Form
    {
        private readonly SettingsViewModel viewModel;

        private string witcherexe = "";
        private string wccLiteexe = "";

        private const string wcc_sha256 = "fb20d7aa45b95446baac9b376533b06b86add732cbe40fd0620e4a4feffae47b";
        private const string wcc_sha256_patched = "275faa214c6263287deea47ddbcd7afcf6c2503a76ff57f2799bc158f5af7c5d";
        private const string wcc_sha256_patched2 = "104f50142fde883337d332d319d205701e8a302197360f5237e6bb426984212a";



        public frmSettings()
        {
            InitializeComponent();
            var config = MainController.Get().Configuration;




            textBoxGame.Text = config.ExecutablePath;
            textBoxWcc.Text = config.WccLite;

            SetDefaultModDir();
            SetDefaultDlcDir();

            txTextLanguage.Text = config.TextLanguage;
            txVoiceLanguage.Text = config.VoiceLanguage;


            checkBoxDisableWelcomeForm.Checked = config.IsWelcomeFormDisabled;
            checkBoxAutoInstall.Checked = !config.IsAutoInstallModsDisabled;

            comboBoxTheme.Items.AddRange(Enum.GetValues(typeof(EColorThemes)).Cast<object>().ToArray());
            comboBoxTheme.SelectedItem = UIController.Get().Configuration.ColorTheme;

            comboBoxUpdateChannel.Items.AddRange(Enum.GetValues(typeof(EUpdateChannel)).Cast<object>().ToArray());
            comboBoxUpdateChannel.SelectedItem = MainController.Get().Configuration.UpdateChannel;

            comboBoxExtension.Items.AddRange(Enum.GetValues(typeof(EUncookExtension)).Cast<object>().ToArray());
            comboBoxExtension.SelectedItem = MainController.Get().Configuration.UncookExtension;

            // automatically scan the registry for exe paths for wcc and tw3
            // if either text field is empty
            if (string.IsNullOrEmpty(textBoxGame.Text) || string.IsNullOrEmpty(textBoxWcc.Text))
            {
                exeSearcherSlave.RunWorkerAsync();
            }

            btSave.Enabled =
                (File.Exists(textBoxWcc.Text) && Path.GetExtension(textBoxWcc.Text) == ".exe" && textBoxWcc.Text.Contains("wcc_lite.exe")) &&
                (File.Exists(textBoxGame.Text) && Path.GetExtension(textBoxGame.Text) == ".exe" && textBoxGame.Text.Contains("witcher3.exe")) &&
                Directory.Exists(textBoxDepot.Text);

            Icon = UIController.GetThemedWkitIcon();

        }


        public event Action RequestApplyTheme;


        private void btSave_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBoxGame.Text))
            {
                DialogResult = DialogResult.None;
                textBoxGame.Focus();
                MessageBox.Show("Invalid witcher3.exe path", "failed to save.");
                return;
            }

            if (!File.Exists(textBoxWcc.Text))
            {
                DialogResult = DialogResult.None;
                textBoxWcc.Focus();
                MessageBox.Show("Invalid wcc_lite.exe path", "failed to save.");
                return;
            }

            MainController.Get().ProjectStatus = EProjectStatus.Busy;
            MainController.Get().StatusProgress = 0;

            // get configs
            var config = MainController.Get().Configuration;
            var uiconfig = UIController.Get().Configuration;

            // Apply Theme
            var applyTheme = uiconfig.ColorTheme != (EColorThemes)comboBoxTheme.SelectedItem;

            // save settings
            config.ExecutablePath = textBoxGame.Text;
            config.WccLite = textBoxWcc.Text;

            // double check that r4depot exists
            if (string.IsNullOrEmpty(config.DepotPath))
            {
                var wccDir = new FileInfo(textBoxWcc.Text).Directory.Parent.Parent;
                var wcc_r4data = Path.Combine(wccDir.FullName, "r4data");
                if (Directory.Exists(wcc_r4data))
                {
                    config.DepotPath = wcc_r4data;
                }
            }
            config.DepotPath = textBoxDepot.Text;
            config.GameModDir = textBoxModDir.Text;
            config.GameDlcDir = textBoxDlcDir.Text;

            config.TextLanguage = txTextLanguage.Text;
            config.VoiceLanguage = txVoiceLanguage.Text;
            config.UncookExtension = (EUncookExtension)comboBoxExtension.SelectedItem;
            config.IsWelcomeFormDisabled = checkBoxDisableWelcomeForm.Checked;
            config.IsAutoInstallModsDisabled = !checkBoxAutoInstall.Checked;

            uiconfig.ColorTheme = (EColorThemes)comboBoxTheme.SelectedItem;
            config.UpdateChannel = (EUpdateChannel)comboBoxUpdateChannel.SelectedItem;

            // save configs
            config.Save();
            uiconfig.Save();

            MainController.Get().UpdateWccHelper(config.WccLite);


            if (applyTheme)
            {
                MockKernel.Get().Window.GlobalApplyTheme();
                RequestApplyTheme?.Invoke();
            }

            // debug console enabling
            try
            {
                //TODO:UPDATE
                // IniParser ip = new IniParser(Path.Combine(MainController.Get().Configuration.GameRootDir, "bin\\config\\base\\general.ini"));
                // if (!ip.HasSection("General") || ip.GetSetting("General", "DBGConsoleOn", true) != "true")
                // {
                //     if (MessageBox.Show(
                //             "WolvenKit has detected that your game has the debug console disabled. It is a useful tool when testing mods. Would you like it to be enabled?",
                //             "Debug console enabling", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //     {
                //         ip.AddSetting("General", "DBGConsoleOn", "true");
                //         ip.Save();
                //     }
                // }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

            // patch wcc_lite
            try
            {
                using (var fs = new FileStream(textBoxWcc.Text, FileMode.Open))
                using (var bw = new BinaryWriter(fs))
                {
                    var shawcc = System.Security.Cryptography.SHA256.Create().ComputeHash(fs).Aggregate("", (c, n) => c += n.ToString("x2"));
                    switch (shawcc)
                    {
                        case wcc_sha256:
                        {
                            if (MessageBox.Show("wcc_lite is a great tool by CD Projekt red but" +
                                        "due to some internal problems they didn't really have time to properly develop it, and is very slow " +
                                        "because it is searching for a CD Projekt red mssql server.\n" +
                                        "WolvenKit can patch this with a method figured out by blobbins on the witcher 3 forums." +
                                        "Would you like to perform this patch?", "wcc_lite faster patch", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                                DialogResult.Yes)
                            {
                                //We perform the patch
                                bw.BaseStream.Seek(0x00713CD0, SeekOrigin.Begin);
                                bw.Write(new byte[0xDD].Select(x => x = 0x90).ToArray());

                                //Recompute hash
                                fs.Seek(0, SeekOrigin.Begin);
                                shawcc = System.Security.Cryptography.SHA256.Create().ComputeHash(fs).Aggregate("", (c, n) => c += n.ToString("x2"));
                                if (shawcc == wcc_sha256_patched)
                                {
                                    MessageBox.Show("Succesfully patched!", "Patch completed", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Failed to patch! Please reinstall wcc_lite and try again",
                                        "Patch completed", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                }
                            }



                            break;
                        }
                        case wcc_sha256_patched2:
                        case wcc_sha256_patched:
                        {
                            //Do nothing we are cool.
                            break;
                        }
                        default:
                        {
                            DialogResult = DialogResult.None;
                            textBoxGame.Focus();
                            MessageBox.Show("Invalid wcc_lite.exe path you seem to have on older version",
                                "failed to save.");
                            return;
                        }
                    }

                }
            }
            catch (UnauthorizedAccessException)
            {
                //wcc_lite is installed to C:\\Program files
                MessageBox.Show("Please restart WolvenKit as administrator. Couldn't access " + textBoxWcc.Text,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Exit with error code 0 so we don't raise a windows error and the user can restart it so we have access to the files.
                Environment.Exit(0);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

            MainController.Get().StatusProgress = 100;
            MainController.Get().ProjectStatus = EProjectStatus.Ready;
            DialogResult = DialogResult.OK;
        }

        private void btnBrowseExe_Click(object sender, EventArgs e)
        {
            var dlg = new System.Windows.Forms.OpenFileDialog
            {
                Title = "Select Witcher 3 Executable.",
                FileName = textBoxGame.Text,
                Filter = "witcher3.exe|witcher3.exe"
            };
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                textBoxGame.Text = dlg.FileName;
            }
        }

        private void btBrowseWCC_Lite_Click(object sender, EventArgs e)
        {
            var dlg = new System.Windows.Forms.OpenFileDialog
            {
                Title = "Select wcc_lite.exe.",
                FileName = textBoxGame.Text,
                Filter = "wcc_lite.exe|wcc_lite.exe"
            };
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                textBoxWcc.Text = dlg.FileName;
            }
        }

        private void btBrowseDepot_Click(object sender, EventArgs e)
        {
            var dlg = new CommonOpenFileDialog
            {
                InitialDirectory = "C:\\Users",
                IsFolderPicker = true
            };
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBoxDepot.Text = dlg.FileName;
            }
        }

        #region Events
        private void exeSearcherSlave_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            const string uninstallkey = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\";
            const string uninstallkey2 = "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\";
            var w3 = "";
            var wcc = "";
            try
            {
                Parallel.ForEach(Registry.LocalMachine.OpenSubKey(uninstallkey)?.GetSubKeyNames(), item =>
                {
                    var programName = Registry.LocalMachine.OpenSubKey(uninstallkey + item)
                        ?.GetValue("DisplayName");
                    var installLocation = Registry.LocalMachine.OpenSubKey(uninstallkey + item)
                        ?.GetValue("InstallLocation");
                    if (programName != null && installLocation != null)
                    {
                        if (programName.ToString().Contains("Witcher 3 Mod Tools"))
                        {
                            var str = installLocation.ToString();
                            if (Directory.Exists(str))
                            {
                                wcc = Directory.GetFiles(str, "wcc_lite.exe",
                                    SearchOption.AllDirectories).FirstOrDefault();
                            }
                        }

                        if (programName.ToString().Contains("The Witcher 3 - Wild Hunt") ||
                            programName.ToString().Contains("The Witcher 3: Wild Hunt"))
                        {
                            var str = installLocation.ToString();
                            if (Directory.Exists(str))
                            {
                                w3 = Directory.GetFiles(str, "witcher3.exe",
                                    SearchOption.AllDirectories).FirstOrDefault();
                            }
                        }
                    }

                    exeSearcherSlave.ReportProgress(0, new Tuple<string, string, int, int>(w3, wcc, 0, 0));
                });
                Parallel.ForEach(Registry.LocalMachine.OpenSubKey(uninstallkey2)?.GetSubKeyNames(), item =>
                {
                    var programName = Registry.LocalMachine.OpenSubKey(uninstallkey2 + item)
                        ?.GetValue("DisplayName");
                    var installLocation = Registry.LocalMachine.OpenSubKey(uninstallkey2 + item)
                        ?.GetValue("InstallLocation");
                    if (programName != null && installLocation != null)
                    {
                        if (programName.ToString().Contains("Witcher 3 Mod Tools"))
                        {
                            if (Directory.Exists(installLocation.ToString()))
                            {
                                wcc = Directory.GetFiles(installLocation.ToString(), "wcc_lite.exe",
                                    SearchOption.AllDirectories).FirstOrDefault();
                            }
                        }

                        if (programName.ToString().Contains("The Witcher 3 - Wild Hunt") ||
                            programName.ToString().Contains("The Witcher 3: Wild Hunt"))
                        {
                            if (Directory.Exists(installLocation.ToString()))
                            {
                                w3 = Directory.GetFiles(installLocation.ToString(), "witcher3.exe",
                                SearchOption.AllDirectories).FirstOrDefault();
                            }
                        }
                    }

                    exeSearcherSlave.ReportProgress(0, new Tuple<string, string, int, int>(w3, wcc, 0, 0));
                });
            }
            catch (Exception ex)
            {
                System.Console.Error.WriteLine(ex.ToString());
            }
        }

        private void exeSearcherSlave_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (File.Exists(witcherexe))
            {
                textBoxGame.Text = witcherexe;
            }

            if (File.Exists(wccLiteexe))
            {
                textBoxWcc.Text = wccLiteexe;
            }


            // get the depot path
            // if depot path is empty, get the r4data from wcc_lite
            var config = MainController.Get().Configuration;
            if (string.IsNullOrEmpty(config.DepotPath) || !Directory.Exists(config.DepotPath))
            {
                if (File.Exists(wccLiteexe) && Path.GetExtension(wccLiteexe) == ".exe" && wccLiteexe.Contains("wcc_lite.exe"))
                {
                    var directoryInfo = new FileInfo(wccLiteexe).Directory;
                    var wccDir = directoryInfo?.Parent?.Parent;
                    if (wccDir != null)
                    {
                        var wccR4data = Path.Combine(wccDir.FullName, "r4data");
                        if (Directory.Exists(wccR4data))
                        {
                            config.DepotPath = wccR4data;
                        }
                    }
                }
            }
            textBoxDepot.Text = config.DepotPath;

            // if custom mod folder is empty or incorrect in the configuration, get the game mod dir and dlc dir
            SetDefaultModDir();
            SetDefaultDlcDir();

        }

        private void SetDefaultModDir()
        {
            var config = MainController.Get().Configuration;
            var executablePath = config.ExecutablePath;
            if (string.IsNullOrEmpty(executablePath))
            {
                executablePath = witcherexe;
            }

            if (string.IsNullOrEmpty(config.GameModDir) || !Directory.Exists(config.GameModDir))
            {
                if (File.Exists(executablePath) && Path.GetExtension(executablePath) == ".exe" && executablePath.Contains("witcher3.exe"))
                {
                    var tw3ExeDirectory = new FileInfo(executablePath).Directory;
                    var tw3Directory = tw3ExeDirectory?.Parent?.Parent;
                    if (tw3Directory != null)
                    {
                        var gamemoddir = Path.Combine(tw3Directory.FullName, "Mods");
                        if (Directory.Exists(gamemoddir))
                        {
                            config.GameModDir = gamemoddir;
                        }
                        else
                        {
                            Directory.CreateDirectory(gamemoddir);
                            config.GameModDir = gamemoddir;
                        }
                    }
                }
            }
            textBoxModDir.Text = config.GameModDir;
        }

        private void SetDefaultDlcDir()
        {
            var config = MainController.Get().Configuration;
            var executablePath = config.ExecutablePath;
            if (string.IsNullOrEmpty(executablePath))
            {
                executablePath = witcherexe;
            }

            if (string.IsNullOrEmpty(config.GameDlcDir) || !Directory.Exists(config.GameDlcDir))
            {
                if (File.Exists(executablePath) && Path.GetExtension(executablePath) == ".exe" && executablePath.Contains("witcher3.exe"))
                {
                    var tw3ExeDirectory = new FileInfo(executablePath).Directory;
                    var tw3Directory = tw3ExeDirectory?.Parent?.Parent;
                    if (tw3Directory != null)
                    {
                        var gamedlcdir = Path.Combine(tw3Directory.FullName, "DLC");
                        if (Directory.Exists(gamedlcdir))
                        {
                            config.GameDlcDir = gamedlcdir;
                        }
                    }
                }
            }
            textBoxDlcDir.Text = config.GameDlcDir;
        }

        private void exeSearcherSlave_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var report = (e.UserState as Tuple<string, string, int, int>);
            witcherexe = report?.Item1;
            wccLiteexe = report?.Item2;

        }

        private void txWCC_Lite_TextChanged(object sender, EventArgs e)
        {
            var path = textBoxWcc.Text;
            if (File.Exists(path) && Path.GetExtension(path) == ".exe" && path.Contains("wcc_lite.exe"))
            {
                WCCexeTickLBL.Text = "✓";
                WCCexeTickLBL.ForeColor = Color.Green;
            }
            else
            {
                WCCexeTickLBL.Text = "X";
                WCCexeTickLBL.ForeColor = Color.Red;
            }
            btSave.Enabled =
                (File.Exists(textBoxWcc.Text) && Path.GetExtension(textBoxWcc.Text) == ".exe" && textBoxWcc.Text.Contains("wcc_lite.exe")) &&
                (File.Exists(textBoxGame.Text) && Path.GetExtension(textBoxGame.Text) == ".exe" && textBoxGame.Text.Contains("witcher3.exe"));


            // get the depot path
            var config = MainController.Get().Configuration;
            if (File.Exists(textBoxWcc.Text) && Path.GetExtension(textBoxWcc.Text) == ".exe" && textBoxWcc.Text.Contains("wcc_lite.exe"))
            {
                var wccDir = new FileInfo(textBoxWcc.Text).Directory.Parent.Parent;
                var wcc_r4data = Path.Combine(wccDir.FullName, "r4data");
                if (Directory.Exists(wcc_r4data))
                {
                    config.DepotPath = wcc_r4data;
                }
            }
            textBoxDepot.Text = config.DepotPath;

        }

        private void txExecutablePath_TextChanged(object sender, EventArgs e)
        {
            var path = textBoxGame.Text;
            if (File.Exists(path) && Path.GetExtension(path) == ".exe" && path.Contains("witcher3.exe"))
            {
                W3exeTickLBL.Text = "✓";
                W3exeTickLBL.ForeColor = Color.Green;
            }
            else
            {
                W3exeTickLBL.Text = "X";
                W3exeTickLBL.ForeColor = Color.Red;
            }
            btSave.Enabled =
                (File.Exists(textBoxWcc.Text) && Path.GetExtension(textBoxWcc.Text) == ".exe" && textBoxWcc.Text.Contains("wcc_lite.exe")) &&
                (File.Exists(textBoxGame.Text) && Path.GetExtension(textBoxGame.Text) == ".exe" && textBoxGame.Text.Contains("witcher3.exe"));
        }
        #endregion

        private void buttonBrowseModDir_Click(object sender, EventArgs e)
        {
            var dlg = new CommonOpenFileDialog
            {
                InitialDirectory = textBoxModDir.Text,
                IsFolderPicker = true
            };
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBoxModDir.Text = dlg.FileName;
            }
        }

        private void buttonBrowseDlcDir_Click(object sender, EventArgs e)
        {
            var dlg = new CommonOpenFileDialog
            {
                InitialDirectory = textBoxDlcDir.Text,
                IsFolderPicker = true
            };
            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBoxDlcDir.Text = dlg.FileName;
            }
        }


    }
}
