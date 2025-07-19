using Business.Abstract;
using Business.Concrete;
using DataAcces.Concrete;
using DataAcces.EntityFramework;
using Entity;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
namespace EntityStockProjectt
{
	public partial class Form1 : Form
	{
		private IProductService _productService;
		private ICategoryService _categoryService;
		public Form1()
		{
			InitializeComponent();
			_productService = new ProductManager(new EfProductDal(new Context()));
			_categoryService = new CategoryManager(new EfCategoryDal(new Context()));

		}

		

		private void UrunleriListele()
		{
			dataGridView1.DataSource = _productService.GetAll();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			UrunleriListele();
			cbxCategory.DataSource = _categoryService.GetAll();
			cbxCategory.DisplayMember = "CategoryName";
			cbxCategory.ValueMember = "CategoryId";
			txtProductId.ReadOnly = true;
		}

		private void btnSearch_Click(object sender, EventArgs e)
		{
			string searchText = txtProductName.Text.Trim();

			if (string.IsNullOrWhiteSpace(searchText))
			{
				MessageBox.Show("Lütfen aramak için bir ürün adý girin.");
				return;
			}

			var result = _productService.GetAll()
				.Where(p => p.ProductName != null && p.ProductName.Contains(searchText, StringComparison.OrdinalIgnoreCase))
				.ToList();

			if (result.Count > 0)
			{
				dataGridView1.DataSource = result;
			}
			else
			{
				MessageBox.Show("Eþleþen ürün bulunamadý.");
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtProductName.Text))
			{
				MessageBox.Show("Ürün adý boþ olamaz.");
				return;
			}

			if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
			{
				MessageBox.Show("Geçerli bir pozitif fiyat giriniz.");
				return;
			}

			if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
			{
				MessageBox.Show("Geçerli bir stok miktarý giriniz (0 veya daha büyük).");
				return;
			}

			if (cbxCategory.SelectedItem == null)
			{
				MessageBox.Show("Lütfen bir kategori seçin.");
				return;
			}
			try
			{
				var product = new Product
				{
					ProductName = txtProductName.Text,
					Price = Convert.ToDecimal(txtPrice.Text),
					Stock = Convert.ToInt32(txtStock.Text),
					Category = cbxCategory.Text 
				};

				_productService.Add(product);
				MessageBox.Show("Ürün baþarýyla eklendi.");
				UrunleriListele();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Hata: " + ex.Message);
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtProductId.Text))
			{
				MessageBox.Show("Lütfen güncellenecek bir ürün seçin.");
				return;
			}

			if (string.IsNullOrWhiteSpace(txtProductName.Text))
			{
				MessageBox.Show("Ürün adý boþ olamaz.");
				return;
			}

			if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
			{
				MessageBox.Show("Geçerli bir pozitif fiyat giriniz.");
				return;
			}

			if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
			{
				MessageBox.Show("Geçerli bir stok miktarý giriniz (0 veya daha büyük).");
				return;
			}

			if (cbxCategory.SelectedItem == null)
			{
				MessageBox.Show("Lütfen bir kategori seçin.");
				return;
			}
			if (!string.IsNullOrEmpty(txtProductId.Text))
			{
				int productId = int.Parse(txtProductId.Text);
				var product = _productService.GetById(productId);

				if (product != null)
				{
					_productService.Delete(product);
					MessageBox.Show("Ürün silindi.");
					UrunleriListele();
				}
				else
				{
					MessageBox.Show("Ürün bulunamadý.");
				}
			}
			else
			{
				MessageBox.Show("Lütfen silinecek bir ürün seçin.");
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtProductId.Text))
			{
				MessageBox.Show("Lütfen bir ürün seçin.");
				return;
			}

			if (string.IsNullOrWhiteSpace(txtProductName.Text))
			{
				MessageBox.Show("Ürün adý boþ olamaz.");
				return;
			}

			if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
			{
				MessageBox.Show("Geçerli bir fiyat girin.");
				return;
			}

			if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
			{
				MessageBox.Show("Geçerli bir stok miktarý girin.");
				return;
			}

			if (cbxCategory.SelectedItem == null)
			{
				MessageBox.Show("Kategori seçin.");
				return;
			}
			if (!string.IsNullOrEmpty(txtProductId.Text))
			{
				int productId = int.Parse(txtProductId.Text);
				var product = _productService.GetById(productId);

				if (product != null)
				{
					product.ProductName = txtProductName.Text;
					product.Price = decimal.Parse(txtPrice.Text);
					product.Stock = int.Parse(txtStock.Text);
					product.Category = cbxCategory.Text;

					_productService.Update(product);
					MessageBox.Show("Ürün güncellendi.");
					UrunleriListele();
				}
				else
				{
					MessageBox.Show("Güncellenecek ürün bulunamadý.");
				}
			}
			else
			{
				MessageBox.Show("Lütfen bir ürün seçin.");
			}
		}

		private void btnList_Click(object sender, EventArgs e)
		{
		  UrunleriListele();
		}

		private void btnCategoryDelete_Click(object sender, EventArgs e)
		{
			string categoryName = txtCategory.Text.Trim();

			if (!string.IsNullOrEmpty(categoryName))
			{
				// Adýna göre kategoriyi bul
				var category = _categoryService.GetAll().FirstOrDefault(c => c.CategoryName == categoryName);

				if (category != null)
				{
					_categoryService.Delete(category);
					MessageBox.Show("Kategori silindi.");

					// Combobox ve textbox güncelle
					cbxCategory.DataSource = _categoryService.GetAll();
					cbxCategory.DisplayMember = "CategoryName";
					cbxCategory.ValueMember = "CategoryId";
					txtCategory.Clear();
				}
				else
				{
					MessageBox.Show("Böyle bir kategori bulunamadý.");
				}
			}
			else
			{
				MessageBox.Show("Lütfen silinecek kategori adýný girin.");
			}
		}
		

		private void btnCategoryAdd_Click(object sender, EventArgs e)
		{
			try
			{
				var category = new Category
				{
					CategoryName = txtCategory.Text 
				};

				_categoryService.Add(category);
				MessageBox.Show("Kategori baþarýyla eklendi.");

				// Combobox'ý güncelle
				cbxCategory.DataSource = _categoryService.GetAll();
				cbxCategory.DisplayMember = "CategoryName";
				cbxCategory.ValueMember = "CategoryId";
			}
			catch (Exception ex)
			{
				MessageBox.Show("Hata: " + ex.Message);
			}
		}

		private void dataGridView1_Click(object sender, EventArgs e)
		{

		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

				txtProductId.Text = row.Cells["ProductId"].Value.ToString();
				txtProductName.Text = row.Cells["ProductName"].Value.ToString();
				txtPrice.Text = row.Cells["Price"].Value.ToString();
				txtStock.Text = row.Cells["Stock"].Value.ToString();

				
				string selectedCategoryName = row.Cells["Category"].Value.ToString();
				cbxCategory.SelectedIndex = cbxCategory.FindStringExact(selectedCategoryName);
			}
		}
	}
}
