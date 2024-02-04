//using CrystalMeds.Shared.Domain;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;

//namespace CrystalMeds.Server.Configurations.Entities
//{
//    public class OrderSeedConfiguration : IEntityTypeConfiguration<Order>
//    {
//        public void Configure(EntityTypeBuilder<Order> builder)
//        {
//            builder.HasData(
//                new Order
//                {
//                    OrderId = 1,
//                    OrderDate = DateTime.Now.AddDays(-5),
//                    TotalPrice = 50.5f,
//                    ProductId = 1, 
//                },
//                new Order
//                {
//                    OrderId = 2,
//                    OrderDate = DateTime.Now.AddDays(-3),
//                    TotalPrice = 35.2f,
//                    ProductId = 2, 
//                }
//            );
//        }
//    }
//}