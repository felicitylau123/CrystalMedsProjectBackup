using CrystalMeds.Shared.Domain;

namespace CrystalMeds.Server.Controllers
{
	public class ProductsViewModel
	{
		public string CategoryName { get; set; }
		public List<Product> Products { get; set; }
	}
}