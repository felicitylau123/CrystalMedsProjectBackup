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
	public class customersController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		//public customersController(ApplicationDbContext context)
		public customersController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		// GET: api/customers
		[HttpGet]
		//public async Task<ActionResult<IEnumerable<Customer>>> Getcustomers()
		public async Task<IActionResult> getcustomers()
		{
			//return await _context.customers.ToListAsync();
			var customers = await _unitOfWork.Customers.GetAll();
			return Ok(customers);
		}

		// GET: api/customers/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Customer>> GetCustomer(int id)
		{
			//var Customer = await _context.customers.FindAsync(id);
			var Customer = await _unitOfWork.Customers.Get(q => q.CustomerId == id);
			if (Customer == null)
			{
				return NotFound();
			}

			return Ok(Customer);
		}

		private ActionResult<Customer> OK(Customer Customer)
		{
			throw new NotImplementedException();
		}

		// PUT: api/customers/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCustomer(int id, Customer Customer)
		{
			if (id != Customer.CustomerId)
			{
				return BadRequest();
			}

			//_context.Entry(Customer).State = EntityState.Modified;
			_unitOfWork.Customers.Update(Customer);
			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				//if (!CustomerExists(id))
				if (!await CustomerExists(id))
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

		// POST: api/customers
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Customer>> PostCustomer(Customer Customer)
		{
			//_context.customers.Add(Customer);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Customers.Insert(Customer);
			await _unitOfWork.Save(HttpContext);
			return CreatedAtAction("GetCustomer", new { id = Customer.CustomerId }, Customer);
		}

		// DELETE: api/customers/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCustomer(int id)
		{
			//var Customer = await _context.customers.FindAsync(id);
			var Customer = await _unitOfWork.Customers.Get(q => q.CustomerId == id);
			if (Customer == null)
			{
				return NotFound();
			}

			// _context.customers.Remove(Customer);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Customers.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		//private bool CustomerExists(int id)
		private async Task<bool> CustomerExists(int id)
		{
			//return (_context.customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
			var make = await _unitOfWork.Customers.Get(q => q.CustomerId == id);
			return make != null;
		}
	}
}