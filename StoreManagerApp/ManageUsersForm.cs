using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace StoreManagerApp
{
    public partial class ManageUsersForm : Form
    {
        public ManageUsersForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                DataTable users = DatabaseHelper.ExecuteQuery("SELECT Id, Username, Email, IsAdmin, CreatedDate FROM Users");
                dgvUsers.DataSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading users: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int id = Convert.ToInt32(dgvUsers.CurrentRow.Cells["Id"].Value);
                if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DatabaseHelper.ExecuteNonQuery("DELETE FROM Users WHERE Id = @id", new SqlParameter("@id", id));
                    LoadUsers();
                }
            }
        }

        private void dgvUsers_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Save changes to the database
            var row = dgvUsers.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["Id"].Value);
            string username = row.Cells["Username"].Value?.ToString();
            string email = row.Cells["Email"].Value?.ToString();
            bool isAdmin = Convert.ToBoolean(row.Cells["IsAdmin"].Value);
            DatabaseHelper.ExecuteNonQuery(
                "UPDATE Users SET Username=@username, Email=@email, IsAdmin=@isAdmin WHERE Id=@id",
                new SqlParameter("@username", username),
                new SqlParameter("@email", email),
                new SqlParameter("@isAdmin", isAdmin),
                new SqlParameter("@id", id)
            );
        }
    }
} 