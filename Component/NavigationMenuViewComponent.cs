using BYU_FEG.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYU_FEG.Component
{
    
    public class NavigationMenuViewComponent : ViewComponent
    {

        private BYUFEGContext context;

        public NavigationMenuViewComponent (BYUFEGContext c)
        {
            context = c;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedFilters = RouteData?.Values["filter"].ToString().Split('_');
            //context.books.Select(b => b.Category).Distinct().OrderBy(b => b)
            return View();
        }
    }
}
