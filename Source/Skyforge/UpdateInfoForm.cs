using System;
using System.Windows.Forms;

namespace SkyforgeReforge
{
    // form show details about the update
    internal partial class UpdateInfoForm : Form
    {
        // create a new update info form
        internal UpdateInfoForm(UpdateInterface applicationInfo, UpdateXML upadateInfo)
        {
            InitializeComponent();

            // sets the icon if it's not Nall
            if (applicationInfo.ApplictionIcon != null)
            {
                this.Icon = applicationInfo.ApplictionIcon;
            }

            // fills in the UI
            //this.Text = applicationInfo.ApplicationName + " Update Info"; // defualt text
            this.Text = "Update Info";
            this.labelVersions.Text = String.Format("Current Version: {0}\nUpdate Version: {1}", applicationInfo.ApplicationAssembly.GetName().Version.ToString(), upadateInfo.Version.ToString());
            this.textDescription.Text = upadateInfo.Description;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textDescription_KeyDown(object sender, KeyEventArgs e)
        {
            // blocks any keys but control seat copy text
            if (!(e.Control && e.KeyCode == Keys.C))
            {
                e.SuppressKeyPress = true;
            }
        }
    }
}
