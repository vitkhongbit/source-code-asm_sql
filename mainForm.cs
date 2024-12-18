using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryManagementSystem
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to exit?", "Information Message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to logout?", "Information Message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }

        private Form currentFormChild;
        private void openChildForm(Form childform)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childform);
            panel_body.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new adminDashboard());

        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
            openChildForm(new addUser());
        }

        private void btn_addCategory_Click(object sender, EventArgs e)
        {
            openChildForm(new addCategory());
        }

        private void btn_addProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new addProduct());
        }

        private void btn_invoice_Click(object sender, EventArgs e)
        {
            openChildForm(new formInvoice());
        }
    }
}
