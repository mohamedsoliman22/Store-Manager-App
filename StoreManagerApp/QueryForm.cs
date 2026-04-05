using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace StoreManagerApp
{
    public partial class QueryForm : Form
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ECommerceDB;Integrated Security=True";

        public QueryForm()
        {
            InitializeComponent();
            cmbQueryList.SelectedIndex = 0;
        }

        private void cmbQueryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cmbQueryList.SelectedItem.ToString();
            bool showThreshold = selected.Contains("X");
            txtThreshold.Visible = showThreshold;
            lblThreshold.Visible = showThreshold;
        }

        private void btnRunQuery_Click(object sender, EventArgs e)
        {
            string selectedQuery = cmbQueryList.SelectedItem.ToString();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                if (selectedQuery == "Top 5 Customers by Order Count")
                {
                    cmd.CommandText = @"
                        SELECT TOP 5 c.CustomerName, COUNT(o.Id) AS OrderCount
                        FROM Customers c
                        JOIN Orders o ON c.Id = o.CustomerId
                        GROUP BY c.CustomerName
                        ORDER BY OrderCount DESC";
                }
                else if (selectedQuery == "Products with Price > X")
                {
                    if (!decimal.TryParse(txtThreshold.Text, out decimal threshold))
                    {
                        MessageBox.Show("Please enter a valid threshold value.");
                        return;
                    }

                    cmd.CommandText = @"
                        SELECT ProductName, Price, Quantity
                        FROM Products
                        WHERE Price > @threshold
                        ORDER BY Price DESC";
                    cmd.Parameters.AddWithValue("@threshold", threshold);
                }
                else if (selectedQuery == "Top 5 Customers by Total Amount")
                {
                    cmd.CommandText = @"
                        SELECT TOP 5 c.CustomerName, SUM(o.OrderAmount) AS TotalAmount
                        FROM Customers c
                        JOIN Orders o ON c.Id = o.CustomerId
                        GROUP BY c.CustomerName
                        ORDER BY TotalAmount DESC";
                }
                else if (selectedQuery == "Products with Quantity < X")
                {
                    if (!int.TryParse(txtThreshold.Text, out int threshold))
                    {
                        MessageBox.Show("Please enter a valid threshold value.");
                        return;
                    }

                    cmd.CommandText = @"
                        SELECT ProductName, Quantity, Price
                        FROM Products
                        WHERE Quantity < @threshold
                        ORDER BY Quantity ASC";
                    cmd.Parameters.AddWithValue("@threshold", threshold);
                }

                adapter.SelectCommand = cmd;
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvQueryResults.DataSource = table;
            }
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            DataTable dt = dgvQueryResults.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.FileName = "query_results.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sb.Append(dt.Columns[i]);
                        if (i < dt.Columns.Count - 1) sb.Append(",");
                    }
                    sb.AppendLine();

                    foreach (DataRow row in dt.Rows)
                    {
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            sb.Append(row[i]?.ToString());
                            if (i < dt.Columns.Count - 1) sb.Append(",");
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString());
                    MessageBox.Show("Exported successfully to " + sfd.FileName);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
