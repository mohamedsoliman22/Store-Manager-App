using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace StoreManagerApp
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
            this.Text = "Store Manager - Products";
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                DataTable products = DatabaseHelper.ExecuteQuery("SELECT * FROM Products");
                dgvProducts.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading products: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Add
        {
            AddProductForm addForm = new AddProductForm();
            addForm.FormClosed += (s, args) => LoadProducts();
            addForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e) // Edit
        {
            if (dgvProducts.CurrentRow != null)
            {
                try
                {
                    var row = dgvProducts.CurrentRow;

                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    string name = row.Cells["ProductName"].Value?.ToString();
                    decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                    int quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                    EditProductForm editForm = new EditProductForm(id, name, price, quantity);
                    editForm.FormClosed += (s, args) => LoadProducts();
                    editForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error preparing to edit product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e) // Delete
        {
            if (dgvProducts.CurrentRow != null)
            {
                try
                {
                    int id = Convert.ToInt32(dgvProducts.CurrentRow.Cells["Id"].Value);
                    DialogResult confirm = MessageBox.Show(
                        "Are you sure you want to delete this product?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        var parameters = new[]
                        {
                            new SqlParameter("@id", id)
                        };

                        DatabaseHelper.ExecuteNonQuery("DELETE FROM Products WHERE Id = @id", parameters);
                        LoadProducts();
                        MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a product to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
