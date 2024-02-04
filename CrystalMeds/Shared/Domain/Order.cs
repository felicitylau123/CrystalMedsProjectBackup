using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMeds.Shared.Domain
{
	public class Order
	{
		public int OrderId { get; set; }
		public DateTime OrderDate { get; set; }
        public float? TotalPrice { get; set; }
		public int ProductId { get; set; }
		public virtual Product? Product { get; set; }
		
	}
}
