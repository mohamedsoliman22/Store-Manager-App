using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace StoreManagerApp
{
    public partial class EditProductForm : Form
    {
        private int productId;
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ECommerceDB;Integrated Security=True";

        public EditProductForm(int id, string name, decimal price, int quantity)
        {
            InitializeComponent();
            productId = id;
            txtProductName.Text = name;
            txtPrice.Text = price.ToString();
            txtQuantity.Text = quantity.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) ||
                !decimal.TryParse(txtPrice.Text, out decimal price) ||
                !int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter valid product data.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET ProductName = @name, Price = @price, Quantity = @qty WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", txtProductName.Text.Trim());
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@qty", quantity);
                cmd.Parameters.AddWithValue("@id", productId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Product updated successfully.");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
