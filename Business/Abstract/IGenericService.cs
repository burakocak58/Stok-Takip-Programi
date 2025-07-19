﻿using System.Collections.Generic;

namespace Business.Abstract
{
	public interface IGenericService<T>
	{
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		T GetById(int id);
		List<T> GetAll();
	}
}
