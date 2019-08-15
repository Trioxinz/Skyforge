using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using SkyforgeReforge;

namespace Skyforge
{
    public partial class MainForm : Form, UpdateInterface
    {
        #region Important variables and information
        private static string applicationName = "Skyforge";
        private static string applicationID = applicationName;
        private string[] args;
        private byte[] programData;
        private bool isNewInput;
        private bool skipFileCheck;
        private Updater update;
        private TextBoxOutputter outputter;

        public string ApplicationName
        {
            get
            {
                return applicationName + isBeta();
            }
        }

        public string ApplicationID
        {
            get
            {
                return applicationID + isBeta();
            }
        }

        public Assembly ApplicationAssembly
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }

        public Icon ApplictionIcon
        {
            get
            {
                return this.Icon;
            }
        }

        public Uri UpdateXMLLocation
        {
            get
            {
                if (readSFDATA(1, 0x01))
                {
                    return new Uri("https://raw.githubusercontent.com/Trioxinz/Skyforge/Development/Update/update.xml");
                }
                else
                {
                    return new Uri("https://raw.githubusercontent.com/Trioxinz/Skyforge/Master/Update/update.xml");
                }
            }
        }

        public Form Contex
        {
            get
            {
                return this;
            }
        }

        private string isBeta()
        {
#if DEBUG
            return "Dev";
#else
            return "";
#endif
        }

        private Boolean readSFDATA(int byteToCheck, byte byteToCheckFor)
        {
            if (programData == null)
            {
                if (File.Exists("SFDATA.dat"))
                {
                        FileStream fileStreamIn = new FileStream("SFDATA.dat",FileMode.Open,FileAccess.Read);
                        BinaryReader binaryReader = new BinaryReader(fileStreamIn);
                        long numBytes = new FileInfo("SFDATA.dat").Length;
                        programData = binaryReader.ReadBytes((int)numBytes);
                        fileStreamIn.Close();
                }
                else
                {
                    programData = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
                    try
                    {
                        writeSFDATA();
                        
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Local folder access failed, please ensure that Skyforge is in a folder with proper permissions to run", "File Access Denied Error", MessageBoxButtons.OK);
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }
            if (programData[byteToCheck] == byteToCheckFor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void writeSFDATA()
        {
            try
            {
                using (var outStream = new FileStream("SFDATA.dat", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    outStream.Write(programData, 0, programData.Length);
                }
                //File.SetAttributes("SF.dat", File.GetAttributes("SF.dat") | FileAttributes.Hidden);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
            }
        }

        public MainForm(string[] args)
        {
            this.args = args;
            InitializeComponent();
            
        }
        #endregion

        #region Form loading methods
        private void MainForm_Load(object sender, EventArgs e)
        {
            bool loaded = readSFDATA(0, 0x00);
            writeSFDATA();
            loaded = true;
            isNewInput = false;
            outputter = new TextBoxOutputter(terminalTextBox);
            Console.SetOut(outputter);
            Console.WriteLine("Skyforge" + isBeta() + " v" + this.ApplicationAssembly.GetName().Version.ToString() + " Loaded");
            if(!readSFDATA(0, 0xe2))
            {
                Console.WriteLine("Please read and accept the LICENSE....");
                Console.WriteLine("This can found under Help->LICENSE");
                selectFolderButton.Enabled = false;
                folderTextBox.Enabled = false;
                fileListView.Enabled = false;
                fileCheckSkipCheckBox.Enabled = false;
            }
        }


        void TimerTick(object state)
        {
            if (isNewInput)
            {
                var who = state as string;
                Console.WriteLine(who);
            }
        }

        private void timer1_Tick(object state, EventArgs e)
        {
            TimerTick(state);
        }


        private void timer2_Tick(object state, EventArgs e)
        {
            TimerTick(state);
        }
        #endregion

        #region Menu items
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void checkForUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            update = new Updater(this);
            update.DoUpDate();
        }

        private void sitchUpdatechannelStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateChannelForm updateChannel = new UpdateChannelForm(readSFDATA(1, 0x01));
            DialogResult dialogResultBeta = updateChannel.ShowDialog();
            if (dialogResultBeta == DialogResult.OK)
            {
                if (programData[1] == 0x00)
                {
                    programData[1] = 0x01;
                    writeSFDATA();
                    Console.WriteLine("Update Channel set to development branch...");
                }
            }
            else if(dialogResultBeta == DialogResult.Cancel)
            {
                if (programData[1] == 0x01)
                {
                    programData[1] = 0x00;
                    writeSFDATA();
                    Console.WriteLine("Update Channel set to stable branch...");
                }
            }
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LicenseForm license = new LicenseForm();
            DialogResult dialogResultBeta = license.ShowDialog();
            if (dialogResultBeta == DialogResult.OK)
            {
                if (programData[0] == 0x00)
                {
                    programData[0] = 0xe2;
                    writeSFDATA();
                    Console.WriteLine("LICENSE accepted...");
                    selectFolderButton.Enabled = true;
                    folderTextBox.Enabled = true;
                    fileListView.Enabled = true;
                    fileCheckSkipCheckBox.Enabled = true;
                }
            }
            else if (dialogResultBeta == DialogResult.Cancel)
            {
                if (programData[0] == 0xe2)
                {
                    programData[0] = 0x00;
                    writeSFDATA();
                    Console.WriteLine("LICENSE rejected...");
                    selectFolderButton.Enabled = false;
                    folderTextBox.Enabled = false;
                    fileListView.Enabled = false;
                    fileCheckSkipCheckBox.Enabled = false;
                    folderTextBox.Text = "Please select a folder containing the mod files to work with";
                }
            }
        }

        private void aboutSkyforgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox(this);
            about.ShowDialog();
        }
        #endregion

        #region Main form logic
        private void selectFolderButton_Click(object sender, EventArgs e)
        {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    folderTextBox.Text = folderBrowserDialog1.SelectedPath;
                    Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;
                }
        }

        private void fileCheckSkipCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            skipFileCheck = fileCheckSkipCheckBox.Checked;
            refreshFileList();
        }

