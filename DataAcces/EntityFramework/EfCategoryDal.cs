using DataAcces.Abstract;
using DataAcces.Repository;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.EntityFramework
{
	public class EfCategoryDal: GenericRepository<Category>, ICategoryDal
	{
		public EfCategoryDal(DbContext context) : base(context)
		{
		}
	}
}

