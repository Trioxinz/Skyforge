namespace Skyforge
{
    partial class UpdateChannelForm
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
            this.updateChannelLabel = new System.Windows.Forms.Label();
            this.channelTextBox = new System.Windows.Forms.TextBox();
            this.stableButton = new System.Windows.Forms.Button();
            this.betaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // updateChannelLabel
            // 
            this.updateChannelLabel.AutoSize = true;
            this.updateChannelLabel.Font = new System.Drawing.Font("Times New Roman", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateChannelLabel.Location = new System.Drawing.Point(12, 22);
            this.updateChannelLabel.Name = "updateChannelLabel";
            this.updateChannelLabel.Size = new System.Drawing.Size(289, 31);
            this.updateChannelLabel.TabIndex = 0;
            this.updateChannelLabel.Text = "Current Update Channel:";
            // 
            // channelTextBox
            // 
            this.channelTextBox.BackColor = System.Drawing.Color.Black;
            this.channelTextBox.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.channelTextBox.ForeColor = System.Drawing.Color.Lime;
            this.channelTextBox.Location = new System.Drawing.Point(307, 22);
            this.channelTextBox.Name = "channelTextBox";
            this.channelTextBox.ReadOnly = true;
            this.channelTextBox.Size = new System.Drawing.Size(144, 30);
            this.channelTextBox.TabIndex = 0;
            this.channelTextBox.TabStop = false;
            // 
            // stableButton
            // 
            this.stableButton.Location = new System.Drawing.Point(171, 78);
            this.stableButton.Name = "stableButton";
            this.stableButton.Size = new System.Drawing.Size(137, 35);
            this.stableButton.TabIndex = 2;
            this.stableButton.TabStop = false;
            this.stableButton.Text = "Stable";
            this.stableButton.UseVisualStyleBackColor = true;
            this.stableButton.Click += new System.EventHandler(this.stableButton_Click);
            // 
            // betaButton
            // 
            this.betaButton.Location = new System.Drawing.Point(314, 78);
            this.betaButton.Name = "betaButton";
            this.betaButton.Size = new System.Drawing.Size(137, 35);
            this.betaButton.TabIndex = 3;
            this.betaButton.TabStop = false;
            this.betaButton.Text = "Development";
            this.betaButton.UseVisualStyleBackColor = true;
            this.betaButton.Click += new System.EventHandler(this.betaButton_Click);
            // 
            // UpdateChannelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 125);
            this.ControlBox = false;
            this.Controls.Add(this.betaButton);
            this.Controls.Add(this.stableButton);
            this.Controls.Add(this.channelTextBox);
            this.Controls.Add(this.updateChannelLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateChannelForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Update Channel Selector";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.UpdateChannelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label updateChannelLabel;
        private System.Windows.Forms.TextBox channelTextBox;
        private System.Windows.Forms.Button stableButton;
        private System.Windows.Forms.Button betaButton;
    }
}