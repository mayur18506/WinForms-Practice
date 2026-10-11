namespace _5.Link_Label_Control
{
    partial class Form1
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
            this.MyLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // MyLink
            // 
            this.MyLink.AutoSize = true;
            this.MyLink.BackColor = System.Drawing.SystemColors.Control;
            this.MyLink.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MyLink.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyLink.Location = new System.Drawing.Point(490, 313);
            this.MyLink.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MyLink.Name = "MyLink";
            this.MyLink.Size = new System.Drawing.Size(375, 29);
            this.MyLink.TabIndex = 0;
            this.MyLink.TabStop = true;
            this.MyLink.Text = "CLICK THIS LINK TO OPEN  GOOGLE";
            this.MyLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MyLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MyLink_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1322, 696);
            this.Controls.Add(this.MyLink);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel MyLink;
    }
}

