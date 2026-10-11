namespace _55.Shopping_Mart_Apllication_Part_1
{
    partial class ViewDataForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewDataForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ADDbutton1 = new System.Windows.Forms.Button();
            this.UPDATEbutton2 = new System.Windows.Forms.Button();
            this.DELETEbutton3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(754, 157);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gill Sans MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(257, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 42);
            this.label1.TabIndex = 5;
            this.label1.Text = "VIEW DATA";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(40, 248);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(669, 326);
            this.dataGridView1.TabIndex = 6;
            // 
            // ADDbutton1
            // 
            this.ADDbutton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ADDbutton1.Location = new System.Drawing.Point(84, 621);
            this.ADDbutton1.Name = "ADDbutton1";
            this.ADDbutton1.Size = new System.Drawing.Size(128, 42);
            this.ADDbutton1.TabIndex = 7;
            this.ADDbutton1.Text = "ADD ITEM";
            this.ADDbutton1.UseVisualStyleBackColor = true;
            this.ADDbutton1.Click += new System.EventHandler(this.ADDbutton1_Click);
            // 
            // UPDATEbutton2
            // 
            this.UPDATEbutton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UPDATEbutton2.Location = new System.Drawing.Point(264, 601);
            this.UPDATEbutton2.Name = "UPDATEbutton2";
            this.UPDATEbutton2.Size = new System.Drawing.Size(126, 65);
            this.UPDATEbutton2.TabIndex = 7;
            this.UPDATEbutton2.Text = "UPDATE ITEM";
            this.UPDATEbutton2.UseVisualStyleBackColor = true;
            this.UPDATEbutton2.Click += new System.EventHandler(this.UPDATEbutton2_Click);
            // 
            // DELETEbutton3
            // 
            this.DELETEbutton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DELETEbutton3.Location = new System.Drawing.Point(434, 604);
            this.DELETEbutton3.Name = "DELETEbutton3";
            this.DELETEbutton3.Size = new System.Drawing.Size(126, 59);
            this.DELETEbutton3.TabIndex = 7;
            this.DELETEbutton3.Text = "DELETE ITEM";
            this.DELETEbutton3.UseVisualStyleBackColor = true;
            this.DELETEbutton3.Click += new System.EventHandler(this.DELETEbutton3_Click);
            // 
            // ViewDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 703);
            this.Controls.Add(this.DELETEbutton3);
            this.Controls.Add(this.UPDATEbutton2);
            this.Controls.Add(this.ADDbutton1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "ViewDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewDataForm";
            this.Activated += new System.EventHandler(this.ViewDataForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ADDbutton1;
        private System.Windows.Forms.Button UPDATEbutton2;
        private System.Windows.Forms.Button DELETEbutton3;
    }
}