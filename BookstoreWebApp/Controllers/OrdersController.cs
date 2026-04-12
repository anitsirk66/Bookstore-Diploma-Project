using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Models.Cart;
using BookstoreProjectCore.Services;
using BookstoreProjectData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
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

        public IActionResult Index()
        {
            return View();
        }

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

        [HttpPost]
        public async Task<IActionResult> ChangeQuantity(Guid bookId, int quantity)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            await service.ChangeQuantity(user.Id, bookId, quantity);

            return RedirectToAction("GetCart");
        }

        [Authorize(Roles = "Client")]
        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
                return Unauthorized();

            var address = user.Address;

            var finalAddress = await service.PlaceOrder(user.Id, address);

            TempData["OrderMessage"] =
                $"Your order has been placed! It will arrive in 3 to 5 business days on this address: {finalAddress}.";

            return RedirectToAction("GetCart");
        }
    }

}
