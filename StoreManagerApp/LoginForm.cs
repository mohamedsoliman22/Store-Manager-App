using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace StoreManagerApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.Text = "Store Manager - Login";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var parameters = new[]
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password)
                };

                DataTable result = DatabaseHelper.ExecuteQuery(
                    "SELECT Id, Username, IsAdmin FROM Users WHERE Username = @username AND Password = @password",
                    parameters
                );

                if (result.Rows.Count > 0)
                {
                    // Store user info in a static class for later use
                    UserSession.CurrentUser = new UserInfo
                    {
                        Id = Convert.ToInt32(result.Rows[0]["Id"]),
                        Username = result.Rows[0]["Username"].ToString(),
                        IsAdmin = Convert.ToBoolean(result.Rows[0]["IsAdmin"])
                    };

                    this.Hide();
                    if (UserSession.CurrentUser.IsAdmin)
                    {
                        MainForm mainForm = new MainForm();
                        mainForm.FormClosed += (s, args) => this.Close();
                        mainForm.Show();
                    }
                    else
                    {
                        WelcomeUserForm welcomeForm = new WelcomeUserForm();
                        welcomeForm.FormClosed += (s, args) => this.Close();
                        welcomeForm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            SignupForm signupForm = new SignupForm();
            signupForm.ShowDialog();
        }
    }
} 