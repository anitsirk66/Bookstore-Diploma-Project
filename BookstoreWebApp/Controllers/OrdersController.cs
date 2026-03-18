using BookstoreProjectCore.Contracts;
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
        public IActionResult Index()
        {
            return View();
        }

        
        [Authorize]
        public async Task<IActionResult> AddToCart(Guid bookid)
        {
            var user = await userManager.GetUserAsync(User);
            await service.AddToCart(bookid, user.Id);
            return RedirectToAction("Index"); //*
        }

        public async Task<IActionResult> GetCart()
        {
            var user = await userManager.GetUserAsync(User);

            var order = await service.GetCart(user.Id);

            var cartItems = new List<Order_Book>();

            if (order != null)
            {
                foreach (var item in order.Orders_Books)
                {
                    cartItems.Add(item);
                }
            }

            return View(cartItems); //?
        }
    }
}
