namespace inventoryManagementSystem
{
    partial class addUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_clearUser = new System.Windows.Forms.Button();
            this.btn_updateUser = new System.Windows.Forms.Button();
            this.btn_removeUser = new System.Windows.Forms.Button();
            this.btn_addUser = new System.Windows.Forms.Button();
            this.userStatus = new System.Windows.Forms.ComboBox();
            this.userRole = new System.Windows.Forms.ComboBox();
            this.txt_userPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_userName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_User = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_User)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_clearUser);
            this.panel1.Controls.Add(this.btn_updateUser);
            this.panel1.Controls.Add(this.btn_removeUser);
            this.panel1.Controls.Add(this.btn_addUser);
            this.panel1.Controls.Add(this.userStatus);
            this.panel1.Controls.Add(this.userRole);
            this.panel1.Controls.Add(this.txt_userPassword);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_userName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(6, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 606);
            this.panel1.TabIndex = 0;
            // 
            // btn_clearUser
            // 
            this.btn_clearUser.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_clearUser.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clearUser.ForeColor = System.Drawing.Color.White;
            this.btn_clearUser.Location = new System.Drawing.Point(166, 407);
            this.btn_clearUser.Name = "btn_clearUser";
            this.btn_clearUser.Size = new System.Drawing.Size(116, 40);
            this.btn_clearUser.TabIndex = 4;
            this.btn_clearUser.Text = "Clear";
            this.btn_clearUser.UseVisualStyleBackColor = false;
            this.btn_clearUser.Click += new System.EventHandler(this.btn_clearUser_Click);
            // 
            // btn_updateUser
            // 
            this.btn_updateUser.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_updateUser.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updateUser.ForeColor = System.Drawing.Color.White;
            this.btn_updateUser.Location = new System.Drawing.Point(166, 349);
            this.btn_updateUser.Name = "btn_updateUser";
            this.btn_updateUser.Size = new System.Drawing.Size(116, 40);
            this.btn_updateUser.TabIndex = 4;
            this.btn_updateUser.Text = "Update";
            this.btn_updateUser.UseVisualStyleBackColor = false;
            this.btn_updateUser.Click += new System.EventHandler(this.btn_updateUser_Click);
            // 
            // btn_removeUser
            // 
            this.btn_removeUser.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_removeUser.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_removeUser.ForeColor = System.Drawing.Color.White;
            this.btn_removeUser.Location = new System.Drawing.Point(24, 407);
            this.btn_removeUser.Name = "btn_removeUser";
            this.btn_removeUser.Size = new System.Drawing.Size(116, 40);
            this.btn_removeUser.TabIndex = 3;
            this.btn_removeUser.Text = "Remove";
            this.btn_removeUser.UseVisualStyleBackColor = false;
            this.btn_removeUser.Click += new System.EventHandler(this.btn_removeUser_Click);
            // 
            // btn_addUser
            // 
            this.btn_addUser.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_addUser.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addUser.ForeColor = System.Drawing.Color.White;
            this.btn_addUser.Location = new System.Drawing.Point(24, 349);
            this.btn_addUser.Name = "btn_addUser";
            this.btn_addUser.Size = new System.Drawing.Size(116, 40);
            this.btn_addUser.TabIndex = 3;
            this.btn_addUser.Text = "Add";
            this.btn_addUser.UseVisualStyleBackColor = false;
            this.btn_addUser.Click += new System.EventHandler(this.btn_addUser_Click);
            // 
            // userStatus
            // 
            this.userStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userStatus.FormattingEnabled = true;
            this.userStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive",
            "Approval"});
            this.userStatus.Location = new System.Drawing.Point(24, 259);
            this.userStatus.Name = "userStatus";
            this.userStatus.Size = new System.Drawing.Size(258, 28);
            this.userStatus.TabIndex = 2;
            // 
            // userRole
            // 
            this.userRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userRole.FormattingEnabled = true;
            this.userRole.Items.AddRange(new object[] {
            "Admin",
            "Sales",
            "WareHouse"});
            this.userRole.Location = new System.Drawing.Point(24, 196);
            this.userRole.Name = "userRole";
            this.userRole.Size = new System.Drawing.Size(258, 28);
            this.userRole.TabIndex = 2;
            this.userRole.SelectedIndexChanged += new System.EventHandler(this.userRole_SelectedIndexChanged);
            // 
            // txt_userPassword
            // 
            this.txt_userPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userPassword.Location = new System.Drawing.Point(24, 132);
            this.txt_userPassword.Name = "txt_userPassword";
            this.txt_userPassword.Size = new System.Drawing.Size(258, 26);
            this.txt_userPassword.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(20, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Role:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txt_userName
            // 
            this.txt_userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_userName.Location = new System.Drawing.Point(24, 63);
            this.txt_userName.Name = "txt_userName";
            this.txt_userName.Size = new System.Drawing.Size(258, 26);
            this.txt_userName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridView_User);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(326, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 606);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView_User
            // 
            this.dataGridView_User.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_User.Location = new System.Drawing.Point(16, 44);
            this.dataGridView_User.Name = "dataGridView_User";
            this.dataGridView_User.RowHeadersVisible = false;
            this.dataGridView_User.Size = new System.Drawing.Size(592, 546);
            this.dataGridView_User.TabIndex = 2;
            this.dataGridView_User.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_User_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "All user\'s data";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // addUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 630);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addUser";
            this.Text = "addUser";
            this.Load += new System.EventHandler(this.addUser_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_User)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox userStatus;
        private System.Windows.Forms.ComboBox userRole;
        private System.Windows.Forms.TextBox txt_userPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_userName;
        private System.Windows.Forms.Button btn_clearUser;
        private System.Windows.Forms.Button btn_updateUser;
        private System.Windows.Forms.Button btn_removeUser;
        private System.Windows.Forms.Button btn_addUser;
        private System.Windows.Forms.DataGridView dataGridView_User;
    }
}