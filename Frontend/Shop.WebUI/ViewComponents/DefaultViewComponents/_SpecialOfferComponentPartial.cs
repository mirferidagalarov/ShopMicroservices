﻿using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
