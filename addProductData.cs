using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace inventoryManagementSystem
{
    internal class allProductData
    {
        public int ID { get; set; }
        public string ProdID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        public string ImagePath { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }

        public List<allProductData> AllProductDatas()
        {
            List<allProductData> lisData = new List<allProductData>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                string selectData = "SELECT * FROM products";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    SqlDataReader render = cmd.ExecuteReader();
                    while (render.Read())
                    {
                        allProductData aData = new allProductData();
                        aData.ID = (int)render["id"];
                        aData.ProdID = render["prod_id"].ToString();
                        aData.ProductName = render["prod_name"].ToString();
                        aData.Category = render["category"].ToString();
                        aData.Price = render["price"].ToString();
                        aData.Stock = render["stock"].ToString();
                        aData.ImagePath = render["image_path"].ToString();
                        aData.Status = render["status"].ToString();
                        aData.Date = render["date_insert"].ToString();

                        lisData .Add(aData);
                    }
                }
            }
            return lisData;

        }

        public List<allProductData> allAvailableProducts()
        {
            List<allProductData> lisData = new List<allProductData>();

            using (SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();

                string selectData = "SELECT * FROM products WHERE status = @status";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    cmd.Parameters.AddWithValue("@status", "Available");
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        allProductData aData = new allProductData();
                        aData.ID = (int)reader["id"];
                        aData.ProdID = reader["prod_id"].ToString();
                        aData.ProductName = reader["prod_name"].ToString();
                        aData.Category = reader["category"].ToString();
                        aData.Price = reader["price"].ToString();
                        aData.Stock = reader["stock"].ToString();
                        aData.ImagePath = reader["image_path"].ToString();
                        aData.Status = reader["status"].ToString();
                        aData.Date = reader["date_insert"].ToString();

                        lisData.Add(aData);
                    }
                }
            }
            return lisData;
        }
    }
}