        private void folderTextBox_TextChanged(object sender, EventArgs e)
        {
            refreshFileList();
        }

        private void refreshFileList()
        {
            fileListView.Items.Clear();
            try
            {
                string[] files = Directory.GetFiles(folderTextBox.Text);
                string[] folders = Directory.GetDirectories(folderTextBox.Text);
                foreach (string folder in folders)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = "\\" + Path.GetFileName(folder);
                    fileListView.Items.Add(item);
                }
                foreach (string file in files)
                {
                    string fileExt = Path.GetExtension(file);
                    if (skipFileCheck)
                    {
                        string fileName = Path.GetFileName(file);
                        ListViewItem item = new ListViewItem(fileName);
                        item.Tag = file;
                        fileListView.Items.Add(item);
                    }
                    else
                    {
                        if ((fileExt == ".bsa") || (fileExt == ".esm") || (fileExt == ".esp") || (fileExt == ".pex") || (fileExt == ".dds") || (fileExt == ".lod") || (fileExt == ".strings") || (fileExt == ".dlstrings") || (fileExt == ".ilstrings") || (fileExt == ".nif") || (fileExt == ".hkx") || (fileExt == ".fuz") || (fileExt == ".mcadpcm"))
                        {
                            string fileName = Path.GetFileName(file);
                            ListViewItem item = new ListViewItem(fileName);
                            item.Tag = file;
                            fileListView.Items.Add(item);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (IOException)
            {
            }

            if (fileListView.Items.Count > 0)
            {
                convertModButton.Enabled = true;
                convertOnlyButton.Enabled = true;
                packModButton.Enabled = true;
                repackModButton.Enabled = true;
                unpackModButton.Enabled = true;
                loadOrderButton.Enabled = true;
            }
            else
            {
                convertModButton.Enabled = false;
                convertOnlyButton.Enabled = false;
                packModButton.Enabled = false;
                repackModButton.Enabled = false;
                unpackModButton.Enabled = false;
                loadOrderButton.Enabled = false;
            }
        }

        private void convertModButton_Click(object sender, EventArgs e)
        {
            startAction("CONVERT_MOD.BAT");
        }

        private void convertOnlyButton_Click(object sender, EventArgs e)
        {
            startAction("CONVERT_ONLY.BAT");
        }

        private void packModButton_Click(object sender, EventArgs e)
        {
            startAction("PACK_MOD.BAT");
        }

        private void unpackModButton_Click(object sender, EventArgs e)
        {
            startAction("UNPACK_MOD.BAT");
        }

        private void repackModButton_Click(object sender, EventArgs e)
        {
            startAction("REPACK_MOD.BAT");
        }

        private void loadOrderButton_Click(object sender, EventArgs e)
        {
            startAction("LOAD_ORDER.BAT");
        }
        #endregion

        #region Toolkit backend logic
        private void startAction(string batchFile)
        {
            convertModButton.Enabled = false;
            convertOnlyButton.Enabled = false;
            packModButton.Enabled = false;
            repackModButton.Enabled = false;
            unpackModButton.Enabled = false;
            loadOrderButton.Enabled = false;
            selectFolderButton.Enabled = false;
            folderTextBox.Enabled = false;
            fileListView.Enabled = false;
            fileCheckSkipCheckBox.Enabled = false;
            try
            {
                using (Process proc = new Process())
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo(Environment.CurrentDirectory + "\\Skyrim-NX-Toolkit\\" + batchFile);
                    startInfo.Arguments = "\"" + folderTextBox.Text + "\"";
                    startInfo.WorkingDirectory = Environment.CurrentDirectory + "\\Skyrim-NX-Toolkit\\";
                    startInfo.RedirectStandardOutput = true;
                    startInfo.RedirectStandardError = true;
                    startInfo.UseShellExecute = false;
                    startInfo.CreateNoWindow = true;
                    proc.EnableRaisingEvents = true;
                    proc.StartInfo = startInfo;
                    proc.Start();
                    proc.BeginOutputReadLine();
                    proc.OutputDataReceived += p_OutputDataReceived;
                    proc.ErrorDataReceived += p_ErrorDataReceived;
                    proc.Exited += p_ProcessExited;
                }
            }
            catch (Exception ex)
            {
                convertModButton.Enabled = true;
                convertOnlyButton.Enabled = true;
                packModButton.Enabled = true;
                repackModButton.Enabled = true;
                unpackModButton.Enabled = true;
                loadOrderButton.Enabled = true;
                selectFolderButton.Enabled = true;
                folderTextBox.Enabled = true;
                fileListView.Enabled = true;
                fileCheckSkipCheckBox.Enabled = true;
                Console.WriteLine(ex);
            }
        }
        void ProcessExited()
        {
            convertModButton.Enabled = true;
            convertOnlyButton.Enabled = true;
            packModButton.Enabled = true;
            repackModButton.Enabled = true;
            unpackModButton.Enabled = true;
            loadOrderButton.Enabled = true;
            selectFolderButton.Enabled = true;
            folderTextBox.Enabled = true;
            fileListView.Enabled = true;
            fileCheckSkipCheckBox.Enabled = true;
            Console.WriteLine("Completed task...");
        }

        static void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Process p = sender as Process;
            if (p == null)
                return;
            Console.WriteLine(e.Data);
        }

        static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Process p = sender as Process;
            if (p == null)
                return;
            if (!(e.Data == null))
            {
                if (!(e.Data.Contains("=Done=")))
                {
                    Console.WriteLine(e.Data);
                }
                else
                {
                    Skyforge.MainForm form = new MainForm(null);
                    form.ProcessExited();
                } 
            }
        }

        internal void p_ProcessExited(object sender, System.EventArgs e)
        {
            convertModButton.Enabled = true;
            convertOnlyButton.Enabled = true;
            packModButton.Enabled = true;
            repackModButton.Enabled = true;
            unpackModButton.Enabled = true;
            loadOrderButton.Enabled = true;
            selectFolderButton.Enabled = true;
            folderTextBox.Enabled = true;
            fileListView.Enabled = true;
            fileCheckSkipCheckBox.Enabled = true;
            Console.WriteLine("Completed task...");
        }
        #endregion
    }
}