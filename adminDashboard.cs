using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryManagementSystem
{
    public partial class adminDashboard : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True");

        public adminDashboard()
        {
            InitializeComponent();
            displayTodayInvoice();
            displayAllUsers();
            displayAllCustomer();
            displayTodayIncome();
            displayTotalIncome();
        }

        public bool checkConnection()
        {
            if (connect.State == ConnectionState.Closed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void adminDashboard_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void displayTodayInvoice()
        {
            invoiceData todayData = new invoiceData();
            List<invoiceData> listData = todayData.allTodayInvoice();
            dataGridView1.DataSource = listData;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        public void displayAllUsers()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    string selectData = " SELECT COUNT(id) FROM users WHERE status = @status";
                    using (SqlCommand cmd = new SqlCommand(selectData,connect))
                    {
                        cmd.Parameters.AddWithValue("@status", "Active");
                        SqlDataReader reader = cmd.ExecuteReader();
                        if ( reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dasboard_allUser.Text = count.ToString();
                        }
                        reader.Close(); 
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show("Connection failed" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }finally
                {
                    connect.Close();
                }

            }
        }

        public void displayAllCustomer()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    string selectData = " SELECT COUNT(id) FROM customer";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_allCustomer.Text = count.ToString();
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connect.Close();
                }

            }

        }
         public void displayTodayIncome()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    string selectData = " SELECT SUM(total_price) FROM invoice WHERE order_date = @date ";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        DateTime today = DateTime.Today;
                        string getToday = today.ToString("yyyy-MM-dd");

                        cmd.Parameters.AddWithValue("@date", getToday);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            object value = reader[0];
                            if(value != DBNull.Value)
                            {
                                int count = Convert.ToInt32(reader[0]);
                                dashboard_todayIncome.Text = count.ToString("0.00");
                            }
                            reader.Close();
                            
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connect.Close();
                }

            }
        }

        public void displayTotalIncome()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();
                    string selectData = " SELECT SUM(total_price) FROM invoice ";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_totaIncome.Text = count.ToString("0.00");
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connect.Close();
                }

            }
        }
    }
}
