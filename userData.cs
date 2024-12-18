using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inventoryManagementSystem
{
    internal class userData
    {
        public int ID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }    
        public string Role { set; get; }
        public string Status { set; get; }
        public string Date {  set; get; }

        public List<userData> allUserData()
        {
            List<userData> listData = new List<userData>();
            using (SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();
                string selectData = "SELECT * FROM users";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        userData uData = new userData();

                        uData.ID = (int)reader["id"];
                        uData.Username = reader["username"].ToString();
                        uData.Password = reader["password"].ToString();
                        uData.Role = reader["role"].ToString();
                        uData.Status = reader["status"].ToString();
                        uData.Date = reader["date"].ToString();

                        listData.Add(uData);

                    }
                }
            }
            return listData;
        }

    }
}
