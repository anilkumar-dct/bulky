using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulkyweb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        //Data base implementation using ProductsController
        //------------------------
        //private readonly ApplicationDbContext _context;
        //public ProductsController(ApplicationDbContext db)
        //{
        //    _context = db;
        //}
        //public IActionResult Products()
        //{
        //    var objProductsList=_context.categories.ToList();
        //    return View(objProductsList);
        //}
        //public IActionResult CreateProducts()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CreateProducts(Products products)
        //{
        //    if (products.Name == products.DisplayOrder.ToString())
        //    {
        //        ModelState.AddModelError("name", "Name can't be same as Display Order");
        //    }
        //    if (ModelState.IsValid) {
        //        _context.categories.Add(products);
        //        _context.SaveChanges();
        //        TempData["success"] = "Products Created Successfully";
        //        return RedirectToAction("Products");
        //    }
        //    return View();

        //}

        ////public IActionResult CreateProductsForm(Products products)

        ////{
        ////    _context.categories.Add(products);
        ////    _context.SaveChanges();
        ////    return RedirectToAction("Products");

        ////Edit Products Controller 
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0) { return NotFound(); }
        //    Products? products = _context.categories.FirstOrDefault(c => c.Id == id);
        //    //  Products? category2 = _context.categories.Find(id);//provide value based on only primay key
        //    // var category3 = _context.categories.Where(u=>u.Id == id).FirstOrDefault();
        //    if (products == null) { return NotFound(); }
        //    return View(products);
        //}

        //[HttpPost]
        //public IActionResult Edit(Products products)

        //{
        //    _context.categories.Update(products);
        //    _context.SaveChanges();
        //    TempData["success"] = "Products Updated Successfully";
        //    return RedirectToAction("Products");
        //}
        ////Delete with view
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0) { return NotFound(); }
        //    Products? products = _context.categories.FirstOrDefault(c => c.Id == id);
        //    //  Products? category2 = _context.categories.Find(id);//provide value based on only primay key
        //    // var category3 = _context.categories.Where(u=>u.Id == id).FirstOrDefault();
        //    if (products == null) { return NotFound(); }
        //    return View(products);
        //}

        ////[HttpPost]//in this case you need to provide proper path and parrameter 
        //public IActionResult DeleteAndPost(int? id)

        //{
        //    Products? products = _context.categories.FirstOrDefault(u => u.Id == id);
        //    if (products == null) { return NotFound(); }
        //    _context.categories.Remove(products);
        //    _context.SaveChanges();
        //    TempData["success"] = "Products Deleted Successfully";
        //    return RedirectToAction("Products");
        //}

        ////Delete Products controller CREATED by own 
        ////public IActionResult Delete(int? id)
        ////{

        ////    Products? products = _context.categories.FirstOrDefault(u => u.Id == id);
        ////    if (products == null) { return NotFound(); }
        ////    _context.categories.Remove(products);
        ////    _context.SaveChanges();
        ////    return RedirectToAction("Products");

        ////}

        //-----------------------------
        //-----------------------------
        //-----------------------------
        //Database Implementation using Repository Pattern 
        private readonly IProductsRepository _IProductsRepo;
        public ProductsController(IProductsRepository IProductsRepo )
        {
            _IProductsRepo = IProductsRepo;
        }
        public IActionResult Products()
        {
            var objProductsList = _IProductsRepo.GetAll().ToList();
            return View(objProductsList);
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Products products)
        {
            if (ModelState.IsValid)
            {
                _IProductsRepo.Add(products);
                _IProductsRepo.Save();
                TempData["success"] = "Products Created Successfully";
                return RedirectToAction("Products");
            }
            return View();

        }

        //public IActionResult CreateProductsForm(Products products)

        //{
        //    _context.categories.Add(products);
        //    _context.SaveChanges();
        //    return RedirectToAction("Products");

        //Edit Products Controller 
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            Products? products = _IProductsRepo.Get(c => c.Id == id);
            //  Products? category2 = _context.categories.Find(id);//provide value based on only primay key
            // var category3 = _context.categories.Where(u=>u.Id == id).FirstOrDefault();
            if (products == null) { return NotFound(); }
            return View(products);
        }

        [HttpPost]
        public IActionResult Edit(Products products)

        {
            _IProductsRepo.Update(products);
            _IProductsRepo.Save();
            TempData["success"] = "Products Updated Successfully";
            return RedirectToAction("Products");
        }
        //Delete with view
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) { return NotFound(); }
            Products? products = _IProductsRepo.Get(c => c.Id == id);
            //  Products? category2 = _context.categories.Find(id);//provide value based on only primay key
            // var category3 = _context.categories.Where(u=>u.Id == id).FirstOrDefault();
            if (products == null) { return NotFound(); }
            return View(products);
        }

        //[HttpPost]//in this case you need to provide proper path and parrameter 
        public IActionResult DeleteAndPost(int? id)

        {
            Products? products = _IProductsRepo.Get(u => u.Id == id);
            if (products == null) { return NotFound(); }
            _IProductsRepo.Remove(products);
            _IProductsRepo.Save();
            TempData["success"] = "Products Deleted Successfully";
            return RedirectToAction("Products");
        }

        //Delete Products controller CREATED by own 
        //public IActionResult Delete(int? id)
        //{

        //    Products? products = _context.categories.FirstOrDefault(u => u.Id == id);
        //    if (products == null) { return NotFound(); }
        //    _context.categories.Remove(products);
        //    _context.SaveChanges();
        //    return RedirectToAction("Products");

        //}
    }
}
