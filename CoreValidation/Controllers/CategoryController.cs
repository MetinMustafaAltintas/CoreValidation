using CoreValidation.Models.ContextClasses;
using CoreValidation.Models.Entities;
using CoreValidation.Models.ViewModels.PureVM.Categories;
using Microsoft.AspNetCore.Mvc;

namespace CoreValidation.Controllers
{
    public class CategoryController : Controller
    {
        MyContext _db;

        public CategoryController(MyContext db)
        {
            _db = db;
        }


        public IActionResult GetCategories()
        {
            return View();
        }
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(CategoryRequestModel category)
        {
            //Server Side Validation'da bilgiler back end'e gönderilir ve kontrol öyle saglanır
            if (ModelState.IsValid) //Model durumu Validation'dan gecmiş ise 
            {
                //Mapping ( Bir tipin bilgilerinin diger istenilen tipe aktarılmasıdır)
                Category c = new()
                {
                    CategoryName = category.CategoryName,
                    Description = category.Description
                };

                _db.Categories.Add(c);
                _db.SaveChanges();
                return RedirectToAction("GetCategories");
            }

            return View(category);
        }
    }
}
