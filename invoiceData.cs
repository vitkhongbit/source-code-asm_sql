using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryManagementSystem
{
    class invoiceData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True");

        public string Invoice_Id {  get; set; }
        public string TotalPrice { get; set; }
        public string Amount { get; set; }
        public string Change {  get; set; }
        public string Date {  get; set; }

        public string Customer_ID { get; set; }
        public string User_ID { get; set; }

        public List<invoiceData> allInvoice()
        {
            List<invoiceData> listData = new List<invoiceData> ();
            if (connect.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connect.Open ();

                    string selectData = "SELECT * FROM invoice";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader ();
                        while (reader.Read())
                        {
                            invoiceData InData = new invoiceData ();
                            InData.Invoice_Id = reader["invoice_id"].ToString ();
                            InData.TotalPrice = reader["total_price"].ToString();
                            InData.Amount = reader["amount"].ToString();
                            InData.Change = reader["change"].ToString();
                            InData.Date = reader["order_date"].ToString() ;
                            InData.Customer_ID= reader["customer_id"].ToString() ;
                            InData.User_ID = reader["user_id"].ToString();

                            listData.Add (InData);

                        }

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connect.Close ();
                }

            }
            return listData;



        }
        public List<invoiceData> allTodayInvoice()
        {
            List<invoiceData> listData = new List<invoiceData>();
            if (connect.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    DateTime today = DateTime.Today;

                    string selectData = "SELECT * FROM invoice WHERE order_date = @date";
                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@date", today);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            invoiceData InData = new invoiceData();
                            InData.Invoice_Id = reader["invoice_id"].ToString();
                            InData.TotalPrice = reader["total_price"].ToString();
                            InData.Amount = reader["amount"].ToString();
                            InData.Change = reader["change"].ToString();
                            InData.Date = reader["order_date"].ToString();
                            InData.Customer_ID = reader["customer_id"].ToString();
                            InData.User_ID = reader["user_id"].ToString();

                            listData.Add(InData);

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
            return listData;

        }
    }
}
