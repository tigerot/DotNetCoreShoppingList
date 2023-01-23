
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoppingListCore.Repository;
using ShoppingListCore.Validators;
using ShoppingListCoreProject.Models;
using ShoppingListProject.Models;
using ShoppingListProject.Validators;
using System.Linq.Expressions;
using System.Text;

namespace ShoppingListCore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ProductController : Controller
    {
       
        GenericRepository<Product> productRepository = new GenericRepository<Product>();
        GenericRepository<Category> categoryRepository = new GenericRepository<Category>();
                

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            GetCategories(0,1);   
           var  product = productRepository.GetAll(null,x=>x.Category);
            return View(product);
        }
        public IActionResult FilterProduct(int id)
        {
            //Filtering according to categories
     
            var productlist = productRepository.GetAll(null, x=>x.Category);

            if (id != 0)
            {
                productlist = productlist.Where(c => c.CategoryId == id).ToList();
            }

            GetCategories(id,1);

         
            return View("Index", productlist);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
           GetCategories();
           
           
            return View();

        }
        private void GetCategories(int id = 0,int isfilter=0)
        {
            //Retrieves the category list
            List<Category> categories = new List<Category>();

            var categories1 = categoryRepository.GetList();
            if (id != 0)
            {
                //Shows the filtered product first at the dropdown menu in products page
                var ct = categoryRepository.GetByID(id);
                categories.Add(ct);
                if (isfilter == 1)
                    categories.Add(new Category { CategoryId = 0, CategoryName = "Tümü" });
                foreach (var item in categories1)
                {
                    if (item.CategoryId != ct.CategoryId)
                    {
                        categories.Add(item);
                    }

                }



            }
            else
            {
                if(isfilter==1)
                categories.Add(new Category { CategoryId = 0, CategoryName = "Tümü" });
                foreach (var item in categories1)
                {

                    categories.Add(item);


                }
            }
            ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
       
           
        }
        [HttpPost]
        public  async Task<IActionResult> AddProduct(Product product)
        {
            GetCategories();

            ProductValidator validator = new ProductValidator();

            ValidationResult result = validator.Validate(product);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();

            }

           

                product.CategoryId = product.Category.CategoryId;
                product.Category = null;
              //Adds the product name if it isn't already used somewhere
            var controll = productRepository.GetListByFilter(s => s.ProductName.ToLower() == product.ProductName.ToLower());
            if (controll.Count ==0)
            {

                productRepository.Insert(product);
                ViewBag.message = "Kayıt Başarılı!";
            }
            else
            {
                 ViewBag.message = "Ürün daha önce eklenmiş!";
            }
                                 

            return View();



        }

        public IActionResult DeleteProduct(int id)
        {
            productRepository.Delete(productRepository.GetByID(id));
            return RedirectToAction("Index", "Product", new { area = "Admin" });

        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            //Returns the info of the product that will get updated
            var ch = productRepository.GetByID(id);
            GetCategories(ch.CategoryId);
          
            return View(ch);


        }
        [HttpPost]
        public IActionResult UpdateProduct(Product  product)
        { 
           
            GetCategories(product.CategoryId);
            ProductValidator validator = new ProductValidator();

            ValidationResult result = validator.Validate(product);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
               
                return View(product);

            }
          
                product.CategoryId = product.Category.CategoryId;
                product.Category = null;
               if(product.Image==null)//Use the old image if a new image isn't added
            {
             product.Image= productRepository.GetByID(product.ProductId).Image;

            }

            var controll = productRepository.GetByFilter(s => s.ProductName.ToLower() == product.ProductName.ToLower());
          
            if (controll == null || controll.ProductId==product.ProductId  )
            {
                productRepository.Update(product);             
                ViewBag.message = "Kayıt Başarılı!";
            }
            else
            {
                ViewBag.message = "Ürün daha önce eklenmiş!";
            }
            return View(product);
           
        }
    

}
}
