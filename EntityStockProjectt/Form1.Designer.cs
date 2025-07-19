namespace EntityStockProjectt
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnSearch = new Button();
			label1 = new Label();
			txtProductId = new TextBox();
			cbxCategory = new ComboBox();
			dataGridView1 = new DataGridView();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			txtProductName = new TextBox();
			txtStock = new TextBox();
			txtPrice = new TextBox();
			btnAdd = new Button();
			btnDelete = new Button();
			btnUpdate = new Button();
			btnList = new Button();
			txtCategory = new TextBox();
			label6 = new Label();
			btnCategoryAdd = new Button();
			btnCategoryDelete = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// btnSearch
			// 
			btnSearch.Location = new Point(347, 12);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(123, 29);
			btnSearch.TabIndex = 0;
			btnSearch.Text = "Ara";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
			label1.Location = new Point(12, 9);
			label1.Name = "label1";
			label1.Size = new Size(86, 28);
			label1.TabIndex = 1;
			label1.Text = "Ürün Id :";
			// 
			// txtProductId
			// 
			txtProductId.Location = new Point(104, 10);
			txtProductId.Name = "txtProductId";
			txtProductId.Size = new Size(149, 27);
			txtProductId.TabIndex = 2;
			// 
			// cbxCategory
			// 
			cbxCategory.FormattingEnabled = true;
			cbxCategory.Location = new Point(164, 77);
			cbxCategory.Name = "cbxCategory";
			cbxCategory.Size = new Size(151, 28);
			cbxCategory.TabIndex = 3;
			// 
			// dataGridView1
			// 
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(12, 202);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.Size = new Size(766, 236);
			dataGridView1.TabIndex = 4;
			dataGridView1.CellClick += dataGridView1_CellClick;
			dataGridView1.Click += dataGridView1_Click;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
			label2.Location = new Point(12, 40);
			label2.Name = "label2";
			label2.Size = new Size(99, 28);
			label2.TabIndex = 5;
			label2.Text = "Ürün Adı :";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
			label3.Location = new Point(1, 72);
			label3.Name = "label3";
			label3.Size = new Size(157, 28);
			label3.TabIndex = 6;
			label3.Text = "Ürün Kategorisi :";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
			label4.Location = new Point(12, 104);
			label4.Name = "label4";
			label4.Size = new Size(60, 28);
			label4.TabIndex = 7;
			label4.Text = "Stok :";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
			label5.Location = new Point(12, 132);
			label5.Name = "label5";
			label5.Size = new Size(63, 28);
			label5.TabIndex = 8;
			label5.Text = "Fiyat :";
			// 
			// txtProductName
			// 
			txtProductName.Location = new Point(117, 44);
			txtProductName.Name = "txtProductName";
			txtProductName.Size = new Size(149, 27);
			txtProductName.TabIndex = 9;
			// 
			// txtStock
			// 
			txtStock.Location = new Point(81, 106);
			txtStock.Name = "txtStock";
			txtStock.Size = new Size(149, 27);
			txtStock.TabIndex = 10;
			// 
			// txtPrice
			// 
			txtPrice.Location = new Point(81, 136);
			txtPrice.Name = "txtPrice";
			txtPrice.Size = new Size(149, 27);
			txtPrice.TabIndex = 11;
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(347, 47);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(123, 29);
			btnAdd.TabIndex = 12;
			btnAdd.Text = "Ekle";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnDelete
			// 
			btnDelete.Location = new Point(347, 82);
			btnDelete.Name = "btnDelete";
			btnDelete.Size = new Size(123, 29);
			btnDelete.TabIndex = 13;
			btnDelete.Text = "Sil";
			btnDelete.UseVisualStyleBackColor = true;
			btnDelete.Click += btnDelete_Click;
			// 
			// btnUpdate
			// 
			btnUpdate.Location = new Point(347, 117);
			btnUpdate.Name = "btnUpdate";
			btnUpdate.Size = new Size(123, 29);
			btnUpdate.TabIndex = 14;
			btnUpdate.Text = "Güncelle";
			btnUpdate.UseVisualStyleBackColor = true;
			btnUpdate.Click += btnUpdate_Click;
			// 
			// btnList
			// 
			btnList.Location = new Point(347, 152);
			btnList.Name = "btnList";
			btnList.Size = new Size(123, 29);
			btnList.TabIndex = 15;
			btnList.Text = "Listele";
			btnList.UseVisualStyleBackColor = true;
			btnList.Click += btnList_Click;
			// 
			// txtCategory
			// 
			txtCategory.Location = new Point(639, 40);
			txtCategory.Name = "txtCategory";
			txtCategory.Size = new Size(149, 27);
			txtCategory.TabIndex = 16;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
			label6.Location = new Point(476, 39);
			label6.Name = "label6";
			label6.Size = new Size(157, 28);
			label6.TabIndex = 17;
			label6.Text = "Ürün Kategorisi :";
			// 
			// btnCategoryAdd
			// 
			btnCategoryAdd.Location = new Point(665, 82);
			btnCategoryAdd.Name = "btnCategoryAdd";
			btnCategoryAdd.Size = new Size(123, 29);
			btnCategoryAdd.TabIndex = 18;
			btnCategoryAdd.Text = "Ekle";
			btnCategoryAdd.UseVisualStyleBackColor = true;
			btnCategoryAdd.Click += btnCategoryAdd_Click;
			// 
			// btnCategoryDelete
			// 
			btnCategoryDelete.Location = new Point(536, 82);
			btnCategoryDelete.Name = "btnCategoryDelete";
			btnCategoryDelete.Size = new Size(123, 29);
			btnCategoryDelete.TabIndex = 19;
			btnCategoryDelete.Text = "Sil";
			btnCategoryDelete.UseVisualStyleBackColor = true;
			btnCategoryDelete.Click += btnCategoryDelete_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnCategoryDelete);
			Controls.Add(btnCategoryAdd);
			Controls.Add(label6);
			Controls.Add(txtCategory);
			Controls.Add(btnList);
			Controls.Add(btnUpdate);
			Controls.Add(btnDelete);
			Controls.Add(btnAdd);
			Controls.Add(txtPrice);
			Controls.Add(txtStock);
			Controls.Add(txtProductName);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(dataGridView1);
			Controls.Add(cbxCategory);
			Controls.Add(txtProductId);
			Controls.Add(label1);
			Controls.Add(btnSearch);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnSearch;
		private Label label1;
		private TextBox txtProductId;
		private ComboBox cbxCategory;
		private DataGridView dataGridView1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private TextBox txtProductName;
		private TextBox txtStock;
		private TextBox txtPrice;
		private Button btnAdd;
		private Button btnDelete;
		private Button btnUpdate;
		private Button btnList;
		private TextBox txtCategory;
		private Label label6;
		private Button btnCategoryAdd;
		private Button btnCategoryDelete;
	}
}
