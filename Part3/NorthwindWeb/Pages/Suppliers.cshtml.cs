using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using NorthwindContextLib;
using NorthwindEntitiesLib;

namespace NorthwindWeb.Pages
{
    public class SuppliersModel : PageModel
    {
        [BindProperty]
        public Supplier Supplier { get; set; }
        
        private Northwind db;
        public SuppliersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }
        
        public IEnumerable<string> Suppliers { get; set; }
        
        public void OnGet()
        {
            ViewData["Title"] = "Northwind Web Site - Suppliers";
            Suppliers = db.Suppliers.Select(s => s.CompanyName).ToArray();
        }
        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(Supplier);
                db.SaveChanges();
                return RedirectToPage("/suppliers");
            }
            return Page();
        }
    }
}