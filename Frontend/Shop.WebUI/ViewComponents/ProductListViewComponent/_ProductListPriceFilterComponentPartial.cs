using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListPriceFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
