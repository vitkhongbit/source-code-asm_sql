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
    public partial class formCustomer : Form
    {
        public formCustomer()
        {
            InitializeComponent();
            displayCustomer();
        }

        public void displayCustomer()
        {
            customerData cus = new customerData();
            List<customerData> list = cus.allcustomer();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
