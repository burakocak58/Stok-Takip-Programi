using Business.Abstract;
using DataAcces.Abstract;
using Entity;
using System.Collections.Generic;

namespace Business.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDal _categoryDal;

		public CategoryManager(ICategoryDal categoryDal)
		{
			_categoryDal = categoryDal;
		}

		public void Add(Category entity)
		{
			_categoryDal.Add(entity);
		}

		public void Delete(Category entity)
		{
			_categoryDal.Delete(entity);
		}

		public List<Category> GetAll()
		{
			return _categoryDal.GetList();
		}

		public Category GetById(int id)
		{
			return _categoryDal.GetById(id);
		}

		public void Update(Category entity)
		{
			_categoryDal.Update(entity);
		}
	}
}
