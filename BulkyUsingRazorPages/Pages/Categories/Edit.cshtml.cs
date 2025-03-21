using BulkyUsingRazorPages.Data;
using BulkyUsingRazorPages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyUsingRazorPages.Pages.Categories
{
    public class EditModel : PageModel
    {
        public readonly ApplicationDbContext _db;
        [BindProperty]
        public Category? category { get; set; }
        public EditModel(ApplicationDbContext db) => _db = db;
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                category = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid) {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
         
        }
    }
}
