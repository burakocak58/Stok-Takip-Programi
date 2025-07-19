using DataAcces.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAcces.Repository
{
	public class GenericRepository<T> : IGenericDal<T> where T : class
	{
		private readonly DbContext _context;

		public GenericRepository(DbContext context)
		{
			_context = context;
		}

		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
			_context.SaveChanges();
		}

		public void Delete(T entity)
		{
			_context.Set<T>().Remove(entity);
			_context.SaveChanges();
		}

		public IEnumerable<T> Find(Func<T, bool> predicate)
		{
			return _context.Set<T>().Where(predicate).ToList();
		}

		public IEnumerable<T> GetAll()
		{
			return _context.Set<T>().AsEnumerable();
		}

		public T? GetById(int id)
		{
			return _context.Set<T>().Find(id);
		}

		public List<T> GetList()
		{
			return _context.Set<T>().ToList();
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
			_context.SaveChanges();
		}
	}
}
