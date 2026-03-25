using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Models.Cart;
using BookstoreProjectCore.Services;
using BookstoreProjectData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BookstoreWebApp.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IOrderService service;
		private readonly UserManager<User> userManager;

		public OrdersController(IOrderService _service, UserManager<User> _userManager)
		{
			service = _service;
			userManager = _userManager;
		}

<<<<<<< HEAD
        
        [Authorize]
        public async Task<IActionResult> AddToCart(string id)
        {
            var bookId = new Guid(id);
            var user = await userManager.GetUserAsync(User);

            if (user == null) {return Unauthorized();}

            await service.AddToCart(bookId, user.Id);
            return RedirectToAction("GetCart");
        }

        [Authorize]
        public async Task<IActionResult> GetCart()
        {
            var user = await userManager.GetUserAsync(User);
=======
		public IActionResult Index()
		{
			return View();
		}

		[Authorize]
		public async Task<IActionResult> AddToCart(string id)
		{
			var bookid = new Guid(id);
			var user = await userManager.GetUserAsync(User);
>>>>>>> 2e8c9ef4dc2c8dfbbaeb6450faaa5f967d37f6d4

			if (user == null)
			{
				return Unauthorized();
			}

<<<<<<< HEAD
            var model = new CartViewModel();

            if (order != null)
            {
                model.Items = order.Orders_Books.Select(ob => new CartItemViewModel
                {
                    BookId = ob.BookId,
                    Title = ob.Book.Title,
                    CoverImageUrl = ob.Book.CoverImageUrl,
                    UnitPrice = ob.UnitPrice,
                    Quantity = ob.Quantity
                }).ToList();
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(Guid bookId)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return Unauthorized();
            }

            await service.RemoveFromCart(bookId, user.Id);

            return RedirectToAction(nameof(GetCart));
        }
    }
=======
			await service.AddToCart(bookid, user.Id);

			return RedirectToAction(nameof(GetCart));
		}

		[Authorize]
		public async Task<IActionResult> GetCart()
		{
			var user = await userManager.GetUserAsync(User);

			var order = await service.GetCart(user.Id);

			var model = new CartViewModel();

			if (order != null)
			{
				model.Items = order.Orders_Books.Select(ob => new CartItemViewModel
				{
					BookId = ob.BookId,
					Title = ob.Book.Title,
					CoverImageUrl = ob.Book.CoverImageUrl,
					UnitPrice = ob.UnitPrice,
					Quantity = ob.Quantity
				}).ToList();
			}

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> RemoveFromCart(Guid bookId)
		{
			var user = await userManager.GetUserAsync(User);

			if (user == null)
			{
				return Unauthorized();
			}

			await service.RemoveFromCart(bookId, user.Id);

			return RedirectToAction(nameof(GetCart));
		}
	}
>>>>>>> 2e8c9ef4dc2c8dfbbaeb6450faaa5f967d37f6d4
}
