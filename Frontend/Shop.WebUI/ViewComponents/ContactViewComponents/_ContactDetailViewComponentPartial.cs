using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.ViewComponents.ContactViewComponents
{
    public class _ContactDetailViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
