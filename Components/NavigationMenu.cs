using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApp.Components
{
    public class NavigationMenu : ViewComponent
    {
        private IBookAppRepository repository;

        public NavigationMenu (IBookAppRepository repo)
        {
            repository = repo;
        }

        public IViewComponentResult Invoke()
        {
            // Set the selected category
            ViewBag.SelectedType = RouteData?.Values["category"];

            // Get all categories
            return View(repository.Books
                .Select(item => item.Category)
                .Distinct()
                .OrderBy(item => item));
        }
    }
}
