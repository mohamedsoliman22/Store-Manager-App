using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace StoreManagerApp
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
            this.Text = "Store Manager - Sign Up";
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string confirmPassword = txtConfirmPassword.Text.Trim();
                string email = txtEmail.Text.Trim();

                // Validate input
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || 
                    string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if username or email already exists
                var checkParameters = new[]
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@email", email)
                };

                DataTable existingUser = DatabaseHelper.ExecuteQuery(
                    "SELECT 1 FROM Users WHERE Username = @username OR Email = @email",
                    checkParameters
                );

                if (existingUser.Rows.Count > 0)
                {
                    MessageBox.Show("Username or email already exists.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert new user
                var insertParameters = new[]
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password),
                    new SqlParameter("@email", email)
                };

                DatabaseHelper.ExecuteNonQuery(
                    "INSERT INTO Users (Username, Password, Email, IsAdmin) VALUES (@username, @password, @email, 0)",
                    insertParameters
                );

                MessageBox.Show("Registration successful! You can now login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during registration: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
} 