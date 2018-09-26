using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SkyforgeReforge
{
    // the update class
    public class Updater
    {
        private UpdateInterface applicationInfo;
        private BackgroundWorker backgroundWorker;

        public Updater(UpdateInterface applicationInfo)
        {
            this.applicationInfo = applicationInfo;

            this.backgroundWorker = new BackgroundWorker();
            this.backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }

        // initiates the update process
        public void DoUpDate()
        {
            if (!this.backgroundWorker.IsBusy)
            {
                this.backgroundWorker.RunWorkerAsync(this.applicationInfo);
            }
        }

        // checks to see if there's an update on server
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateInterface application = (UpdateInterface)e.Argument;

            if (!UpdateXML.ExistsOnServer(application.UpdateXMLLocation))
            {
                e.Cancel = true;
            }
            else
            {
                e.Result = UpdateXML.Parse(application.UpdateXMLLocation, application.ApplicationID);
            }
        }

        // a background worker check after the work is completed
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                UpdateXML update = (UpdateXML)e.Result;
                if (update != null && update.IsNewerThan(this.applicationInfo.ApplicationAssembly.GetName().Version))
                {
                    if (new UpdateAcceptForm(this.applicationInfo, update).ShowDialog(this.applicationInfo.Contex) == DialogResult.Yes)
                    {
                        this.DownloadUpdate(update);
                    }
                }
                else
                {
                    MessageBox.Show("There is no update at this time, you are already running the current version.", "Update Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // this will run the update process
        private void DownloadUpdate(UpdateXML update)
        {
            UpdateDownloadForm form = new UpdateDownloadForm(update.Uri, update.MD5, this.applicationInfo.ApplictionIcon);
            DialogResult result = form.ShowDialog(this.applicationInfo.Contex);

            if (result == DialogResult.OK)
            {
                string currentPath = this.applicationInfo.ApplicationAssembly.Location;
                string newPath = Path.GetDirectoryName(currentPath) + "\\" + update.FileName;

                UpdateApplication(form.TempFilePath, currentPath, newPath, update.LaunchArgs);

                Application.Exit();
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("The update download was canceled.\nThis program has not been modified.", "Update Download Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There was a problem downloading the update.\nPlease verify your Internet connection, then try your download later.", "Update Download Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateApplication(string tempFilePath, string currentPath, string newPath, string launchArgs)
        {

            // this is the arguments for the command prompt to delete rename and move the updated file to the newin current application position
            string argument = "/C Choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & Choice /C Y /N /D /Y /T 2 & Move /Y \"{1}\" \"{2}\" & Start \"\" /D \"{3}\" \"{4}\" {5}";
            ProcessStartInfo info = new ProcessStartInfo();
            info.Arguments = string.Format(argument, currentPath, tempFilePath, newPath, Path.GetDirectoryName(newPath), Path.GetFileName(newPath), launchArgs);
            info.WindowStyle = ProcessWindowStyle.Hidden;
            info.CreateNoWindow = true;
            info.FileName = "cmd.exe";
            Process.Start(info);
        }
    }
}
