// EditCustomerForm.cs
using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace StoreManagerApp
{
    public partial class EditCustomerForm : Form
    {
        private int customerId;
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ECommerceDB;Integrated Security=True";

        public EditCustomerForm(int id, string name, string email, string phone, string address, DateTime? regDate)
        {
            InitializeComponent();
            customerId = id;
            txtName.Text = name;
            txtEmail.Text = email;
            txtPhone.Text = phone;
            txtAddress.Text = address;
            dtpRegDate.Value = regDate ?? DateTime.Now;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter customer name.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Customers SET CustomerName = @name, Email = @mail, PhoneNumber = @phone, Address = @addr, RegistrationDate = @regDate WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@mail", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());
                cmd.Parameters.AddWithValue("@addr", txtAddress.Text.Trim());
                cmd.Parameters.AddWithValue("@regDate", dtpRegDate.Value);
                cmd.Parameters.AddWithValue("@id", customerId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Customer updated successfully.");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void lblRegDate_Click(object sender, EventArgs e) { }
    }
}