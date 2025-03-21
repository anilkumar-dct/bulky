using BulkyUsingRazorPages.Data;
using BulkyUsingRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyUsingRazorPages.Pages.Categories
{
    public class CreateModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]//used for getting and setting value in razor pages we have to use it
        public Category category { get; set; }
        public CreateModel(ApplicationDbContext db) {
            _db = db;
        }
        public void OnGet()
        {
            //var category = _db.Categories.ToList();
        }
        public IActionResult OnPost() { 
            _db.Categories.Add(category);
            _db.SaveChanges();
            TempData["success"] = "Category Created Successfully";
            return RedirectToPage("Index");
        }
    }
}
