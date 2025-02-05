using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
