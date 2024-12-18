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
    public partial class cashierOrder : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True");
        public cashierOrder()
        {
            InitializeComponent();
            displayOrder();
            displayAllAvalableProducts();
            displayAllCategories();
            displayTotalPrice();
        }

        public void displayOrder()
        {
            orderData oData = new orderData();
            List<orderData> listData = oData.allOrderdata();
            dataGridView2.DataSource = listData;
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            idGenerator();

            if (cb_category.SelectedIndex == -1 || cb_productId.SelectedIndex == -1 || cashierProductName.Text == "" || cashierPrice.Text == "" || cashierQuantity.Value == 0)
            {
                MessageBox.Show("select item first", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (checkconnection())
                {
                    try
                    {
                        connect.Open();

                        float getPrice = 0;
                        string selectOrder = "SELECT * FROM products WHERE prod_id = @prodID";

                        using (SqlCommand getOrder = new SqlCommand(selectOrder, connect))
                        {
                            getOrder.Parameters.AddWithValue("@prodID", cb_productId.SelectedItem);

                            using (SqlDataReader reader = getOrder.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    object rowValue = reader["price"];
                                    if (rowValue != DBNull.Value)
                                    {
                                        getPrice = Convert.ToSingle(rowValue);
                                    }
                                }
                            }
                        }

                        string insertData = "INSERT INTO orders VALUES(@prodID, @prodName, @cat, @qty, @origPrice, @totalPrice, @date, @invoice_id)";

                        using(SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@prodID", cb_productId.SelectedItem);
                            cmd.Parameters.AddWithValue("@prodName", cashierProductName.Text.Trim());
                            cmd.Parameters.AddWithValue("@cat", cb_category.SelectedItem);
                            cmd.Parameters.AddWithValue("@qty", cashierQuantity.Value);
                            cmd.Parameters.AddWithValue("origPrice", getPrice);

                            float totalP = (getPrice * (int)cashierQuantity.Value);

                            cmd.Parameters.AddWithValue("totalPrice", totalP);
                            DateTime today = DateTime.Today;
                            cmd.Parameters.AddWithValue("@date", today);
                            cmd.Parameters.AddWithValue("@invoice_id", iGen);

                            cmd.ExecuteNonQuery();
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed connection" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
            displayOrder();
            displayTotalPrice();
        }

        private int iGen;

        private void idGenerator()
        {
            using (SqlConnection connect  = new SqlConnection(@"Data Source=DESKTOP-3IGF319\SQLEXPRESS;Initial Catalog=inventory;Integrated Security=True;TrustServerCertificate=True"))
            {
                connect.Open();
                string selectData = "SELECT MAX(invoice_id) from invoice";

                using (SqlCommand cmd = new SqlCommand(selectData, connect))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int temp = Convert.ToInt32(result);

                        if (temp == 0)
                        {
                            iGen = 1;
                        }else
                        {
                            iGen = temp + 1;
                        }
                    }
                    else
                    {
                        iGen = 1;
                    }
                }
            }
        }

        public void displayAllAvalableProducts()
        {
            allProductData aData = new allProductData();
            List<allProductData> listData = aData.allAvailableProducts();

            dataGridView1.DataSource = listData;

        }

        public bool checkconnection()
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

        public void displayAllCategories()
        {
            if (checkconnection())
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT * FROM categories";

                    using (SqlCommand cmd = new SqlCommand(selectData, connect))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            cb_category.Items.Clear();
                            while (reader.Read())
                            {
                                string item = reader.GetString(1);
                                cb_category.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed connection" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        private void cb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_productId.SelectedIndex = -1;
            cb_productId.Items.Clear();
            cashierProductName.Text = "";
            cashierPrice.Text = "";

            string selectedValue = cb_category.SelectedItem as string;
            if (selectedValue != null)
            {
                if (checkconnection())
                {
                    try
                    {
                        connect.Open();
                        string selectData = @"
                    SELECT p.prod_id
                    FROM products p
                    INNER JOIN categories c ON p.category = c.category
                    WHERE c.category = @category AND p.status = @status";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@category", selectedValue);
                            cmd.Parameters.AddWithValue("@status", "Available");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                cb_productId.Items.Clear();
                                while (reader.Read())
                                {
                                    cb_productId.Items.Add(reader["prod_id"].ToString());
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed connection" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private float totalPrice = 0;
        public void displayTotalPrice()
        {
            idGenerator();
            if(checkconnection())
            {
                try
                {
                    connect.Open();
                    string selectData = "SELECT SUM(total_price) FROM orders WHERE invoice_id = @iID";

                    using (SqlCommand cmd = new SqlCommand( selectData, connect))
                    {
                        cmd.Parameters.AddWithValue ("@iID", iGen);

                        object resutl = cmd.ExecuteScalar();

                        if (resutl != DBNull.Value)
                        {
                            totalPrice = Convert.ToSingle(resutl);
                            cashierTotalPrice.Text = totalPrice.ToString("0.00");
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Failed connection" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    connect.Close() ;
                }
            }
        }

        private void cb_productId_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = cb_productId.SelectedItem as string;
            if (checkconnection())
            {
                if (selectedValue != null)
                {
                    try
                    {
                        connect.Open();
                        string selectData = $"SELECT * FROM products where prod_id = '{selectedValue}' AND status = @status";

                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@status", "Available");
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    string prodName = reader["prod_name"].ToString();
                                    float prodPrice = Convert.ToSingle(reader["price"]);

                                    cashierProductName.Text = prodName;
                                    cashierPrice.Text = prodPrice.ToString("0.00");

                                }
                            }

                        }


                    }catch(Exception ex)
                    {
                        MessageBox.Show("Failed connection" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        connect.Close();
                    }
                }
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (prodID == 0)
            {
                MessageBox.Show("Select item first", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else
            {
                if (MessageBox.Show("Are you sure want to remove ID: " + prodID + "?","Confirm message", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (checkconnection())
                    {
                        try
                        {
                            connect.Open();
                            string deleteData = "DELETE FROM orders WHERE ID = @id";

                            using (SqlCommand cmd = new SqlCommand(deleteData, connect))
                            {
                                cmd.Parameters.AddWithValue("@id" , prodID);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Removed successfully", "Information message", MessageBoxButtons.OK, MessageBoxIcon.Information );
                            }

                        }catch(Exception ex)
                        {
                            MessageBox.Show("Failed connection" + ex, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            connect.Close();
                        }
                    }
                }
            }

            displayOrder();
            displayTotalPrice();
        }
        private int prodID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                prodID = (int)row.Cells[0].Value;
            }
        }

        public void clearFile()
        {
            cb_category.SelectedIndex = -1;
            cb_productId.SelectedIndex = -1;
            cashierProductName.Text = "";
            cashierPrice.Text = "";
            cashierQuantity.Value = 0;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            clearFile();
        }

        private void btn_payOrder_Click(object sender, EventArgs e)
        {
            int userId = USERID.userId;

            // Kiểm tra thông tin khách hàng
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show("Fill in customer information first", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cashierAmount.Text == "" || dataGridView2.Rows.Count <= 0)
            {
                MessageBox.Show("Invalid order details", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure to pay the orders?", "Confirm message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            if (checkconnection())
            {
                try
                {
                    connect.Open();

                    // Kiểm tra khách hàng
                    string checkCustomer = "SELECT id FROM customer WHERE customer_phone = @cusPhone";
                    int customerId;
                    using (SqlCommand cmd = new SqlCommand(checkCustomer, connect))
                    {
                        cmd.Parameters.AddWithValue("@cusPhone", txtPhone.Text);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            customerId = Convert.ToInt32(result);
                        }
                        else
                        {
                            // Chèn khách hàng mới nếu chưa tồn tại
                            string insertCustomer = "INSERT INTO customer (customer_name, customer_phone) VALUES (@cusName, @cusPhone); SELECT SCOPE_IDENTITY();";
                            using (SqlCommand insert = new SqlCommand(insertCustomer, connect))
                            {
                                insert.Parameters.AddWithValue("@cusName", txtCustomerName.Text);
                                insert.Parameters.AddWithValue("@cusPhone", txtPhone.Text);
                                customerId = Convert.ToInt32(insert.ExecuteScalar());
                            }
                        }
                    }

                    // Chèn hóa đơn
                    string insertInvoice = "INSERT INTO invoice  " +
                                           "VALUES (@invoiceId, @totalPrice, @amount, @change, @orderDate, @customerId, @userId)";
                    using (SqlCommand cmd2 = new SqlCommand(insertInvoice, connect))
                    {
                        cmd2.Parameters.AddWithValue("@invoiceId", iGen);
                        cmd2.Parameters.AddWithValue("@totalPrice", cashierTotalPrice.Text);
                        cmd2.Parameters.AddWithValue("@amount", cashierAmount.Text);
                        cmd2.Parameters.AddWithValue("@change", cashierChange.Text);
                        cmd2.Parameters.AddWithValue("@orderDate", DateTime.Today);
                        cmd2.Parameters.AddWithValue("@customerId", customerId);
                        cmd2.Parameters.AddWithValue("@userId", userId);
                        cmd2.ExecuteNonQuery();
                        clearFile();
                    }

                    // Xóa dữ liệu giao diện sau khi thanh toán
                    clearFile();
                    MessageBox.Show("Paid successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed connection: " + ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connect.Close();
                }
            }
            displayTotalPrice();
            cashierAmount.Text = "";
            cashierChange.Text = "";
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void cashierAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                try
                {
                    float getAmount = Convert.ToSingle(cashierAmount.Text);
                    float getChange = (getAmount - totalPrice);

                    if (getChange <= -1)
                    {
                        cashierAmount.Text = "";
                        cashierChange.Text = "";
                    }else
                    {
                        cashierChange.Text = getChange.ToString("0.00");
                    }

                }catch(Exception ex)
                {
                    MessageBox.Show("Some thing wrong: " + ex.Message, "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cashierAmount.Text = "";
                    cashierChange.Text = "";
                }
               
            }
        }

        private void cashierTotalPrice_Click(object sender, EventArgs e)
        {

        }
    }
}
