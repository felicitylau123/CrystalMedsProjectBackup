using CrystalMeds.Server.Data;
using CrystalMeds.Shared.Domain;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace CrystalMeds.Server.Configurations.Entities
{
	public class ProductSeedConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasData(
new Product
{
	ProductId = 1,
	ProductName = "Crystal meds skin cleanser",
	ProductPrice = 15,
	ProductDescription = "Neutrogena Hydro Boost Water Gel Cleanser",
	ProductCategory = "skin care",
	CategoryId = 1
},
new Product
{
	ProductId = 2,
	ProductName = "crystal meds skin moisturizers",
	ProductPrice = 22,
	ProductDescription = "Clinique Dramatically Different Moisturizing Lotion+",
	ProductCategory = "skin care",
	CategoryId = 1
},
new Product
{
	ProductId = 3,
	ProductName = "crystal meds sun screen",
	ProductPrice = 12,
	ProductDescription = "EltaMD UV Clear Broad-Spectrum SPF 46",
	ProductCategory = "skin care",
	CategoryId = 1
},
new Product
{
	ProductId = 4,
	ProductName = "crystal meds serum",
	ProductPrice = 20,
	ProductDescription = "The Ordinary Niacinamide 10% + Zinc 1%",
	ProductCategory = "skin care",
	CategoryId = 1
},
new Product
{
	ProductId = 5,
	ProductName = "crystal meds exfoliants",
	ProductPrice = 30,
	ProductDescription = "Skin Perfecting 2% BHA Liquid Exfoliant",
	ProductCategory = "skin care",
	CategoryId = 1
},
new Product
{
	ProductId = 6,
	ProductName = "crystal meds charcoal mask",
	ProductPrice = 30,
	ProductDescription = "for a healthy and glow skin",
	ProductCategory = "skin care",
	CategoryId = 1
},

new Product
{
	ProductId = 7,
	ProductName = "crystal meds adhesive bandages",
	ProductPrice = 5,
	ProductDescription = "and-Aid for covering small cuts and wounds.",
	ProductCategory = "first aid",
	CategoryId = 2
},
new Product
{
	ProductId = 8,
	ProductName = "crystal meds cotton roll",
	ProductPrice = 5,
	ProductDescription = "highest quality cotton for applying ointments or cleaning small areas.",
	ProductCategory = "first aid",
	CategoryId = 2
},
new Product
{
	ProductId = 9,
	ProductName = "crystal meds antiseptic solution",
	ProductPrice = 13,
	ProductDescription = "Used for cleaning wounds to prevent infection.",
	ProductCategory = "first aid",
	CategoryId = 2
},
new Product
{
	ProductId = 10,
	ProductName = "crystal meds eye cream",
	ProductPrice = 10,
	ProductDescription = "eye cream with the essence of avocado for better result",
	ProductCategory = "first aid",
	CategoryId = 2
},
new Product
{
	ProductId = 11,
	ProductName = "crystal meds medical gloves",
	ProductPrice = 15,
	ProductDescription = "high quality gloves. available in all sizes",
	ProductCategory = "first aid",
	CategoryId = 2
},
new Product
{
	ProductId = 12,
	ProductName = "crystal meds pain relief spray",
	ProductPrice = 10,
	ProductDescription = "relieves pains associated with bones and muscles",
	ProductCategory = "pain relief",
	CategoryId = 3
},
new Product
{
	ProductId = 13,
	ProductName = "crystal meds headache balm",
	ProductPrice = 10,
	ProductDescription = "releives strong headache. faster action.",
	ProductCategory = "pain relief",
	CategoryId = 3
},
new Product
{
	ProductId = 14,
	ProductName = "Acetaminophen (Tylenol)",
	ProductPrice = 20,
	ProductDescription = "Used for mild to moderate pain and to reduce fever. It's generally considered safe when taken as directed, but excessive use can lead to liver damage.",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
},
new Product
{
	ProductId = 15,
	ProductName = "Advil Migraine",
	ProductPrice = 18,
	ProductDescription = " formulated specifically for migraines may contain a combination of pain relievers and caffeine.",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
},
new Product
{
	ProductId = 16,
	ProductName = "Zanaflex (Tizanidine)",
	ProductPrice = 15,
	ProductDescription = "Over-the-counter muscle relaxants can help alleviate muscle spasms and tension. ",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
},
new Product
{
	ProductId = 17,
	ProductName = "Robaxin (Methocarbamol)",
	ProductPrice = 15,
	ProductDescription = "help relieve sneezing, runny nose, and itchy or watery eyes. It may cause drowsiness.",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
},
new Product
{
	ProductId = 18,
	ProductName = "Benadryl",
	ProductPrice = 15,
	ProductDescription = "help relieve sneezing, runny nose, and itchy or watery eyes. It may cause drowsiness.",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
},
new Product
{
	ProductId = 19,
	ProductName = "Zyrtec",
	ProductPrice = 15,
	ProductDescription = "Non-drowsy options for allergy symptoms that may accompany a cold.",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
},
new Product
{
	ProductId = 20,
	ProductName = "Aleve",
	ProductPrice = 17,
	ProductDescription = "for fever and associated symptoms",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
},
new Product
{
	ProductId = 21,
	ProductName = "panadol",
	ProductPrice = 10,
	ProductDescription = "reduces fever",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
},
new Product
{
	ProductId = 22,
	ProductName = "Glibenclamide",
	ProductPrice = 10,
	ProductDescription = " Stimulate the pancreas to release more insulin.",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
},
new Product
{
	ProductId = 23,
	ProductName = "Canagliflozin",
	ProductPrice = 10,
	ProductDescription = " Reduce glucose reabsorption in the kidneys, leading to increased glucose excretion in the urine.",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
},
new Product
{
	ProductId = 24,
	ProductName = "Flomax",
	ProductPrice = 15,
	ProductDescription = "to improve urine flow and reduce symptoms associated with BPH.",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
},
new Product
{
	ProductId = 25,
	ProductName = "Oxycodone",
	ProductPrice = 15,
	ProductDescription = "for severe pain due to kidney stone",
	ProductCategory = "medicine(with prescriptions)",
	CategoryId = 4
}
);


		}
	}
}