using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace SkyforgeReforge
{
    // form that download the update
    internal partial class UpdateDownloadForm : Form
    {

        // Web client to download the update
        private WebClient webClient;

        // the thread to hash the file
        private BackgroundWorker backgroundWorker;

        // a temporary file name to download to
        private string temporaryFile;

        // the md5 hash of the file to download
        private string md5;

        // the sha512 hash of the file to download
        private string sha512;

        // gets the temporary file path for the downloaded file
        internal string TempFilePath
        {
            get { return this.temporaryFile; }
        }

        // creates a new UpdateDownload form
        internal UpdateDownloadForm(Uri location, string md5, string sha512, Icon programIcon)
        {
            InitializeComponent();

            if (programIcon != null)
            {
                this.Icon = programIcon;
            }

            // set the temporary file name and creates a new zero byte file on the local computer
            temporaryFile = Path.GetTempFileName();

            this.md5 = md5;
            this.sha512 = sha512;

            // creates the events for the web client
            webClient = new WebClient();
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
            

            // creates the events for the background worker
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);


            // tries to download the file
            try
            {
                webClient.DownloadFileAsync(location, this.temporaryFile);
            }
            catch
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
        }

        // updates the progress of the download
        private void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
            this.labelProgress.Text = String.Format("Downloaded {0} of {1}",FormatBytes(e.BytesReceived, 2, true), FormatBytes(e.TotalBytesToReceive, 2, true));
        }


        // formats the bites into kilobytes, megabytes, or gigabytes
        private string FormatBytes(long bytes, int decimalPlaces, bool showByteType)
        {
            double newBytes = bytes;
            string formatString = "{0";
            string byteType = "B";

            if (newBytes > 1024 && newBytes < 1048576)
            {
                newBytes /= 1024;
                byteType = "KB";
            }
            else if (newBytes > 1048576 && newBytes < 1073741824)
            {
                newBytes /= 1048576;
                byteType = "MB";
            }
            else
            {
                newBytes /= 1073741824;
                byteType = "GB";
            }

            if (decimalPlaces > 0)
            {
                formatString += ":0.";
            }

            for (int i = 0; i < decimalPlaces; i++)
            {
                formatString += "0";
            }

            formatString += "}";

            if (showByteType)
            {
                formatString += byteType;
            }

            return string.Format(formatString, newBytes);
        }

        // updates of form when the file was fully downloaded then checks it with the background worker
        private void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            else if (e.Cancelled)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            else
            {
                labelProgress.Text = "Verifying download...";
                progressBar.Style = ProgressBarStyle.Marquee;

                backgroundWorker.RunWorkerAsync(new string[] { this.temporaryFile, this.md5, this.sha512 });
            }
        }


        // checks the MD5 and SHA512 hash sums of the download a file against the update file on the server
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string file = ((string[])e.Argument)[0];
            string updateMD5 = ((string[])e.Argument)[1];
            string updateSHA512 = ((string[])e.Argument)[2];

            if ((Hasher.HaseFile(file, HashType.MD5) != updateMD5) && (Hasher.HaseFile(file, HashType.SHA512) != updateSHA512))
            {
                e.Result = DialogResult.No;
            }
            else
            {
                e.Result = DialogResult.OK;
            }
        }


        // updates the form when the hash check completes
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = (DialogResult)e.Result;
            this.Close();
        }


        // checks to see if the download was closed abruptly by the user, if so closes all processes in the form
        private void UpdateDownloadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (webClient.IsBusy)
            {
                webClient.CancelAsync();
                this.DialogResult = DialogResult.Abort;
            }

            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
