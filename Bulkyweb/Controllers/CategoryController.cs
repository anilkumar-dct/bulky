using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulkyweb.Controllers
{
    public class CategoryController:Controller
    {
        //Data base implementation using CategoryController
        //------------------------
        //private readonly ApplicationDbContext _context;
        //public CategoryController(ApplicationDbContext db)
        //{
        //    _context = db;
        //}
        //public IActionResult Category()
        //{
        //    var objCategoryList=_context.categories.ToList();
        //    return View(objCategoryList);
        //}
        //public IActionResult CreateCategory()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CreateCategory(Category category)
        //{
        //    if (category.Name == category.DisplayOrder.ToString())
        //    {
        //        ModelState.AddModelError("name", "Name can't be same as Display Order");
        //    }
        //    if (ModelState.IsValid) {
        //        _context.categories.Add(category);
        //        _context.SaveChanges();
        //        TempData["success"] = "Category Created Successfully";
        //        return RedirectToAction("Category");
        //    }
        //    return View();

        //}

        ////public IActionResult CreateCategoryForm(Category category)

        ////{
        ////    _context.categories.Add(category);
        ////    _context.SaveChanges();
        ////    return RedirectToAction("Category");

        ////Edit Category Controller 
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0) { return NotFound(); }
        //    Category? category = _context.categories.FirstOrDefault(c => c.Id == id);
        //    //  Category? category2 = _context.categories.Find(id);//provide value based on only primay key
        //    // var category3 = _context.categories.Where(u=>u.Id == id).FirstOrDefault();
        //    if (category == null) { return NotFound(); }
        //    return View(category);
        //}

        //[HttpPost]
        //public IActionResult Edit(Category category)

        //{
        //    _context.categories.Update(category);
        //    _context.SaveChanges();
        //    TempData["success"] = "Category Updated Successfully";
        //    return RedirectToAction("Category");
        //}
        ////Delete with view
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0) { return NotFound(); }
        //    Category? category = _context.categories.FirstOrDefault(c => c.Id == id);
        //    //  Category? category2 = _context.categories.Find(id);//provide value based on only primay key
        //    // var category3 = _context.categories.Where(u=>u.Id == id).FirstOrDefault();
        //    if (category == null) { return NotFound(); }
        //    return View(category);
        //}

        ////[HttpPost]//in this case you need to provide proper path and parrameter 
        //public IActionResult DeleteAndPost(int? id)

        //{
        //    Category? category = _context.categories.FirstOrDefault(u => u.Id == id);
        //    if (category == null) { return NotFound(); }
        //    _context.categories.Remove(category);
        //    _context.SaveChanges();
        //    TempData["success"] = "Category Deleted Successfully";
        //    return RedirectToAction("Category");
        //}

        ////Delete Category controller CREATED by own 
        ////public IActionResult Delete(int? id)
        ////{

        ////    Category? category = _context.categories.FirstOrDefault(u => u.Id == id);
        ////    if (category == null) { return NotFound(); }
        ////    _context.categories.Remove(category);
        ////    _context.SaveChanges();
        ////    return RedirectToAction("Category");

        ////}

//-----------------------------
//-----------------------------
//-----------------------------
//Database Implementation using Repository Pattern 
        private readonly ICategoryRepository _ICategoryRepo;
        public CategoryController(ICategoryRepository ICategoryRepo)
        {
            _ICategoryRepo = ICategoryRepo;
        }
        public IActionResult Category()
        {
            var objCategoryList = _ICategoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Name can't be same as Display Order");
            }
            if (ModelState.IsValid)
            {
                _ICategoryRepo.Add(category);
                _ICategoryRepo.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Category");
            }
            return View();

        }

        //public IActionResult CreateCategoryForm(Category category)

        //{
        //    _context.categories.Add(category);
        //    _context.SaveChanges();
        //    return RedirectToAction("Category");

        //Edit Category Controller 
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            Category? category = _ICategoryRepo.Get(c => c.Id == id);
            //  Category? category2 = _context.categories.Find(id);//provide value based on only primay key
            // var category3 = _context.categories.Where(u=>u.Id == id).FirstOrDefault();
            if (category == null) { return NotFound(); }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)

        {
            _ICategoryRepo.Update(category);
            _ICategoryRepo.Save();
            TempData["success"] = "Category Updated Successfully";
            return RedirectToAction("Category");
        }
        //Delete with view
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            Category? category = _ICategoryRepo.Get(c => c.Id == id);
            //  Category? category2 = _context.categories.Find(id);//provide value based on only primay key
            // var category3 = _context.categories.Where(u=>u.Id == id).FirstOrDefault();
            if (category == null) { return NotFound(); }
            return View(category);
        }

        //[HttpPost]//in this case you need to provide proper path and parrameter 
        public IActionResult DeleteAndPost(int? id)

        {
            Category? category = _ICategoryRepo.Get(u => u.Id == id);
            if (category == null) { return NotFound(); }
            _ICategoryRepo.Remove(category);
            _ICategoryRepo.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Category");
        }

        //Delete Category controller CREATED by own 
        //public IActionResult Delete(int? id)
        //{

        //    Category? category = _context.categories.FirstOrDefault(u => u.Id == id);
        //    if (category == null) { return NotFound(); }
        //    _context.categories.Remove(category);
        //    _context.SaveChanges();
        //    return RedirectToAction("Category");

        //}
    }
}
