using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrystalMeds.Shared.Domain
{
	public class Payment
	{
		public int PaymentId { get; set; }
		public float? Amount { get; set; }
		public int OrderId { get; set; }
		public virtual Order? Order { get; set; }
	}
}
