﻿using Microsoft.AspNetCore.Mvc;

namespace Shop.WebUI.Areas.Admin.ViewComponents
{
    public class _AdminLayoutHeaderComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
