using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMeds.Shared.Domain
{ 
	public class ProductViewModel
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public float ProductPrice { get; set; }
		public string ProductDescription { get; set; }
		public string ProductCategory { get; set; }
		public int Quantity { get; set; } // Add the Quantity property
	}
}
