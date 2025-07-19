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
				MessageBox.Show("L�tfen aramak i�in bir �r�n ad� girin.");
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
				MessageBox.Show("E�le�en �r�n bulunamad�.");
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtProductName.Text))
			{
				MessageBox.Show("�r�n ad� bo� olamaz.");
				return;
			}

			if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
			{
				MessageBox.Show("Ge�erli bir pozitif fiyat giriniz.");
				return;
			}

			if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
			{
				MessageBox.Show("Ge�erli bir stok miktar� giriniz (0 veya daha b�y�k).");
				return;
			}

			if (cbxCategory.SelectedItem == null)
			{
				MessageBox.Show("L�tfen bir kategori se�in.");
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
				MessageBox.Show("�r�n ba�ar�yla eklendi.");
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
				MessageBox.Show("L�tfen g�ncellenecek bir �r�n se�in.");
				return;
			}

			if (string.IsNullOrWhiteSpace(txtProductName.Text))
			{
				MessageBox.Show("�r�n ad� bo� olamaz.");
				return;
			}

			if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
			{
				MessageBox.Show("Ge�erli bir pozitif fiyat giriniz.");
				return;
			}

			if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
			{
				MessageBox.Show("Ge�erli bir stok miktar� giriniz (0 veya daha b�y�k).");
				return;
			}

			if (cbxCategory.SelectedItem == null)
			{
				MessageBox.Show("L�tfen bir kategori se�in.");
				return;
			}
			if (!string.IsNullOrEmpty(txtProductId.Text))
			{
				int productId = int.Parse(txtProductId.Text);
				var product = _productService.GetById(productId);

				if (product != null)
				{
					_productService.Delete(product);
					MessageBox.Show("�r�n silindi.");
					UrunleriListele();
				}
				else
				{
					MessageBox.Show("�r�n bulunamad�.");
				}
			}
			else
			{
				MessageBox.Show("L�tfen silinecek bir �r�n se�in.");
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtProductId.Text))
			{
				MessageBox.Show("L�tfen bir �r�n se�in.");
				return;
			}

			if (string.IsNullOrWhiteSpace(txtProductName.Text))
			{
				MessageBox.Show("�r�n ad� bo� olamaz.");
				return;
			}

			if (!decimal.TryParse(txtPrice.Text, out decimal price) || price < 0)
			{
				MessageBox.Show("Ge�erli bir fiyat girin.");
				return;
			}

			if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
			{
				MessageBox.Show("Ge�erli bir stok miktar� girin.");
				return;
			}

			if (cbxCategory.SelectedItem == null)
			{
				MessageBox.Show("Kategori se�in.");
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
					MessageBox.Show("�r�n g�ncellendi.");
					UrunleriListele();
				}
				else
				{
					MessageBox.Show("G�ncellenecek �r�n bulunamad�.");
				}
			}
			else
			{
				MessageBox.Show("L�tfen bir �r�n se�in.");
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
				// Ad�na g�re kategoriyi bul
				var category = _categoryService.GetAll().FirstOrDefault(c => c.CategoryName == categoryName);

				if (category != null)
				{
					_categoryService.Delete(category);
					MessageBox.Show("Kategori silindi.");

					// Combobox ve textbox g�ncelle
					cbxCategory.DataSource = _categoryService.GetAll();
					cbxCategory.DisplayMember = "CategoryName";
					cbxCategory.ValueMember = "CategoryId";
					txtCategory.Clear();
				}
				else
				{
					MessageBox.Show("B�yle bir kategori bulunamad�.");
				}
			}
			else
			{
				MessageBox.Show("L�tfen silinecek kategori ad�n� girin.");
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
				MessageBox.Show("Kategori ba�ar�yla eklendi.");

				// Combobox'� g�ncelle
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
