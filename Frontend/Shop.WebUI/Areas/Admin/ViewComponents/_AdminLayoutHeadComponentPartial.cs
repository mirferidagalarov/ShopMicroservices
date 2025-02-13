using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
