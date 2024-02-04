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
	public class OrdersController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		//public OrdersController(ApplicationDbContext context)
		public OrdersController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		// GET: api/Orders
		[HttpGet]
		//public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
		public async Task<IActionResult> getOrders()
		{
			//return await _context.Orders.ToListAsync();
			var Orders = await _unitOfWork.Orders.GetAll();
			return Ok(Orders);
		}

		// GET: api/Orders/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Order>> GetOrder(int id)
		{
			//var Order = await _context.Orders.FindAsync(id);
			var Order = await _unitOfWork.Orders.Get(q => q.OrderId == id);
			if (Order == null)
			{
				return NotFound();
			}

			return Ok(Order);
		}

		private ActionResult<Order> OK(Order Order)
		{
			throw new NotImplementedException();
		}

		// PUT: api/Orders/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutOrder(int id, Order Order)
		{
			if (id != Order.OrderId)
			{
				return BadRequest();
			}

			//_context.Entry(Order).State = EntityState.Modified;
			_unitOfWork.Orders.Update(Order);
			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				//if (!OrderExists(id))
				if (!await OrderExists(id))
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

		// POST: api/Orders
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Order>> PostOrder(Order Order)
		{
			//_context.Orders.Add(Order);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Orders.Insert(Order);
			await _unitOfWork.Save(HttpContext);
			return CreatedAtAction("GetOrder", new { id = Order.OrderId }, Order);
		}

		// DELETE: api/Orders/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteOrder(int id)
		{
			//var Order = await _context.Orders.FindAsync(id);
			var Order = await _unitOfWork.Orders.Get(q => q.OrderId == id);
			if (Order == null)
			{
				return NotFound();
			}

			// _context.Orders.Remove(Order);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Orders.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		//private bool OrderExists(int id)
		private async Task<bool> OrderExists(int id)
		{
			//return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
			var make = await _unitOfWork.Orders.Get(q => q.OrderId == id);
			return make != null;
		}
	}
}