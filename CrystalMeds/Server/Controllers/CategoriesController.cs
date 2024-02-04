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
    public class CategoriesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //public CategoriesController(ApplicationDbContext context)
        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/Categories
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        public async Task<IActionResult> getcategories()
        {
            //return await _context.Categories.ToListAsync();
            var categories = await _unitOfWork.Categories.GetAll();
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            //var category = await _context.Categories.FindAsync(id);
            var category = await _unitOfWork.Categories.Get(q => q.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        private ActionResult<Category> OK(Category category)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            //_context.Entry(category).State = EntityState.Modified;
            _unitOfWork.Categories.Update(category);
            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!CategoryExists(id))
                if (!await CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            //_context.Categories.Add(category);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Categories.Insert(category);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }


        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            //var category = await _context.Categories.FindAsync(id);
            var category = await _unitOfWork.Categories.Get(q => q.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            // _context.Categories.Remove(category);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Categories.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool CategoryExists(int id)
        private async Task<bool> CategoryExists(int id)
        {
            //return (_context.Categories?.Any(e => e.CategoryId == id)).GetValueOrDefault();
            var make = await _unitOfWork.Categories.Get(q => q.CategoryId == id);
            return make != null;
        }











		//[HttpGet("{categoryId}/Products")]
		//public async Task<IActionResult> GetProductsByCategory(int categoryId)
		//{
		//	var category = await _unitOfWork.Categories.Get(q => q.CategoryId == categoryId);

		//	if (category == null)
		//	{
		//		return NotFound("Category not found");
		//	}

		//	var products = await _unitOfWork.Products.GetMany(q => q.CategoryId == categoryId);

		//	return Ok(products);
		//}

}

	
	}

