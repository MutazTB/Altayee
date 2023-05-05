using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Al_Tayee.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _user;
        public AccountController(IUserService user)
        {
            _user = user;
        }        

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await _user.Login(viewModel);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
			return View("Admin/Brands/Index");
        }

        public async Task<IActionResult> Logout()
        {
            await _user.Logout();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login");
        }
    }
}
