namespace _8.CheckBox_Control
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
            this.label1 = new System.Windows.Forms.Label();
            this.SAMSUNGCH = new System.Windows.Forms.CheckBox();
            this.IPHONECH = new System.Windows.Forms.CheckBox();
            this.NOKIACH = new System.Windows.Forms.CheckBox();
            this.OPPOCH = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(529, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "SELECT YOUR FAVORURITE MOBILE COMPANIES";
            // 
            // SAMSUNGCH
            // 
            this.SAMSUNGCH.AutoSize = true;
            this.SAMSUNGCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SAMSUNGCH.Location = new System.Drawing.Point(60, 85);
            this.SAMSUNGCH.Name = "SAMSUNGCH";
            this.SAMSUNGCH.Size = new System.Drawing.Size(129, 26);
            this.SAMSUNGCH.TabIndex = 1;
            this.SAMSUNGCH.Text = "SAMSUNG";
            this.SAMSUNGCH.UseVisualStyleBackColor = true;
            this.SAMSUNGCH.CheckedChanged += new System.EventHandler(this.SAMSUNGCH_CheckedChanged);
            // 
            // IPHONECH
            // 
            this.IPHONECH.AutoSize = true;
            this.IPHONECH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPHONECH.Location = new System.Drawing.Point(60, 117);
            this.IPHONECH.Name = "IPHONECH";
            this.IPHONECH.Size = new System.Drawing.Size(106, 26);
            this.IPHONECH.TabIndex = 1;
            this.IPHONECH.Text = "IPHONE";
            this.IPHONECH.UseVisualStyleBackColor = true;
            this.IPHONECH.CheckedChanged += new System.EventHandler(this.IPHONECH_CheckedChanged);
            // 
            // NOKIACH
            // 
            this.NOKIACH.AutoSize = true;
            this.NOKIACH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NOKIACH.Location = new System.Drawing.Point(60, 149);
            this.NOKIACH.Name = "NOKIACH";
            this.NOKIACH.Size = new System.Drawing.Size(92, 26);
            this.NOKIACH.TabIndex = 1;
            this.NOKIACH.Text = "NOKIA";
            this.NOKIACH.UseVisualStyleBackColor = true;
            this.NOKIACH.CheckedChanged += new System.EventHandler(this.NOKIACH_CheckedChanged);
            // 
            // OPPOCH
            // 
            this.OPPOCH.AutoSize = true;
            this.OPPOCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OPPOCH.Location = new System.Drawing.Point(60, 181);
            this.OPPOCH.Name = "OPPOCH";
            this.OPPOCH.Size = new System.Drawing.Size(88, 26);
            this.OPPOCH.TabIndex = 1;
            this.OPPOCH.Text = "OPPO";
            this.OPPOCH.UseVisualStyleBackColor = true;
            this.OPPOCH.CheckedChanged += new System.EventHandler(this.OPPOCH_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(60, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 49);
            this.button1.TabIndex = 2;
            this.button1.Text = "SUBMIT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.LightGray;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Red;
            this.checkBox1.Location = new System.Drawing.Point(70, 336);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(109, 26);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "ENABLE";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(248, 325);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 44);
            this.button2.TabIndex = 4;
            this.button2.Text = "MY BUTTON";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OPPOCH);
            this.Controls.Add(this.NOKIACH);
            this.Controls.Add(this.IPHONECH);
            this.Controls.Add(this.SAMSUNGCH);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox SAMSUNGCH;
        private System.Windows.Forms.CheckBox IPHONECH;
        private System.Windows.Forms.CheckBox NOKIACH;
        private System.Windows.Forms.CheckBox OPPOCH;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
    }
}

