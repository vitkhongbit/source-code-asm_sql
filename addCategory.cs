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
    public partial class addCategory : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True");
        public addCategory()
        {
            InitializeComponent();

            displayCategoriesData();
        }

        public void displayCategoriesData()
        {
            categoriesData cData = new categoriesData();
            List<categoriesData> listData = cData.allCategoriesData();

            dataGridView_Category.DataSource = listData;
        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
            if (txt_category.Text == "")
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
                        string checkCat = "SELECT * FROM categories WHERE category = @cat";

                        using (SqlCommand cmd = new SqlCommand(checkCat, connect))
                        {
                            cmd.Parameters.AddWithValue("@cat", txt_category.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show("Category:" + txt_category.Text.Trim() + "is already exist", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                            else
                            {
                                string insertData = "INSERT INTO categories (category, date) VALUES(@cat, @date)";
                                using (SqlCommand insertD = new SqlCommand(insertData, connect))
                                {
                                    insertD.Parameters.AddWithValue("@cat", txt_category.Text.Trim());
                                    DateTime today = DateTime.Today;
                                    insertD.Parameters.AddWithValue("@date", today);

                                    insertD.ExecuteNonQuery();
                                    clearFields();
                                    displayCategoriesData();

                                    MessageBox.Show("Added successfully", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public bool checkConnection()
        {
            if (connect.State == ConnectionState.Closed)
            {
                return true;
            }
            else
                return false;
        }

        private void btn_clearCategory_Click(object sender, EventArgs e)
        {
            clearFields();
        }
        
        public void clearFields()
        {
            txt_category.Text = "";
        }

        private int getID = 0;

        private void dataGridView_Category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView_Category.Rows[e.RowIndex];
                getID = (int)row.Cells["ID"].Value;

                txt_category.Text = row.Cells[1].Value.ToString();
            }

        }

        private void btn_updateCategory_Click(object sender, EventArgs e)
        {
            if (txt_category.Text == "")
            {
                MessageBox.Show("Please fill all the blank", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure want to update category ID:" + getID+ "?","Confirmatin message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            string updateData = "UPDATE categories SET category = @cat where id = @id";
                            using (SqlCommand insertD = new SqlCommand(updateData, connect))
                            {
                                insertD.Parameters.AddWithValue("@cat", txt_category.Text.Trim());
                                insertD.Parameters.AddWithValue("@id", getID);

                                insertD.ExecuteNonQuery();
                                clearFields();
                                displayCategoriesData();

                                MessageBox.Show("Updated successfully", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_removeCategory_Click(object sender, EventArgs e)
        {
            if (txt_category.Text == "")
            {
                MessageBox.Show("Please fill all the blank", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure want to remove category ID:" + getID + "?", "Confirmatin message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkConnection())
                    {
                        try
                        {
                            connect.Open();

                            string removeeData = "DELETE FROM categories WHERE id = @id";
                            using (SqlCommand deleteD = new SqlCommand(removeeData, connect))
                            {
                                deleteD.Parameters.AddWithValue("@id", getID);

                                deleteD.ExecuteNonQuery();
                                clearFields();
                                displayCategoriesData();

                                MessageBox.Show("Removed successfully", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Connection failed" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            connect.Close() ;
                        }
                    }
                }
            }
        }
    }           
        
 }   
