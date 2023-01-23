using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListCore.Repository;
using ShoppingListCoreProject.Models;
using ShoppingListProject.Models;
using ShoppingListProject.Validators;
using System.Text.RegularExpressions;

namespace ShoppingListCore.Areas.Admin.Controllers
{

    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CategoryController : Controller
    {
        
        GenericRepository<Category> categoryRepository = new GenericRepository<Category>();

        [HttpGet]
        public IActionResult Index()
        {
            var categories=categoryRepository.GetList();
            return View(categories);
        }
        public IActionResult DeleteCategory(int id)
        {
            categoryRepository.Delete(categoryRepository.GetByID(id));
            return RedirectToAction("Index", "Category", new { area = "Admin" });

        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(category);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();

            }
            //Adds the category name if it's not already added
            var catname = categoryRepository.GetByFilter(x => x.CategoryName.ToLower()== category.CategoryName.ToLower());
            if (catname == null)
            {
                categoryRepository.Insert(category);
                ViewBag.message = "Kayıt Başarılı!";
               
            }
            else
            {
                ViewBag.message = "Kategori adı kullanılıyor";
            }
                    return View();


           
           
             

            
        }
        
        [HttpGet]
        public IActionResult AddCategory()
        {
           
                return View();


        }
        
        [HttpGet]
        public IActionResult UpdateCategory(string categoryname, int id)
        {
            if (categoryname != null)
            {
                Category category = new Category();
                category.CategoryName = categoryname;
                category.CategoryId = id;
                return View(category);
            }
            else
                return View();


        }
        
        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            CategoryValidator validator = new CategoryValidator();
            ValidationResult result = validator.Validate(category);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();

            }
            //Updates the category name if it's null
            var catname = categoryRepository.GetByFilter(x => x.CategoryName.ToLower() == category.CategoryName.ToLower());
            if (catname == null)
            {
                categoryRepository.Update(category);
                ViewBag.message = "Kayıt Başarılı!";
            }
            else
            {
                ViewBag.message = "Kategori adı kullanılıyor";
            }
          
                       
               return View();
        }


    }
}

