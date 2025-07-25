﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	public class Product
	{
		[Key]
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public string Category { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
	}
}
