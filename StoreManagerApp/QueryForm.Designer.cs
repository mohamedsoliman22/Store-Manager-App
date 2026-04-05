namespace StoreManagerApp
{
    partial class QueryForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cmbQueryList;
        private System.Windows.Forms.TextBox txtThreshold;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.Button btnRunQuery;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvQueryResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cmbQueryList = new System.Windows.Forms.ComboBox();
            this.txtThreshold = new System.Windows.Forms.TextBox();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.btnRunQuery = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvQueryResults = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResults)).BeginInit();
            this.SuspendLayout();

            // cmbQueryList
            this.cmbQueryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQueryList.Items.AddRange(new object[] {
                "Top 5 Customers by Order Count",
                "Products with Price > X",
                "Top 5 Customers by Total Amount",
                "Products with Quantity < X"
            });
            this.cmbQueryList.Location = new System.Drawing.Point(67, 40);
            this.cmbQueryList.Name = "cmbQueryList";
            this.cmbQueryList.Size = new System.Drawing.Size(350, 27);
            this.cmbQueryList.TabIndex = 0;
            this.cmbQueryList.SelectedIndexChanged += new System.EventHandler(this.cmbQueryList_SelectedIndexChanged);

            // txtThreshold
            this.txtThreshold.Location = new System.Drawing.Point(515, 40);
            this.txtThreshold.Name = "txtThreshold";
            this.txtThreshold.Size = new System.Drawing.Size(100, 27);
            this.txtThreshold.TabIndex = 2;
            this.txtThreshold.Visible = false;

            // lblThreshold
            this.lblThreshold.Location = new System.Drawing.Point(440, 40);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(70, 20);
            this.lblThreshold.TabIndex = 1;
            this.lblThreshold.Text = "Threshold:";
            this.lblThreshold.Visible = false;

            // btnRunQuery
            this.btnRunQuery.BackColor = System.Drawing.Color.LightCoral;
            this.btnRunQuery.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.btnRunQuery.Location = new System.Drawing.Point(130, 510);
            this.btnRunQuery.Name = "btnRunQuery";
            this.btnRunQuery.Size = new System.Drawing.Size(175, 45);
            this.btnRunQuery.TabIndex = 3;
            this.btnRunQuery.Text = "Run Query";
            this.btnRunQuery.UseVisualStyleBackColor = false;
            this.btnRunQuery.Click += new System.EventHandler(this.btnRunQuery_Click);

            // btnExportCsv
            this.btnExportCsv.BackColor = System.Drawing.Color.LightCoral;
            this.btnExportCsv.Font = new System.Drawing.Font("Times New Roman", 14F);
            this.btnExportCsv.Location = new System.Drawing.Point(480, 510);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(175, 45);
            this.btnExportCsv.TabIndex = 4;
            this.btnExportCsv.Text = "Export to CSV";
            this.btnExportCsv.UseVisualStyleBackColor = false;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);

            // btnBack
            this.btnBack.BackColor = System.Drawing.Color.LightCoral;
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 11F);
            this.btnBack.Location = new System.Drawing.Point(650, 35);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(80, 38);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // dgvQueryResults
            this.dgvQueryResults.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dgvQueryResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryResults.Location = new System.Drawing.Point(90, 100);
            this.dgvQueryResults.Name = "dgvQueryResults";
            this.dgvQueryResults.RowHeadersWidth = 62;
            this.dgvQueryResults.Size = new System.Drawing.Size(600, 370);
            this.dgvQueryResults.TabIndex = 6;
            this.dgvQueryResults.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

            // QueryForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.cmbQueryList);
            this.Controls.Add(this.txtThreshold);
            this.Controls.Add(this.lblThreshold);
            this.Controls.Add(this.btnRunQuery);
            this.Controls.Add(this.btnExportCsv);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvQueryResults);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "QueryForm";
            this.Text = "Advanced Queries";
            ((System.ComponentModel.ISupportInitialize)(this.dgvQueryResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
