using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListColorFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
