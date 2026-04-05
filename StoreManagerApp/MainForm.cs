using System;
using System.Windows.Forms;

namespace StoreManagerApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open ProductForm
            ProductForm productForm = new ProductForm();
            productForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Open CustomerForm
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Open QueryForm (Complex Queries)
            QueryForm queryForm = new QueryForm();
            queryForm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Exit application
            Application.Exit();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            var manageUsersForm = new ManageUsersForm();
            manageUsersForm.ShowDialog();
        }
    }
}
