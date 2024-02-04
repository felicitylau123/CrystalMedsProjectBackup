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
	public class PromotionsController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		//public PromotionsController(ApplicationDbContext context)
		public PromotionsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		// GET: api/Promotions
		[HttpGet]
		//public async Task<ActionResult<IEnumerable<Promotion>>> GetPromotions()
		public async Task<IActionResult> getPromotions()
		{
			//return await _context.Promotions.ToListAsync();
			var Promotions = await _unitOfWork.Promotions.GetAll();
			return Ok(Promotions);
		}

		// GET: api/Promotions/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Promotion>> GetPromotion(int id)
		{
			//var Promotion = await _context.Promotions.FindAsync(id);
			var Promotion = await _unitOfWork.Promotions.Get(q => q.PromotionId == id);
			if (Promotion == null)
			{
				return NotFound();
			}

			return OK(Promotion);
		}

		private ActionResult<Promotion> OK(Promotion Promotion)
		{
			throw new NotImplementedException();
		}

		// PUT: api/Promotions/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutPromotion(int id, Promotion Promotion)
		{
			if (id != Promotion.PromotionId)
			{
				return BadRequest();
			}

			//_context.Entry(Promotion).State = EntityState.Modified;
			_unitOfWork.Promotions.Update(Promotion);
			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				//if (!PromotionExists(id))
				if (!await PromotionExists(id))
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

		// POST: api/Promotions
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Promotion>> PostPromotion(Promotion Promotion)
		{
			//_context.Promotions.Add(Promotion);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Promotions.Insert(Promotion);
			await _unitOfWork.Save(HttpContext);
			return CreatedAtAction("GetPromotion", new { id = Promotion.PromotionId }, Promotion);
		}

		// DELETE: api/Promotions/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePromotion(int id)
		{
			//var Promotion = await _context.Promotions.FindAsync(id);
			var Promotion = await _unitOfWork.Promotions.Get(q => q.PromotionId == id);
			if (Promotion == null)
			{
				return NotFound();
			}

			// _context.Promotions.Remove(Promotion);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Promotions.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		//private bool PromotionExists(int id)
		private async Task<bool> PromotionExists(int id)
		{
			//return (_context.Promotions?.Any(e => e.PromotionId == id)).GetValueOrDefault();
			var make = await _unitOfWork.Promotions.Get(q => q.PromotionId == id);
			return make != null;
		}
	}
}