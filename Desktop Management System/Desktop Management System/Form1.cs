//using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace BlogAdminWinForms
{
    public partial class Form1 : Form
    {
        // Connection string targeting SQL Server database
        private readonly string connectionString = "Server=localhost;Database=BlogAppDb;Trusted_Connection=True;TrustServerCertificate=True;";

        // UI Controls
        private TextBox txtId;
        private TextBox txtTitle;
        private TextBox txtSummary;
        private TextBox txtContent;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvPosts;

        public Form1()
        {
            InitializeCustomComponents();
            LoadPostsData();
        }

        private void InitializeCustomComponents()
        {
            this.Text = "Blog & Content Management System - Admin Dashboard";
            this.Size = new Size(950, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("Segoe UI", 9.5f);

            // Left Input Panel
            Panel panelInput = new Panel { Dock = DockStyle.Left, Width = 380, Padding = new Padding(15) };

            Label lblId = new Label { Text = "Post ID:", Location = new Point(15, 15), AutoSize = true };
            txtId = new TextBox { Location = new Point(15, 35), Width = 340, ReadOnly = true, BackColor = Color.FromArgb(240, 240, 240) };

            Label lblTitle = new Label { Text = "Title:", Location = new Point(15, 70), AutoSize = true };
            txtTitle = new TextBox { Location = new Point(15, 90), Width = 340 };

            Label lblSummary = new Label { Text = "Summary:", Location = new Point(15, 125), AutoSize = true };
            txtSummary = new TextBox { Location = new Point(15, 145), Width = 340 };

            Label lblContent = new Label { Text = "Content:", Location = new Point(15, 180), AutoSize = true };
            txtContent = new TextBox { Location = new Point(15, 200), Width = 340, Height = 140, Multiline = true, ScrollBars = ScrollBars.Vertical };

            // Buttons
            btnAdd = new Button { Text = "Add Post", Location = new Point(15, 360), Width = 75, Height = 32, BackColor = Color.FromArgb(0, 123, 255), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnUpdate = new Button { Text = "Update", Location = new Point(100, 360), Width = 75, Height = 32, BackColor = Color.FromArgb(40, 167, 69), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnDelete = new Button { Text = "Delete", Location = new Point(185, 360), Width = 75, Height = 32, BackColor = Color.FromArgb(220, 53, 69), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnClear = new Button { Text = "Clear", Location = new Point(270, 360), Width = 85, Height = 32, BackColor = Color.FromArgb(108, 117, 125), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += (s, e) => ClearFields();

            panelInput.Controls.AddRange(new Control[] { lblId, txtId, lblTitle, txtTitle, lblSummary, txtSummary, lblContent, txtContent, btnAdd, btnUpdate, btnDelete, btnClear });

            // Right DataGridView
            dgvPosts = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                BackgroundColor = Color.White
            };
            dgvPosts.CellClick += DgvPosts_CellClick;

            this.Controls.Add(dgvPosts);
            this.Controls.Add(panelInput);
        }

        private void LoadPostsData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT PostId, Title, Summary, Content, CreatedAt FROM Posts ORDER BY PostId DESC";
                    using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dgvPosts.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database load error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) || string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MessageBox.Show("Please fill out Title and Content fields.", "Validation Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Posts (Title, Summary, Content, CreatedAt) VALUES (@Title, @Summary, @Content, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Summary", txtSummary.Text.Trim());
                        cmd.Parameters.AddWithValue("@Content", txtContent.Text.Trim());

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Post added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadPostsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding post: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Select a post from the grid to update.", "Selection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Posts SET Title = @Title, Summary = @Summary, Content = @Content WHERE PostId = @PostId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@PostId", Convert.ToInt32(txtId.Text));
                        cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@Summary", txtSummary.Text.Trim());
                        cmd.Parameters.AddWithValue("@Content", txtContent.Text.Trim());

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Post updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadPostsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating post: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Select a post from the grid to delete.", "Selection Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Are you sure you want to permanently delete this post?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Posts WHERE PostId = @PostId";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@PostId", Convert.ToInt32(txtId.Text));

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Post deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
                LoadPostsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting post: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPosts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPosts.Rows[e.RowIndex];
                txtId.Text = row.Cells["PostId"].Value?.ToString();
                txtTitle.Text = row.Cells["Title"].Value?.ToString();
                txtSummary.Text = row.Cells["Summary"].Value?.ToString();
                txtContent.Text = row.Cells["Content"].Value?.ToString();
            }
        }

        private void ClearFields()
        {
            txtId.Clear();
            txtTitle.Clear();
            txtSummary.Clear();
            txtContent.Clear();
            dgvPosts.ClearSelection();
        }
    }
}