using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace inventoryManagementSystem
{
    internal class categoriesData
    {
        public int ID { set; get; }
        public string Category { set; get; }
        public string Date { set; get; }

        public List<categoriesData> allCategoriesData()
        {
            List<categoriesData> listData = new List<categoriesData>();
            using (SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();
                string selectData = "SELECT * FROM categories";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        categoriesData cData = new categoriesData();

                        cData.ID = (int)reader["ID"];
                        cData.Category = reader["Category"].ToString();
                        cData.Date = reader["date"].ToString();

                        listData.Add(cData);
                       
                    }
                }
            }
            return listData;
        }
    }
}
