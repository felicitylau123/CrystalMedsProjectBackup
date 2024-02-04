using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMeds.Shared.Domain
{
	public class Customer
	{
		public int CustomerId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "First Name doesnot meet length requirements")]
        public string? UserName { get; set; }
		public string? Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E mail address is not valid")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "contact number is not valid")]
        public string? PhoneNumber { get; set; }
		public string? Address { get; set; }
		
	}
}
