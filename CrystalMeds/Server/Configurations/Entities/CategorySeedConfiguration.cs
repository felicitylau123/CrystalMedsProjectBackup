using CrystalMeds.Server.Data;
using CrystalMeds.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace CrystalMeds.Server.Configurations.Entities
{
	public class CategorySeedConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasData(
new Category
{
	CategoryId = 1,
	CategoryName = "skin care",
},
new Category
{
	CategoryId = 2,
	CategoryName = "First Aid",
},
new Category
{
    CategoryId = 3,
    CategoryName = "Pain Relief",
},
 new Category
{
    CategoryId = 4,
    CategoryName = "Medicine(prescription needed)",
}
);


		}
	}
}
