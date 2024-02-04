//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using CrystalMeds.Server.Data;
//using CrystalMeds.Shared.Domain;
//using CrystalMeds.Server.IRepository;

//namespace CrystalMeds.Server.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CartController : ControllerBase
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public CartController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        // GET: api/Cart
//        [HttpGet]
//        public async Task<IActionResult> GetCartItems()
//        {
//            var cartItems = await _unitOfWork.CartItems.GetAll();
//            return Ok(cartItems);
//        }

//        // GET: api/Cart/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<CartItem>> GetCartItem(int id)
//        {
//            var cartItem = await _unitOfWork.CartItems.Get(q => q.CartItemId == id);

//            if (cartItem == null)
//            {
//                return NotFound("CartItem not found");
//            }

//            return Ok(cartItem);
//        }

//        // POST: api/Cart
//        [HttpPost]
//        public async Task<ActionResult<CartItem>> AddToCart(CartItem cartItem)
//        {
//            await _unitOfWork.CartItems.Insert(cartItem);
//            await _unitOfWork.Save(HttpContext);

//            return CreatedAtAction("GetCartItem", new { id = cartItem.CartItemId }, cartItem);
//        }

//        // PUT: api/Cart/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateCartItem(int id, CartItem cartItem)
//        {
//            if (id != cartItem.CartItemId)
//            {
//                return BadRequest("Invalid ID");
//            }

//            _unitOfWork.CartItems.Update(cartItem);

//            try
//            {
//                await _unitOfWork.Save(HttpContext);
//            }
//            catch (Exception)
//            {
//                if (!await CartItemExists(id))
//                {
//                    return NotFound("CartItem not found");
//                }

//                throw;
//            }

//            return NoContent();
//        }

//        // DELETE: api/Cart/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> RemoveFromCart(int id)
//        {
//            var cartItem = await _unitOfWork.CartItems.Get(q => q.CartItemId == id);

//            if (cartItem == null)
//            {
//                return NotFound("CartItem not found");
//            }

//            await _unitOfWork.CartItems.Delete(id);
//            await _unitOfWork.Save(HttpContext);

//            return NoContent();
//        }

//        private async Task<bool> CartItemExists(int id)
//        {
//            var cartItem = await _unitOfWork.CartItems.Get(q => q.CartItemId == id);
//            return cartItem != null;
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrystalMeds.Server.Data;
using CrystalMeds.Shared.Domain;
using CrystalMeds.Server.IRepository;
public class CartController : Controller
{
	private static List<string> cartItems = new List<string>();

	[HttpPost]
	public IActionResult AddToCart(string product)
	{
		cartItems.Add(product);
		return RedirectToAction("/cartpage");
	}

	public IActionResult CartPage()
	{
		ViewBag.CartItems = cartItems;
		return View();
	}
}

