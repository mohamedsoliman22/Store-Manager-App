using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace StoreManagerApp
{
    public partial class AddProductForm : Form
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ECommerceDB;Integrated Security=True";

        public AddProductForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name) ||
                !decimal.TryParse(txtPrice.Text, out decimal price) ||
                !int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Please enter valid product data.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Products (ProductName, Price, Quantity) VALUES (@name, @price, @qty)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@qty", quantity);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Product added successfully.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding product: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // Optional future validation
        }

        private void AddProductForm_Load(object sender, EventArgs e)
        {
            // Optional future use
        }
    }
}
