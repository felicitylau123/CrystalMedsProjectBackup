//using CrystalMeds.Client.Pages.Cart;
using CrystalMeds.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace CrystalMeds.Server.IRepository
{
	public interface IUnitOfWork : IDisposable
	{
		Task Save(HttpContext httpContext);

		IGenericRepository<Category> Categories { get; }
		IGenericRepository<Product> Products { get; }
		IGenericRepository<Customer> Customers { get; }
		IGenericRepository<Order> Orders { get; }
		IGenericRepository<Payment> Payments { get; }
		IGenericRepository<Prescription> Prescriptions { get; }
		IGenericRepository<Promotion> Promotions { get; }
        IGenericRepository<CartItem> CartItems { get; }
    }
}