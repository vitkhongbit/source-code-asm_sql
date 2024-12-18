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
    public partial class wareHouseMainForm : Form
    {
        public wareHouseMainForm()
        {
            InitializeComponent();
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


        private void warehouse_addCategory_Click(object sender, EventArgs e)
        {
            openChildForm(new addCategory());
        }

        private void warhouse_addProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new addProduct());
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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
