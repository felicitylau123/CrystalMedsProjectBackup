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
	public class PrescriptionsController : ControllerBase
	{
		//private readonly ApplicationDbContext _context;
		private readonly IUnitOfWork _unitOfWork;
		//public PrescriptionsController(ApplicationDbContext context)
		public PrescriptionsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}


		// GET: api/Prescriptions
		[HttpGet]
		//public async Task<ActionResult<IEnumerable<Prescription>>> GetPrescriptions()
		public async Task<IActionResult> getPrescriptions()
		{
			//return await _context.Prescriptions.ToListAsync();
			var Prescriptions = await _unitOfWork.Prescriptions.GetAll();
			return Ok(Prescriptions);
		}

		// GET: api/Prescriptions/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Prescription>> GetPrescription(int id)
		{
			//var Prescription = await _context.Prescriptions.FindAsync(id);
			var Prescription = await _unitOfWork.Prescriptions.Get(q => q.PrescriptionId == id);
			if (Prescription == null)
			{
				return NotFound();
			}

			return Ok(Prescription);
		}

		private ActionResult<Prescription> OK(Prescription Prescription)
		{
			throw new NotImplementedException();
		}

		// PUT: api/Prescriptions/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutPrescription(int id, Prescription Prescription)
		{
			if (id != Prescription.PrescriptionId)
			{
				return BadRequest();
			}

			//_context.Entry(Prescription).State = EntityState.Modified;
			_unitOfWork.Prescriptions.Update(Prescription);
			try
			{
				//await _context.SaveChangesAsync();
				await _unitOfWork.Save(HttpContext);
			}
			catch (DbUpdateConcurrencyException)
			{
				//if (!PrescriptionExists(id))
				if (!await PrescriptionExists(id))
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

		// POST: api/Prescriptions
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Prescription>> PostPrescription(Prescription Prescription)
		{
			//_context.Prescriptions.Add(Prescription);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Prescriptions.Insert(Prescription);
			await _unitOfWork.Save(HttpContext);
			return CreatedAtAction("GetPrescription", new { id = Prescription.PrescriptionId }, Prescription);
		}

		// DELETE: api/Prescriptions/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePrescription(int id)
		{
			//var Prescription = await _context.Prescriptions.FindAsync(id);
			var Prescription = await _unitOfWork.Prescriptions.Get(q => q.PrescriptionId == id);
			if (Prescription == null)
			{
				return NotFound();
			}

			// _context.Prescriptions.Remove(Prescription);
			//await _context.SaveChangesAsync();
			await _unitOfWork.Prescriptions.Delete(id);
			await _unitOfWork.Save(HttpContext);

			return NoContent();
		}

		//private bool PrescriptionExists(int id)
		private async Task<bool> PrescriptionExists(int id)
		{
			//return (_context.Prescriptions?.Any(e => e.PrescriptionId == id)).GetValueOrDefault();
			var make = await _unitOfWork.Prescriptions.Get(q => q.PrescriptionId == id);
			return make != null;
		}
	}
}