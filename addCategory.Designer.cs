namespace inventoryManagementSystem
{
    partial class addCategory
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
            this.dataGridView_Category = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_clearCategory = new System.Windows.Forms.Button();
            this.btn_updateCategory = new System.Windows.Forms.Button();
            this.btn_removeCategory = new System.Windows.Forms.Button();
            this.btn_addCategory = new System.Windows.Forms.Button();
            this.txt_category = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Category)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Category
            // 
            this.dataGridView_Category.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Category.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Category.Location = new System.Drawing.Point(16, 44);
            this.dataGridView_Category.Name = "dataGridView_Category";
            this.dataGridView_Category.RowHeadersVisible = false;
            this.dataGridView_Category.Size = new System.Drawing.Size(592, 546);
            this.dataGridView_Category.TabIndex = 2;
            this.dataGridView_Category.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Category_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_clearCategory);
            this.panel1.Controls.Add(this.btn_updateCategory);
            this.panel1.Controls.Add(this.btn_removeCategory);
            this.panel1.Controls.Add(this.btn_addCategory);
            this.panel1.Controls.Add(this.txt_category);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(309, 606);
            this.panel1.TabIndex = 2;
            // 
            // btn_clearCategory
            // 
            this.btn_clearCategory.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_clearCategory.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clearCategory.ForeColor = System.Drawing.Color.White;
            this.btn_clearCategory.Location = new System.Drawing.Point(166, 280);
            this.btn_clearCategory.Name = "btn_clearCategory";
            this.btn_clearCategory.Size = new System.Drawing.Size(116, 40);
            this.btn_clearCategory.TabIndex = 4;
            this.btn_clearCategory.Text = "Clear";
            this.btn_clearCategory.UseVisualStyleBackColor = false;
            this.btn_clearCategory.Click += new System.EventHandler(this.btn_clearCategory_Click);
            // 
            // btn_updateCategory
            // 
            this.btn_updateCategory.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_updateCategory.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updateCategory.ForeColor = System.Drawing.Color.White;
            this.btn_updateCategory.Location = new System.Drawing.Point(166, 222);
            this.btn_updateCategory.Name = "btn_updateCategory";
            this.btn_updateCategory.Size = new System.Drawing.Size(116, 40);
            this.btn_updateCategory.TabIndex = 4;
            this.btn_updateCategory.Text = "Update";
            this.btn_updateCategory.UseVisualStyleBackColor = false;
            this.btn_updateCategory.Click += new System.EventHandler(this.btn_updateCategory_Click);
            // 
            // btn_removeCategory
            // 
            this.btn_removeCategory.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_removeCategory.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_removeCategory.ForeColor = System.Drawing.Color.White;
            this.btn_removeCategory.Location = new System.Drawing.Point(24, 280);
            this.btn_removeCategory.Name = "btn_removeCategory";
            this.btn_removeCategory.Size = new System.Drawing.Size(116, 40);
            this.btn_removeCategory.TabIndex = 3;
            this.btn_removeCategory.Text = "Remove";
            this.btn_removeCategory.UseVisualStyleBackColor = false;
            this.btn_removeCategory.Click += new System.EventHandler(this.btn_removeCategory_Click);
            // 
            // btn_addCategory
            // 
            this.btn_addCategory.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_addCategory.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addCategory.ForeColor = System.Drawing.Color.White;
            this.btn_addCategory.Location = new System.Drawing.Point(24, 222);
            this.btn_addCategory.Name = "btn_addCategory";
            this.btn_addCategory.Size = new System.Drawing.Size(116, 40);
            this.btn_addCategory.TabIndex = 3;
            this.btn_addCategory.Text = "Add";
            this.btn_addCategory.UseVisualStyleBackColor = false;
            this.btn_addCategory.Click += new System.EventHandler(this.btn_addUser_Click);
            // 
            // txt_category
            // 
            this.txt_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_category.Location = new System.Drawing.Point(24, 142);
            this.txt_category.Name = "txt_category";
            this.txt_category.Size = new System.Drawing.Size(258, 26);
            this.txt_category.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dataGridView_Category);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(329, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 606);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "All category";
            // 
            // addCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 630);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addCategory";
            this.Text = "addCategory";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Category)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Category;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_clearCategory;
        private System.Windows.Forms.Button btn_updateCategory;
        private System.Windows.Forms.Button btn_removeCategory;
        private System.Windows.Forms.Button btn_addCategory;
        private System.Windows.Forms.TextBox txt_category;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
    }
}