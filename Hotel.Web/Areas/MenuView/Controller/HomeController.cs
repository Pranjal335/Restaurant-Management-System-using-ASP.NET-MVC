using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hotel.Web.Areas.MenuView.ViewModels;
using Hotel.Web.Data;
using Hotel.Web.Models;



namespace Hotel.Web.Areas.MenuView.Controllers
{
    [Area("MenuView")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Populate the data for the drop-down select list
            List<SelectListItem> categories = new List<SelectListItem>();
            categories.Add(new SelectListItem { Selected = true, Value = "", Text = "-- select a category --" });
            categories.AddRange(new SelectList(_context.Categories, "CategoryId", "CategoryName"));
            ViewData["CategoryId"] = categories.ToArray();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("CategoryId")] ShowMenuViewModel model)
        {
            // Retrieve the Menu Items for the selected category
            var items = _context.Menus.Where(m => m.CategoryId == model.CategoryId);

            // Populate the data into the viewmodel object
            model.MenuItems = items.ToList();

            // Populate the data for the drop-down select list
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");

            // Display the View
            return View("Index", model);
        }

        public IActionResult AddToCart(int? id)
        {

            return RedirectToAction("Index");
        }
    }
}
