using Business.Abstract;
using DataAcces.Abstract;
using Entity;
using System.Collections.Generic;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IProductDal _productDal;

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;
		}

		public void Add(Product entity)
		{
			_productDal.Add(entity);
		}

		public void Update(Product entity)
		{
			_productDal.Update(entity);
		}

		public void Delete(Product entity)
		{
			_productDal.Delete(entity);
		}

		public Product GetById(int id)
		{
			return _productDal.GetById(id);
		}

		public List<Product> GetAll()
		{
			return _productDal.GetList();
		}
	}
}
