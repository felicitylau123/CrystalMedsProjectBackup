using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMeds.Shared.Domain
{
	public class Promotion
	{
		public int PromotionId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = " Promotion doesnot meet length requirements")]
        public string? PromotionName { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public float? PromotionAmount { get; set;}
        public virtual Product? Product { get; set; }

    }
}
