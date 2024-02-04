
using CrystalMeds.Server.Data;
using CrystalMeds.Server.IRepository;
using CrystalMeds.Server.Models;
using CrystalMeds.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CrystalMeds.Server.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _context;
		private IGenericRepository<Category> _categories;
		private IGenericRepository<Product> _products;
		private IGenericRepository<Customer> _customers;
		private IGenericRepository<Order> _orders;
		private IGenericRepository<Payment> _payments;
		private IGenericRepository<Promotion> _promotions;
		private IGenericRepository<Prescription> _prescriptions;
        private IGenericRepository<CartItem> _cartItems;

        private UserManager<ApplicationUser> _userManager;

		public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public IGenericRepository<Category> Categories
			=> _categories ??= new GenericRepository<Category>(_context);
		public IGenericRepository<Product> Products
			=> _products ??= new GenericRepository<Product>(_context);
		public IGenericRepository<Order> Orders
			=> _orders ??= new GenericRepository<Order>(_context);
		public IGenericRepository<Customer> Customers
			=> _customers ??= new GenericRepository<Customer>(_context);
		public IGenericRepository<Payment> Payments
			=> _payments ??= new GenericRepository<Payment>(_context);
		public IGenericRepository<Prescription> Prescriptions
			=> _prescriptions ??= new GenericRepository<Prescription>(_context);
		public IGenericRepository<Promotion> Promotions
			=> _promotions ??= new GenericRepository<Promotion>(_context);
        public IGenericRepository<CartItem> CartItems
            => _cartItems ??= new GenericRepository<CartItem>(_context);

        public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}

		public async Task Save(HttpContext httpContext)
		{
			//To be implemented
			string user = "System";

			var entries = _context.ChangeTracker.Entries()
				.Where(q => q.State == EntityState.Modified ||
					q.State == EntityState.Added);

			await _context.SaveChangesAsync();
		}
	}
}
