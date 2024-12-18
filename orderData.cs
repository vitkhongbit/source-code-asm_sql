using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventoryManagementSystem
{
    class orderData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True");

        public int Id {  get; set; }
        public string InvoiceID { get; set; }
        public string ProdID { set; get; }
        public string ProdName { set; get; }
        public string Category { set; get; }
        public string Qty {  set; get; }
        public string OrigPrice {  set; get; }
        public string TotalPrice { set; get; }
        public string Date { set; get; }

        public List<orderData> allOrderdata()
        {
            List<orderData> listData = new List<orderData> ();

            if (connect.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connect.Open ();
                    int invoiceID = 0;
                    string selectInvoiceData = "SELECT MAX(invoice_id) FROM orders";

                    using (SqlCommand cmd = new SqlCommand(selectInvoiceData,connect))
                    {
                        object result = cmd.ExecuteScalar();

                        if (result != DBNull.Value)
                        {
                            int temp = Convert.ToInt32(result);

                            if (temp == 0)
                            {
                                invoiceID = 1;
                            }
                            else
                            {
                                invoiceID = temp;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error id:");
                        }
                    }

                    string selectData = "SELECT * FROM orders WHERE invoice_id = @iID";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@iID", invoiceID);
                        
                        SqlDataReader reader = cmd.ExecuteReader ();

                        while ((reader.Read()))
                        {
                            orderData oData = new orderData ();
                            oData.Id = (int)reader["id"];
                            oData.InvoiceID = reader["invoice_id"].ToString();
                            oData.ProdID = reader["prod_id"].ToString ();
                            oData.ProdName = reader["prod_name"].ToString ();
                            oData.Category = reader["category"].ToString ();
                            oData.Qty = reader["qty"].ToString();
                            oData.OrigPrice = reader["orig_price"].ToString ();
                            oData.TotalPrice = reader["total_price"].ToString ();
                            oData.Date = reader["order_date"].ToString ();

                            listData.Add (oData);
                        }
                    }



                }catch(Exception ex)
                {
                    Console.WriteLine("connection fail: " + ex);
                }finally
                {
                    connect.Close ();
                }
            }
            return listData;
        }
    }
}
