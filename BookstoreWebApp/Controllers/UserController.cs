using BookstoreProjectData.Entities;
using BookstoreWebApp.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Net.WebSockets;

namespace BookstoreWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<User> _userManagaer, SignInManager<User> _signInManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManagaer;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SeedRoles()
        {
            string[] roles = { "Admin", "Client" };
            foreach (var role in roles)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            return Content("Roles seeded (created if mising).");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            var model = new UserRegisterViewModel();

            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Client");
                
                return RedirectToAction( "Index", "Home");
            }

            foreach(var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View(new UserLoginViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            var check = ModelState.IsValid;
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid user data";
                ModelState.AddModelError("", "Input data is not valid");
                return View(model);
            }

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null) 
            {
                ModelState.AddModelError("", "User is not found"); 
                return View(model); 
            }

            var result = await signInManager.PasswordSignInAsync(
                user.UserName, 
                model.Password, 
                model.RememberMe, 
                lockoutOnFailure: false);

            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Невалиден имейл или парола");
                return View(model);
            }

            TempData["SuccessMessage"] = "Logged in!";
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateAdmin()
        {
            var viewmodel = new UserCreateAdminViewModel();
            var allRoles = roleManager.Roles.ToList();
            viewmodel.RolesList = allRoles.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            });

            return View(viewmodel);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAdmin(UserCreateAdminViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var admin = new User()
            {
                Email = "kristina@gmail.com",
                UserName = model.UserName
            };

            var result = await userManager.CreateAsync(admin, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");

                return RedirectToAction("Index", "Home");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View(model);


        }


    }
}
