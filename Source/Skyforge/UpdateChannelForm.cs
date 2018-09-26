using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skyforge
{
    public partial class UpdateChannelForm : Form
    {
        bool isBeta;
        public UpdateChannelForm(bool SFDATA1)
        {
            isBeta = SFDATA1;
            InitializeComponent();
        }

        private void UpdateChannelForm_Load(object sender, EventArgs e)
        {
            if(isBeta)
            {
                channelTextBox.Text = "Development";
            }
            else
            {
                channelTextBox.Text = "Stable";
            }
        }

        private void betaButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void stableButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
