using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.ViewComponents.ProductListViewComponent
{
    public class _ProductListSizeFilterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
