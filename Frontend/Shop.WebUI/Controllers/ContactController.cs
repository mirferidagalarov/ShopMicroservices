using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
