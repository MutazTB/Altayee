using Microsoft.AspNetCore.Mvc;

namespace Al_Tayee.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
