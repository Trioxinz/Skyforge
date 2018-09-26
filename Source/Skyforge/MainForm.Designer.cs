namespace Skyforge
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.terminalTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.fileDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.checkForUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sitchUpdatechannelStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutSkyforgeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileListView = new System.Windows.Forms.ListView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderTextBox = new System.Windows.Forms.TextBox();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // terminalTextBox
            // 
            this.terminalTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.terminalTextBox.BackColor = System.Drawing.Color.Black;
            this.terminalTextBox.Font = new System.Drawing.Font("Consolas", 8.25F);
            this.terminalTextBox.ForeColor = System.Drawing.Color.Lime;
            this.terminalTextBox.Location = new System.Drawing.Point(355, 294);
            this.terminalTextBox.MaxLength = 2147483647;
            this.terminalTextBox.Multiline = true;
            this.terminalTextBox.Name = "terminalTextBox";
            this.terminalTextBox.ReadOnly = true;
            this.terminalTextBox.Size = new System.Drawing.Size(427, 295);
            this.terminalTextBox.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileDownButton,
            this.helpDownButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1122, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // fileDownButton
            // 
            this.fileDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
            this.fileDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fileDownButton.Name = "fileDownButton";
            this.fileDownButton.Size = new System.Drawing.Size(38, 22);
            this.fileDownButton.Text = "File";
            this.fileDownButton.ToolTipText = "File";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitMenuItem.Text = "Exit";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // helpDownButton
            // 
            this.helpDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.helpDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForUpdateToolStripMenuItem,
            this.sitchUpdatechannelStripMenuItem,
            this.licenseToolStripMenuItem,
            this.aboutSkyforgeToolStripMenuItem});
            this.helpDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpDownButton.Name = "helpDownButton";
            this.helpDownButton.Size = new System.Drawing.Size(45, 22);
            this.helpDownButton.Text = "Help";
            // 
            // checkForUpdateToolStripMenuItem
            // 
            this.checkForUpdateToolStripMenuItem.Name = "checkForUpdateToolStripMenuItem";
            this.checkForUpdateToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.checkForUpdateToolStripMenuItem.Text = "Check for update";
            this.checkForUpdateToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdateToolStripMenuItem_Click);
            // 
            // sitchUpdatechannelStripMenuItem
            // 
            this.sitchUpdatechannelStripMenuItem.Name = "sitchUpdatechannelStripMenuItem";
            this.sitchUpdatechannelStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.sitchUpdatechannelStripMenuItem.Text = "Switch update channel";
            this.sitchUpdatechannelStripMenuItem.Click += new System.EventHandler(this.sitchUpdatechannelStripMenuItem_Click);
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.licenseToolStripMenuItem.Text = "LICENSE";
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // aboutSkyforgeToolStripMenuItem
            // 
            this.aboutSkyforgeToolStripMenuItem.Name = "aboutSkyforgeToolStripMenuItem";
            this.aboutSkyforgeToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.aboutSkyforgeToolStripMenuItem.Text = "About Skyforge";
            this.aboutSkyforgeToolStripMenuItem.Click += new System.EventHandler(this.aboutSkyforgeToolStripMenuItem_Click);
            // 
            // fileListView
            // 
            this.fileListView.Location = new System.Drawing.Point(12, 108);
            this.fileListView.Name = "fileListView";
            this.fileListView.Size = new System.Drawing.Size(337, 481);
            this.fileListView.TabIndex = 2;
            this.fileListView.UseCompatibleStateImageBehavior = false;
            this.fileListView.View = System.Windows.Forms.View.List;
            // 
            // folderTextBox
            // 
            this.folderTextBox.Location = new System.Drawing.Point(12, 82);
            this.folderTextBox.Name = "folderTextBox";
            this.folderTextBox.Size = new System.Drawing.Size(337, 20);
            this.folderTextBox.TabIndex = 3;
            this.folderTextBox.Text = "Please select a folder containing the mod files to work with";
            this.folderTextBox.TextChanged += new System.EventHandler(this.folderTextBox_TextChanged);
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(12, 41);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(125, 35);
            this.selectFolderButton.TabIndex = 4;
            this.selectFolderButton.Text = "Select Folder";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 601);
            this.Controls.Add(this.selectFolderButton);
            this.Controls.Add(this.folderTextBox);
            this.Controls.Add(this.fileListView);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.terminalTextBox);
            this.MinimumSize = new System.Drawing.Size(1138, 640);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Skyforge";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox terminalTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton fileDownButton;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton helpDownButton;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sitchUpdatechannelStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutSkyforgeToolStripMenuItem;
        private System.Windows.Forms.ListView fileListView;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox folderTextBox;
        private System.Windows.Forms.Button selectFolderButton;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
    }
}