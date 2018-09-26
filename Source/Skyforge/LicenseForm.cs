using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Skyforge
{
    public partial class LicenseForm : Form
    {
        public LicenseForm()
        {
            InitializeComponent();
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "Skyforge.EMB_LIC.txt";
            string embResult;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                embResult = reader.ReadToEnd();
            }
            try
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                byte[] rawData = webClient.DownloadData("https://raw.githubusercontent.com/Trioxinz/Skyforge/Master/LICENSE");

                string webData = System.Text.Encoding.UTF8.GetString(rawData);
                richTextBox1.Text = webData;
            }
            catch
            {
                try
                {
                    FileStream fileStreamIn = new FileStream("LICENSE", FileMode.Open, FileAccess.Read);
                    BinaryReader binaryReader = new BinaryReader(fileStreamIn);
                    long numBytes = new FileInfo("LICENSE").Length;
                    richTextBox1.Text = System.Text.Encoding.Default.GetString(binaryReader.ReadBytes((int)numBytes));
                    
                }
                catch
                {
                    richTextBox1.Text = embResult;
                }
            }
            
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void declineButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
