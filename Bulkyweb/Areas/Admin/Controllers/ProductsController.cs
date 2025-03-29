using System.Collections.Generic;
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        private readonly IWebHostEnvironment _webHostEnvironment;
        //When you are working with file upload then you have to capture is and store it some where in your project for ex: wwwRoot folder 
        //And to keep the track or to access the wwwroot path to do that we need to inject WebHostEnviroment and this above we injected the WebHost Environment 
        //and this is inbuild functionality so you don't have to worry about it, once you inject now make the change into your constructor
        private readonly IProductsRepository _IProductsRepo;
        private readonly ICategoryRepository _ICategoryRepo;
        public ProductsController(IProductsRepository IProductsRepo,ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _IProductsRepo = IProductsRepo;
            _ICategoryRepo = categoryRepository;
             _webHostEnvironment= webHostEnvironment;
        }
        public IActionResult Products()
        {
            var objProductsList = _IProductsRepo.GetAll(includeCategory:"Category").ToList();
           
            return View(objProductsList);
        }
        public IActionResult AddProduct()
        {
            IEnumerable<SelectListItem> CategoryList = _ICategoryRepo.GetAll().ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.CategoryList = CategoryList;
            return View();
            //Both below andd above is ViewBag Method is give to show the category list item in product page
            //NOT working this operation
            //ProductViewModel productViewModel = new()
            //{
            //    CategoryList = _ICategoryRepo.GetAll().ToList().Select(u => new SelectListItem
            //    {
            //        Text = u.Name,
            //        Value = u.Id.ToString()
            //    }),
            //    product = new Products()
            //};

            //return View(productViewModel);
        }
        [HttpPost]
        public IActionResult AddProduct(Products products,IFormFile?file)
        {   

            if (ModelState.IsValid)
            {
                //starting of file capturing syntax and storing
                //step 1. get the file which is in "file" variable of IFormFile
                //This WebRootPath is for path for wwwRoot file in your project.
                string wwwRoot=_webHostEnvironment.WebRootPath;//this is to navigate to wwwroot path  that is "C:\\DOT NET\\Bulky\\Bulkyweb\\wwwroot"
                // Now check whether file is empty or not.
                if (file != null)
                { 
                    //when file is uploaded then it might have some weird name and we can assign rename to our file for the solution of it We Can you use Grid functionality
                    string  fileName=Guid.NewGuid().ToString()+Path.GetExtension(file.FileName);//it provide you random name
                    //Now we have also manage the file extension because above code only provide you the name and we need to keep safe the extension and to the we added the function in above code after "+" here is the name with extension "921e20f4-8e29-4bc1-93dd-d2522e95a1f0.webp"
                    //Next step is to guide our "wwwRoot" To the wwwroot file and below the syntax is given here is the path C:\\DOT NET\\Bulky\\Bulkyweb\\wwwroot\\images\\product
                    string productPath =Path.Combine(wwwRoot,@"images\product");

                    //Now we have file with name and location
                    //Next step is to save the file below the syntax is given
                    //FileStream() accept full path and we need to provide that here we use path.combine to provide the path and we also have to path one more property that is fileMode 
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        //Now to copy the file in our provided root we need to use 
                        file.CopyTo(fileStream);
                        // Now next step is to save the imageurl and we have imagurl variable in our product class and we are going to store our file in that url.
                    }
                    //here we provided the path as well as file name with extension that is "\\images\\product\\921e20f4-8e29-4bc1-93dd-d2522e95a1f0.webp"
                    products.imageUrl = @"\images\product\"+fileName;

                }

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
            IEnumerable<SelectListItem> CategoryList = _ICategoryRepo.GetAll().ToList().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            ViewBag.CategoryList = CategoryList;
            if (id == null || id == 0) { return NotFound(); }
            Products? products = _IProductsRepo.Get(c => c.Id == id);
            //  Products? category2 = _context.categories.Find(id);//provide value based on only primay key
            // var category3 = _context.categories.Where(u=>u.Id == id).FirstOrDefault();
            if (products == null) { return NotFound(); }
            return View(products);
        }

        [HttpPost]
        public IActionResult Edit(Products products, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRoot = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRoot, @"images\product");

                    //Deteting Old image method
                    if (!string.IsNullOrEmpty(products.imageUrl))
                    {
                        //delete old imageurl
                        var OldImagePath = Path.Combine(wwwRoot, products.imageUrl.TrimStart('\\'));//This will get the old file

                        //finally deleted the image
                        if (System.IO.File.Exists(OldImagePath))
                        {
                            System.IO.File.Delete(OldImagePath);
                        }

                    }
                    //getting new image address here
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    products.imageUrl = @"\images\product\" + fileName;
                }
            }


            _IProductsRepo.Update(products);
            _IProductsRepo.Save();
            TempData["success"] = "Products Updated Successfully";
            return RedirectToAction("Products");
        }
        //Delete with view 
        //Previous Comments are which is with no dates
        //Today 29 march below code not required becauce we used sweet alert 
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
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var objProductsList = _IProductsRepo.GetAll(includeCategory: "Category").ToList();

            return Json(new { data = objProductsList });
        }

        [HttpDelete]
        public IActionResult DeleteWithAlert(int? id)
        {
            try
            {
                var productToDelete = _IProductsRepo.Get(u => u.Id == id);
                if (productToDelete == null)
                {
                    return Json(new { success = false, message = "Product not found" });
                }

                // Delete image if exists
                if (!string.IsNullOrEmpty(productToDelete.imageUrl))
                {
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath,
                        productToDelete.imageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                _IProductsRepo.Remove(productToDelete);
                _IProductsRepo.Save();

                return Json(new
                {
                    success = true,
                    message = "Product deleted successfully"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = $"Error deleting product: {ex.Message}"
                });
            }

        }
        #endregion
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
