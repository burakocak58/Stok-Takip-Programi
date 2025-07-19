using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Abstract
{
	public interface IGenericDal<T> where T : class
	{
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		List<T> GetList();
		T GetById(int id);
		IEnumerable<T> GetAll();
		IEnumerable<T> Find(Func<T, bool> predicate);
	}
	
}

