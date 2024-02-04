using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMeds.Shared.Domain
{
	public class Product
	{


		public int ProductId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = " Name doesnot meet length requirements")]
        public string? ProductName { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public float ProductPrice { get; set; }
        public string ProductDescription { get; set; }
		public string? ProductCategory { get; set; }
		//public int? ProductQuantity { get; set; }
		public int CategoryId { get; set; }
		public virtual Category? Category { get; set; }
    }
}
