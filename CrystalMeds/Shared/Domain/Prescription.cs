using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrystalMeds.Shared.Domain
{
	public class Prescription
	{
		public int PrescriptionId { get; set; }
		public string? PatientName { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = " Description does not meet length requirements")]
        public string? PrescriptionDescription { get; set; }
		public int CustomerId { get; set; }
		public virtual Customer? Customer { get; set; }
	}
}
