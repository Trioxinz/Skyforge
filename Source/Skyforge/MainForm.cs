using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using UpdateDLL;

namespace Skyforge
{
    public partial class MainForm : Form, UpdateInterface
    {
        #region Important variables and information
        private static string applicationName = "Skyforge";
        private static string applicationID = applicationName;
        private string[] args;
        private byte[] programData;// Should be 7 bytes
        

        private Updater update;
        private TextBoxOutputter outputter;
        private Boolean isNewInput;

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
                return applicationID;
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
                if (readSFDATA(1))
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
            if(readSFDATA(1))
            {
                return "Beta";
            }
            else
            {
                return "";
            }
        }

        private Boolean readSFDATA(int byteToCheck)
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
                    programData = new byte[] { 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30 };
                    try
                    {
                        FileStream outStream = new FileStream("SFDATA.dat", FileMode.OpenOrCreate, FileAccess.Write);
                        outStream.Write(programData, 0, programData.Length);
                        outStream.Close();
                        //File.SetAttributes("SF.dat", File.GetAttributes("SF.dat") | FileAttributes.Hidden);
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show("Local folder access failed, please ensure that Skyforge is in a folder with proper permissions to run", "File Access Denied Error", MessageBoxButtons.OK);
                        System.Windows.Forms.Application.Exit();
                    }
                }
            }
            if (programData[byteToCheck] == 0x31)
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
                FileStream outStream = new FileStream("SFDATA.dat", FileMode.OpenOrCreate, FileAccess.Write);
                outStream.Write(programData, 0, programData.Length);
                outStream.Close();
            }
            catch
            {
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
            isNewInput = false;
            outputter = new TextBoxOutputter(terminalTextBox);
            Console.SetOut(outputter);
            Console.WriteLine("Skyforged v" + this.ApplicationAssembly.GetName().Version.ToString() + " Loaded");
            if(!readSFDATA(0))
            {
                Console.WriteLine("Please read and accept the LICENSE....");
                Console.WriteLine("This can found under Help->LICENSE");
                selectFolderButton.Enabled = false;
                folderTextBox.Enabled = false;
                fileListView.Enabled = false;
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
            UpdateChannelForm updateChannel = new UpdateChannelForm(readSFDATA(1));
            DialogResult dialogResultBeta = updateChannel.ShowDialog();
            if (dialogResultBeta == DialogResult.OK)
            {
                if (programData[1] == 0x30)
                {
                    programData[1] = 0x31;
                    writeSFDATA();
                    Console.WriteLine("Update Channel set to development branch...");
                }
            }
            else if(dialogResultBeta == DialogResult.Cancel)
            {
                if (programData[1] == 0x31)
                {
                    programData[1] = 0x30;
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
                if (programData[0] == 0x30)
                {
                    programData[0] = 0x31;
                    writeSFDATA();
                    Console.WriteLine("LICENSE accepted...");
                    selectFolderButton.Enabled = true;
                    folderTextBox.Enabled = true;
                    fileListView.Enabled = true;
                }
            }
            else if (dialogResultBeta == DialogResult.Cancel)
            {
                if (programData[0] == 0x31)
                {
                    programData[0] = 0x30;
                    writeSFDATA();
                    Console.WriteLine("LICENSE rejected...");
                    selectFolderButton.Enabled = false;
                    folderTextBox.Enabled = false;
                    fileListView.Enabled = false;
                }
            }
        }

        private void aboutSkyforgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
        #endregion

        private void startAction(string batchFile, string folderArg)
        {
            var processStartInfo = new ProcessStartInfo(batchFile, folderArg);

            processStartInfo.UseShellExecute = false;
            processStartInfo.ErrorDialog = false;

            processStartInfo.RedirectStandardError = true;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;

            Process process = new Process();
            process.StartInfo = processStartInfo;
            bool processStarted = process.Start();

            StreamWriter inputWriter = process.StandardInput;
            StreamReader outputReader = process.StandardOutput;
            StreamReader errorReader = process.StandardError;
            process.WaitForExit();
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    folderTextBox.Text = folderBrowserDialog1.SelectedPath;
                    Environment.SpecialFolder root = folderBrowserDialog1.RootFolder;
                }
        }

        private void folderTextBox_TextChanged(object sender, EventArgs e)
        {
            fileListView.Items.Clear();
            try
            {
                string[] files = Directory.GetFiles(folderTextBox.Text);
                foreach (string file in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(file);
                    ListViewItem item = new ListViewItem(fileName);
                    item.Tag = file;
                    fileListView.Items.Add(item);
                }
            }
            catch (FileNotFoundException)
            {
            }
            catch (IOException)
            {
            }
        }
    }
}