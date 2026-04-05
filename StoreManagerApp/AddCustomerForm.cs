// AddCustomerForm.cs
using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace StoreManagerApp
{
    public partial class AddCustomerForm : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ECommerceDB;Integrated Security=True";

        public AddCustomerForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter customer name.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customers (CustomerName, Email, PhoneNumber, Address, RegistrationDate) " +
                               "VALUES (@name, @mail, @phone, @addr, @regDate)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@regDate", dtpRegDate.Value);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Customer added successfully.");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void lblName_Click(object sender, EventArgs e) { }
        private void AddCustomerForm_Load(object sender, EventArgs e) { }
    }
}
