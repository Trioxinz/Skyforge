namespace SkyforgeReforge
{
    partial class UpdateAcceptForm
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
            this.labelUpdateAvailable = new System.Windows.Forms.Label();
            this.labelUpdateVersionAvailable = new System.Windows.Forms.Label();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.buttonYes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelUpdateAvailable
            // 
            this.labelUpdateAvailable.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpdateAvailable.Location = new System.Drawing.Point(12, 9);
            this.labelUpdateAvailable.Name = "labelUpdateAvailable";
            this.labelUpdateAvailable.Size = new System.Drawing.Size(228, 56);
            this.labelUpdateAvailable.TabIndex = 0;
            this.labelUpdateAvailable.Text = "An update is available!\r\nWould you like to update?\r\n";
            this.labelUpdateAvailable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelUpdateVersionAvailable
            // 
            this.labelUpdateVersionAvailable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUpdateVersionAvailable.Location = new System.Drawing.Point(49, 65);
            this.labelUpdateVersionAvailable.Name = "labelUpdateVersionAvailable";
            this.labelUpdateVersionAvailable.Size = new System.Drawing.Size(154, 19);
            this.labelUpdateVersionAvailable.TabIndex = 1;
            this.labelUpdateVersionAvailable.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonDetails
            // 
            this.buttonDetails.Location = new System.Drawing.Point(170, 113);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(75, 23);
            this.buttonDetails.TabIndex = 2;
            this.buttonDetails.Text = "Details";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.Location = new System.Drawing.Point(89, 113);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(75, 23);
            this.buttonNo.TabIndex = 3;
            this.buttonNo.Text = "No";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // buttonYes
            // 
            this.buttonYes.Location = new System.Drawing.Point(8, 113);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(75, 23);
            this.buttonYes.TabIndex = 4;
            this.buttonYes.Text = "Yes";
            this.buttonYes.UseVisualStyleBackColor = true;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // UpdateAcceptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 148);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonDetails);
            this.Controls.Add(this.labelUpdateVersionAvailable);
            this.Controls.Add(this.labelUpdateAvailable);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpdateAcceptForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelUpdateAvailable;
        private System.Windows.Forms.Label labelUpdateVersionAvailable;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Button buttonYes;
    }
}