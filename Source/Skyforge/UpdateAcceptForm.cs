using System;
using System.Windows.Forms;

namespace SkyforgeReforge
{
    // prompts the user to accept the update
    internal partial class UpdateAcceptForm : Form
    {
        // pulls the interface class to create the application info
        private UpdateInterface applicationInfo;

        // pulls the update information from the server
        private UpdateXML updateInfo;

        // set up a constructor to create a new update information form
        private UpdateInfoForm updateInfoForm;

        // creates a new instance of the update acceptance form
        internal UpdateAcceptForm(UpdateInterface applicationInfo, UpdateXML updateInfo)
        {
            InitializeComponent();

            this.applicationInfo = applicationInfo;
            this.updateInfo = updateInfo;

            //this.Text = this.applicationInfo.ApplicationName + " Update Available"; // defualt text
            this.Text =  "Update Available";

            // set this Windows icon if available
            if (this.applicationInfo.ApplictionIcon != null)
            {
                this.Icon = this.applicationInfo.ApplictionIcon;
            }

            // adds the update version number to the form
            this.labelUpdateVersionAvailable.Text = string.Format("New Version: {0}", this.updateInfo.Version.ToString());
        }

        private void buttonYes_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void buttonDetails_Click(object sender, EventArgs e)
        {
            if (this.updateInfoForm == null)
            {
                this.updateInfoForm = new UpdateInfoForm(this.applicationInfo, this.updateInfo);
            }

            this.updateInfoForm.ShowDialog(this);
        }
    }
}
