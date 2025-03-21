using BulkyUsingRazorPages.Data;
using BulkyUsingRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyUsingRazorPages.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public Category? category { get; set; }
        public DeleteModel(ApplicationDbContext db) => _db = db;
        public void OnGet(int? id)
        {
            category = _db.Categories.Find(id);
        }

        public IActionResult OnPost() {
        _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToPage("Index");
        }
    }
}
