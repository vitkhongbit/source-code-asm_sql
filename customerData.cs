using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryManagementSystem
{
    class customerData
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True");

        public string Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }

        public List<customerData> allcustomer()
        {
            List<customerData> lisData = new List<customerData>();
            if (connect.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    connect.Open();
                    string selecData = "SELECT * FROM customer";
                    using (SqlCommand cmd = new SqlCommand(selecData,connect))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            customerData cusData = new customerData();
                            cusData.Id = reader["id"].ToString();
                            cusData.CustomerName = reader["customer_name"].ToString(); ;
                            cusData.CustomerPhone = reader["customer_phone"].ToString();

                            lisData.Add(cusData);
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
            return lisData;
        }
        
    }
}
