namespace StoreManagerApp
{
    partial class EditCustomerForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.DateTimePicker dtpRegDate;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblRegDate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Drawing.Color darkGreen = System.Drawing.Color.FromArgb(0, 64, 64);
            System.Drawing.Color lightPink = System.Drawing.Color.LightCoral;

            this.txtName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.dtpRegDate = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblRegDate = new System.Windows.Forms.Label();

            // TextBox style
            var txtBoxes = new[] { txtName, txtEmail, txtPhone, txtAddress };
            foreach (var txt in txtBoxes)
            {
                txt.BackColor = System.Drawing.Color.White;
                txt.ForeColor = System.Drawing.Color.Black;
                txt.Font = new System.Drawing.Font("Times New Roman", 12F);
                txt.Size = new System.Drawing.Size(450, 30);
            }

            // Label style
            var labels = new[] { lblName, lblEmail, lblPhone, lblAddress, lblRegDate };
            foreach (var lbl in labels)
            {
                lbl.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
                lbl.ForeColor = System.Drawing.Color.White;
                lbl.AutoSize = true;
            }

            // Positioning
            txtName.Location = new System.Drawing.Point(320, 40);
            txtEmail.Location = new System.Drawing.Point(320, 90);
            txtPhone.Location = new System.Drawing.Point(320, 140);
            txtAddress.Location = new System.Drawing.Point(320, 190);
            dtpRegDate.Location = new System.Drawing.Point(320, 245);
            dtpRegDate.Size = new System.Drawing.Size(300, 30);

            lblName.Location = new System.Drawing.Point(150, 40);
            lblName.Text = "Name:";
            lblEmail.Location = new System.Drawing.Point(150, 90);
            lblEmail.Text = "Email:";
            lblPhone.Location = new System.Drawing.Point(150, 140);
            lblPhone.Text = "Phone:";
            lblAddress.Location = new System.Drawing.Point(150, 190);
            lblAddress.Text = "Address:";
            lblRegDate.Location = new System.Drawing.Point(150, 245);
            lblRegDate.Text = "Registration Date:";

            // Buttons
            btnUpdate.Text = "Update";
            btnUpdate.Font = new System.Drawing.Font("Times New Roman", 14F);
            btnUpdate.BackColor = lightPink;
            btnUpdate.ForeColor = System.Drawing.Color.White;
            btnUpdate.Location = new System.Drawing.Point(200, 330);
            btnUpdate.Size = new System.Drawing.Size(180, 45);
            btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            btnCancel.Text = "Cancel";
            btnCancel.Font = new System.Drawing.Font("Times New Roman", 14F);
            btnCancel.BackColor = lightPink;
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(420, 330);
            btnCancel.Size = new System.Drawing.Size(180, 45);
            btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Form
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.BackColor = darkGreen;
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                txtName, txtEmail, txtPhone, txtAddress, dtpRegDate,
                lblName, lblEmail, lblPhone, lblAddress, lblRegDate,
                btnUpdate, btnCancel
            });
            this.Text = "Edit Customer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
