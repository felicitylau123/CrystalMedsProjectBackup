using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrystalMeds.Server.Data;
using CrystalMeds.Shared.Domain;
using CrystalMeds.Server.IRepository;

namespace CrystalMeds.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		//public ProductsController(ApplicationDbContext context)
		public ProductsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		// GET: api/Products
		[HttpGet]
		//public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		public async Task<IActionResult> getProducts()
		{
			//return await _context.Products.ToListAsync();
			var Products = await _unitOfWork.Products.GetAll();
			return Ok(Products);
		}

		// GET: api/Products/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Product>> GetProduct(int id)
		{
			//var Product = await _context.Products.FindAsync(id);
			var Product = await _unitOfWork.Products.Get(q => q.ProductId == id);
			if (Product == null)
			{
				return NotFound();
			}

			return Ok(Product);
		}

		private ActionResult<Product> OK(Product Product)
		{
			throw new NotImplementedException();
		}

		// PUT: api/Products/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutProduct(int id, Product Product)
		{
			if (id != Product.ProductId)
			{
				return BadRequest();
			}

			//_context.Entry(Product).State = EntityState.Modified;
			_unitOfWork.Products.Update(Product);
			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				//if (!ProductExists(id))
				if (!await ProductExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// POST: api/Products
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Product>> PostProduct(Product Product)
		{
			//_context.Products.Add(Product);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Products.Insert(Product);
			await _unitOfWork.Save(HttpContext);
			return CreatedAtAction("GetProduct", new { id = Product.ProductId }, Product);
		}

		// DELETE: api/Products/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			//var Product = await _context.Products.FindAsync(id);
			var Product = await _unitOfWork.Products.Get(q => q.ProductId == id);
			if (Product == null)
			{
				return NotFound();
			}

			// _context.Products.Remove(Product);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Products.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		//private bool ProductExists(int id)
		private async Task<bool> ProductExists(int id)
		{
			//return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
			var make = await _unitOfWork.Products.Get(q => q.ProductId == id);
			return make != null;
		}


		[HttpGet("ByCategory/{categoryId}")]
		public async Task<ActionResult<IEnumerable<Product>>> GetProductsByCategory(int categoryId)
		{
			var products = await _unitOfWork.Products.Get(q => q.CategoryId == categoryId);
			return Ok(products);
		}
	}
}