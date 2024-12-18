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
    public partial class formInvoice : Form
    {
        public formInvoice()
        {
            InitializeComponent();
            displayInvoice();
        }

        public void displayInvoice()
        {
            invoiceData i = new invoiceData();
            List<invoiceData> listData = i.allInvoice();
            dataGridView1.DataSource = listData;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
