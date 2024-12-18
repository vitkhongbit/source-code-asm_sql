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
    public partial class addUser : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True");

        public void displayAllUserData()
        {
            userData uData = new userData();

            List<userData> listData = uData.allUserData();

            dataGridView_User.DataSource = listData;
        }

        public bool checkConnection()
        {
            if (connect.State == ConnectionState.Closed)
            {
                return true;
            }else
            {
                return false;
            }
        }
        public addUser()
        {
            InitializeComponent();
            displayAllUserData();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
            if (txt_userName.Text == "" || txt_userPassword.Text == "" || userRole.Text == "" || userStatus.Text == "")
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

                        string checkUserName = "SELECT * FROM users WHERE username = @userN";
                        using (SqlCommand cmd = new SqlCommand(checkUserName, connect))
                        {
                            cmd.Parameters.AddWithValue("@userN", txt_userName.Text.Trim());
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count > 0)
                            {
                                MessageBox.Show(txt_userName.Text.Trim() + "Is already taken", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }else
                            {
                                string insertData = "INSERT INTO users (username, password, role, status, date, isChangePassWord)" +
                                    "VALUES (@usern, @pass, @role, @status, @date, 0)";
                                using (SqlCommand inserD = new SqlCommand(insertData, connect))
                                {
                                    inserD.Parameters.AddWithValue("@usern", txt_userName.Text.Trim());
                                    inserD.Parameters.AddWithValue("@pass", txt_userPassword.Text.Trim());
                                    inserD.Parameters.AddWithValue("@role", userRole.SelectedItem.ToString());
                                    inserD.Parameters.AddWithValue("@status", userStatus.SelectedItem.ToString());
                                    DateTime today = DateTime.Today;
                                    inserD.Parameters.AddWithValue("@date", today);

                                    inserD.ExecuteNonQuery();

                                    clear();
                                    displayAllUserData();
                                    MessageBox.Show("Added succedfully" , "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void clear()
        {
            txt_userName.Text = "";
            txt_userPassword.Text = "";
            userRole.SelectedIndex = -1;
            userStatus.SelectedIndex = -1;
        }

        private void btn_clearUser_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btn_updateUser_Click(object sender, EventArgs e)
        {
            if (txt_userName.Text == "" || txt_userPassword.Text == "" || userRole.Text == "" || userStatus.Text == "")
            {
                MessageBox.Show("Please fill all the blank", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure want to update user ID:" + getID +"?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                
                if (checkConnection())
                {

                    try
                    {
                        connect.Open();

                        string updateData = "UPDATE users SET username = @user," 
                                    + "password = @pass, role = @role, status = @status WHERE id = @id";

                        using (SqlCommand updateD = new SqlCommand(updateData, connect))
                        {
                                    updateD.Parameters.AddWithValue("@user", txt_userName.Text.Trim());
                                    updateD.Parameters.AddWithValue("@pass", txt_userPassword.Text.Trim());
                                    updateD.Parameters.AddWithValue("@role", userRole.SelectedItem);
                                    updateD.Parameters.AddWithValue("@status", userStatus.SelectedItem);
                                    updateD.Parameters.AddWithValue("@id", getID );

                        updateD.ExecuteNonQuery();
                        clear();

                        displayAllUserData();
                        MessageBox.Show("Updated successfully" , "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private int getID = 0;

        private void dataGridView_User_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView_User.Rows[e.RowIndex];

                getID = (int)row.Cells[0].Value;
                string username = row.Cells[1].Value.ToString();
                string password = row.Cells[2].Value.ToString();
                string role = row.Cells[3].Value.ToString();
                string status = row.Cells[4].Value.ToString();

                txt_userName.Text = username;
                txt_userPassword.Text = password;
                userRole.Text = role;   
                userStatus.Text = status;
            }
        }

        private void btn_removeUser_Click(object sender, EventArgs e)
        {
            if (txt_userName.Text == "" || txt_userPassword.Text == "" || userRole.Text == "" || userStatus.Text == "")
            {
                MessageBox.Show("Please fill all the blank", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Are you sure want to remove user ID:" + getID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

                    if (checkConnection())
                    {

                        try
                        {
                            connect.Open();

                            string removeData = "DELETE FROM users WHERE id = @id";

                            using (SqlCommand removeD = new SqlCommand(removeData, connect))
                            {
                                
                                removeD.Parameters.AddWithValue("@id", getID);

                                removeD.ExecuteNonQuery();
                                clear();

                                displayAllUserData();
                                MessageBox.Show("Removed successfully", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void addUser_Load(object sender, EventArgs e)
        {

        }

        private void userRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
