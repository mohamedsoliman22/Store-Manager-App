using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace StoreManagerApp
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
            this.Text = "Store Manager - Customers";
            dgvCustomers.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            dgvCustomers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.Black;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            try
            {
                DataTable customers = DatabaseHelper.ExecuteQuery("SELECT * FROM Customers");
                dgvCustomers.AutoGenerateColumns = true;
                dgvCustomers.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCustomerForm addForm = new AddCustomerForm();
            addForm.FormClosed += (s, args) => LoadCustomers();
            addForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                try
                {
                    var row = dgvCustomers.CurrentRow;

                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    string name = row.Cells["CustomerName"].Value?.ToString();
                    string email = row.Cells["Email"].Value?.ToString();
                    string phone = row.Cells["PhoneNumber"].Value?.ToString();
                    string address = row.Cells["Address"].Value?.ToString();
                    DateTime? registrationDate = row.Cells["RegistrationDate"].Value == DBNull.Value
                        ? (DateTime?)null
                        : Convert.ToDateTime(row.Cells["RegistrationDate"].Value);

                    EditCustomerForm editForm = new EditCustomerForm(id, name, email, phone, address, registrationDate);
                    editForm.FormClosed += (s, args) => LoadCustomers();
                    editForm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error preparing to edit customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow != null)
            {
                try
                {
                    var row = dgvCustomers.CurrentRow;
                    int id = Convert.ToInt32(row.Cells["Id"].Value);

                    var confirm = MessageBox.Show(
                        "Are you sure you want to delete this customer?",
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

                        try
                        {
                            DatabaseHelper.ExecuteNonQuery("DELETE FROM Customers WHERE Id = @id", parameters);
                            LoadCustomers();
                            MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (SqlException ex)
                        {
                            if (ex.Message.Contains("REFERENCE constraint"))
                            {
                                MessageBox.Show(
                                    "This customer cannot be deleted because there are related orders. Please delete their orders first.",
                                    "Cannot Delete",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                            }
                            else
                            {
                                throw;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
