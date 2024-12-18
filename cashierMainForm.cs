using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace inventoryManagementSystem
{
    public partial class cashierMainForm : Form
    {
        public cashierMainForm()
        {
            InitializeComponent();
        }

        private void btn_customer_Click(object sender, EventArgs e)
        {
            openChildForm(new cashierOrder());
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
            panel_10.Controls.Add(childform);
            panel_10.Tag = childform;
            childform.BringToFront();
            childform.Show();
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

        private void btn_customer_Click_1(object sender, EventArgs e)
        {
            openChildForm(new formInvoice());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_customer_Click_2(object sender, EventArgs e)
        {
            openChildForm(new formCustomer());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new formInvoice());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChildForm(new cashierOrder());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure want to logout?", "Information Message"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 loginForm = new Form1();
                loginForm.Show();
                this.Close();
            }
        }
    }
}
