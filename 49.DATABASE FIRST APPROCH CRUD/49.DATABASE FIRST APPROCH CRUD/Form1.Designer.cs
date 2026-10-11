namespace _49.DATABASE_FIRST_APPROCH_CRUD
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
            this.label2 = new System.Windows.Forms.Label();
            this.nametextBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.agetextBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.classtextBox4 = new System.Windows.Forms.TextBox();
            this.gendercomboBox1 = new System.Windows.Forms.ComboBox();
            this.ibutton1 = new System.Windows.Forms.Button();
            this.ubutton2 = new System.Windows.Forms.Button();
            this.dbutton3 = new System.Windows.Forms.Button();
            this.rbutton4 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(386, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "STUDENT DETAILS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(139, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "NAME";
            // 
            // nametextBox1
            // 
            this.nametextBox1.Location = new System.Drawing.Point(234, 67);
            this.nametextBox1.Name = "nametextBox1";
            this.nametextBox1.Size = new System.Drawing.Size(294, 22);
            this.nametextBox1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(139, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "GENDER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(139, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "AGE";
            // 
            // agetextBox3
            // 
            this.agetextBox3.Location = new System.Drawing.Point(234, 176);
            this.agetextBox3.Name = "agetextBox3";
            this.agetextBox3.Size = new System.Drawing.Size(294, 22);
            this.agetextBox3.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(139, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "CLASS";
            // 
            // classtextBox4
            // 
            this.classtextBox4.Location = new System.Drawing.Point(234, 227);
            this.classtextBox4.Name = "classtextBox4";
            this.classtextBox4.Size = new System.Drawing.Size(294, 22);
            this.classtextBox4.TabIndex = 3;
            // 
            // gendercomboBox1
            // 
            this.gendercomboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.gendercomboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.gendercomboBox1.FormattingEnabled = true;
            this.gendercomboBox1.Items.AddRange(new object[] {
            "MALE ",
            "FEMALE"});
            this.gendercomboBox1.Location = new System.Drawing.Point(234, 120);
            this.gendercomboBox1.Name = "gendercomboBox1";
            this.gendercomboBox1.Size = new System.Drawing.Size(294, 24);
            this.gendercomboBox1.TabIndex = 1;
            // 
            // ibutton1
            // 
            this.ibutton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ibutton1.Location = new System.Drawing.Point(69, 279);
            this.ibutton1.Name = "ibutton1";
            this.ibutton1.Size = new System.Drawing.Size(116, 46);
            this.ibutton1.TabIndex = 4;
            this.ibutton1.Text = "INSERT";
            this.ibutton1.UseVisualStyleBackColor = true;
            this.ibutton1.Click += new System.EventHandler(this.ibutton1_Click);
            // 
            // ubutton2
            // 
            this.ubutton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ubutton2.Location = new System.Drawing.Point(234, 279);
            this.ubutton2.Name = "ubutton2";
            this.ubutton2.Size = new System.Drawing.Size(116, 46);
            this.ubutton2.TabIndex = 4;
            this.ubutton2.Text = "UPDATE";
            this.ubutton2.UseVisualStyleBackColor = true;
            this.ubutton2.Click += new System.EventHandler(this.ubutton2_Click);
            // 
            // dbutton3
            // 
            this.dbutton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dbutton3.Location = new System.Drawing.Point(391, 279);
            this.dbutton3.Name = "dbutton3";
            this.dbutton3.Size = new System.Drawing.Size(116, 46);
            this.dbutton3.TabIndex = 4;
            this.dbutton3.Text = "DELETE";
            this.dbutton3.UseVisualStyleBackColor = true;
            this.dbutton3.Click += new System.EventHandler(this.dbutton3_Click);
            // 
            // rbutton4
            // 
            this.rbutton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbutton4.Location = new System.Drawing.Point(550, 279);
            this.rbutton4.Name = "rbutton4";
            this.rbutton4.Size = new System.Drawing.Size(116, 46);
            this.rbutton4.TabIndex = 4;
            this.rbutton4.Text = "RESET";
            this.rbutton4.UseVisualStyleBackColor = true;
            this.rbutton4.Click += new System.EventHandler(this.rbutton4_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(36, 353);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(740, 313);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 678);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rbutton4);
            this.Controls.Add(this.dbutton3);
            this.Controls.Add(this.ubutton2);
            this.Controls.Add(this.ibutton1);
            this.Controls.Add(this.gendercomboBox1);
            this.Controls.Add(this.classtextBox4);
            this.Controls.Add(this.agetextBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nametextBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nametextBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox agetextBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox classtextBox4;
        private System.Windows.Forms.ComboBox gendercomboBox1;
        private System.Windows.Forms.Button ibutton1;
        private System.Windows.Forms.Button ubutton2;
        private System.Windows.Forms.Button dbutton3;
        private System.Windows.Forms.Button rbutton4;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

