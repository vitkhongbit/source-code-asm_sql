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
    public partial class Form1 : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True");

        public bool checkConnection()
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
            }
            return connect.State == ConnectionState.Open;
            
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cb_showPassword_CheckedChanged(object sender, EventArgs e)
        {
            txt_password.PasswordChar = cb_showPassword.Checked ? '\0' : '*';
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_userName.Text == "" || txt_password.Text == "")
            {
                MessageBox.Show("Please fill all the blank", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (checkConnection())
            {
                try
                {
                    
                    string selectData = "SELECT id, role FROM users WHERE username = @user AND password = @pass AND status = @status";

                    using(SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        cmd.Parameters.AddWithValue("@user", txt_userName.Text.Trim());
                        cmd.Parameters.AddWithValue("@pass", txt_password.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", "Active");

                        using( SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                USERID.userId = reader.GetInt32(0);
                                string userRole = reader.GetString(1).Trim();

                                switch (userRole)
                                {
                                    case "Admin":
                                        mainForm mform = new mainForm();
                                        mform.Show();
                                        this.Hide();
                                        break;

                                    case "Sales":
                                        cashierMainForm cashierMainForm = new cashierMainForm();
                                        cashierMainForm.Show();
                                        this.Hide();
                                        break;

                                    case "WareHouse":
                                        wareHouseMainForm wareHouseMainForm = new wareHouseMainForm();
                                        wareHouseMainForm.Show();
                                        this.Hide();
                                        break;

                                    default:
                                        MessageBox.Show("Role not recongnized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                }
                                MessageBox.Show("Login successfuly!", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Incorrect username or password", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        
                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection failed!"+ ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connect.Close();
                }
            }
            else
            {
                MessageBox.Show("Unable to establish a connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
