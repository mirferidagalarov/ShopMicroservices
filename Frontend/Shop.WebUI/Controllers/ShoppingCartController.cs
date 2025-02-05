using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
