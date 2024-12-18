using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryManagementSystem
{
    public partial class addProduct : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True");
        public addProduct()
        {
            InitializeComponent();
            displayCategories();
            disPlayAllProducts();
        }

        public void disPlayAllProducts()
        {
            allProductData allProductData = new allProductData();
            List<allProductData> listData = allProductData.AllProductDatas();

            dataGridView1.DataSource = listData;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.jpg; *.png)| *.jpg; *.png";
                string imagePath = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    pictureProduct.ImageLocation = imagePath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool emtyFiles()
        {
            if (txt_productID.Text == "" || txt_productName.Text == "" || cb_category.SelectedIndex == -1 || txt_price.Text == "" || txt_stock.Text == "" || cb_status.SelectedIndex == -1)
            {
                return true;
            }
            else
            { return false; }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            if (emtyFiles())
            {
                MessageBox.Show("Please fill all the blank", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkConnection())
                {
                    try
                    {
                        connect.Open();

                        string checkProduct = "SELECT * FROM products WHERE prod_id = @prodID";

                        using (SqlCommand cmd = new SqlCommand(checkProduct, connect))
                        {
                            cmd.Parameters.AddWithValue("@prodID", txt_productID.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Product ID: " + txt_productID.Text.Trim() + " is existing", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                                string relativePath = Path.Combine("Product_Directory", txt_productID.Text.Trim() + ".jpg");
                                string path = Path.Combine(baseDirectory, relativePath);

                                string directoryPath = Path.GetDirectoryName(path);
                                if (!Directory.Exists(directoryPath))
                                {
                                    Directory.CreateDirectory(directoryPath);
                                }
                                File.Copy(pictureProduct.ImageLocation, path, true);

                                string insertData = "INSERT INTO products" +
                                    "(prod_id, prod_name, category, price, stock, image_path, status, date_insert)" +
                                    "VALUES( @prodID, @prodName, @cat, @price, @stock, @path, @status, @date)";
                                using (SqlCommand insertD = new SqlCommand(insertData, connect))
                                {
                                    insertD.Parameters.AddWithValue("@prodID", txt_productID.Text.Trim());
                                    insertD.Parameters.AddWithValue("@prodName", txt_productName.Text.Trim());
                                    insertD.Parameters.AddWithValue("@cat", cb_category.Text.Trim());
                                    insertD.Parameters.AddWithValue("@price", txt_price.Text.Trim());
                                    insertD.Parameters.AddWithValue("@stock", txt_stock.Text.Trim());
                                    insertD.Parameters.AddWithValue("@path", path);
                                    insertD.Parameters.AddWithValue("@status", cb_status.Text.Trim());

                                    DateTime today = DateTime.Today;
                                    insertD.Parameters.AddWithValue("@date", today);

                                    insertD.ExecuteNonQuery();
                                    clearFiles();
                                    disPlayAllProducts();
                                    MessageBox.Show("Added successfully!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
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
        }

        public void displayCategories()
        {
            if (checkConnection())
            {
                try
                {
                    connect.Open();

                    string selectData = "SELECT * FROM categories";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        SqlDataReader render = cmd.ExecuteReader();
                        if (render.HasRows)
                        {
                            while (render.Read())
                            {
                                cb_category.Items.Add(render["category"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    connect.Close();
                }
            }

        }

        public void clearFiles()
        {
            txt_productID.Text = "";
            txt_productName.Text = "";
            cb_category.SelectedIndex = -1;
            txt_price.Text = "";
            txt_stock.Text = "";
            cb_status.SelectedIndex = -1;
            pictureProduct.Image = null;
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearFiles();
        }

        private int getID = 0;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;

                txt_productID.Text = row.Cells[1].Value.ToString();
                txt_productName.Text = row.Cells[2].Value.ToString();
                cb_category.Text = row.Cells[3].Value.ToString();
                txt_price.Text = row.Cells[4].Value.ToString();
                txt_stock.Text = row.Cells[5].Value.ToString();

                string imagepath = row.Cells[6].Value.ToString();

                try
                {
                    if (imagepath != null)
                    {
                        pictureProduct.Image = Image.FromFile(imagepath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error image: " + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                cb_status.Text = row.Cells[7].Value.ToString();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (emtyFiles())
            {
                MessageBox.Show("Please fill all the blank", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure want to update Product ID: " + txt_productID.Text.Trim() + "?", "Confirm message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE products SET prod_id = @prodID, prod_name = @prodName, category = @cat, price = @price, stock = @stock, status = @status WHERE id = @id";

                            using (SqlCommand updateD = new SqlCommand(updateData, connect))
                            {
                                updateD.Parameters.AddWithValue("@prodID", txt_productID.Text.Trim());
                                updateD.Parameters.AddWithValue("@prodName", txt_productName.Text.Trim());
                                updateD.Parameters.AddWithValue("@cat", cb_category.Text.Trim());
                                updateD.Parameters.AddWithValue("@price", txt_price.Text.Trim());
                                updateD.Parameters.AddWithValue("@stock", txt_stock.Text.Trim());
                                updateD.Parameters.AddWithValue("@status", cb_status.Text.Trim());
                                updateD.Parameters.AddWithValue("@id", getID);


                                updateD.ExecuteNonQuery();
                                clearFiles();
                                disPlayAllProducts();
                                MessageBox.Show("Update successfully!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);


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

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (emtyFiles())
            {
                MessageBox.Show("Please fill all the blank", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure want to delete Product ID: " + txt_productID.Text.Trim() + "?", "Confirm message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            string deleteData = "DELETE FROM products WHERE id = @id";


                            using (SqlCommand deleteD = new SqlCommand(deleteData, connect))
                            {

                                deleteD.Parameters.AddWithValue("@id", getID);

                                deleteD.ExecuteNonQuery();
                                clearFiles();
                                disPlayAllProducts();
                                MessageBox.Show("Delete successfully!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
    }
}
