using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

using ShoppingListCore.Models;
using ShoppingListCore.Repository;
using ShoppingListCoreProject.Models;
using ShoppingListProject.Models;
using ShoppingListProject.Validators;
using System.Security.Claims;
using System.Security.Principal;

namespace ShoppingListCoreProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        //Creates a generic repository for user table
        GenericRepository<User> userRepository = new GenericRepository<User>();


        [HttpGet]
        public IActionResult SignUp()
        {
            HttpContext.SignOutAsync();                   
            return View();
        }
        [HttpPost]
        public  IActionResult SignUp(UserRegisterViewModel u) 
        {
            //Checks the conditions within uservalidator
            UserValidator validator = new UserValidator();
            ValidationResult result = validator.Validate(u);
            if (result.IsValid == false)
            {
                foreach (var error in result.Errors)
                {
                    //Returns the error message if the conditions aren't valid
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();

            }
          
            User user = new User()
            {
                UserPassword = u.UserPassword,
                UserSurname = u.UserSurname,
                UserMail = u.UserMail,
                UserName = u.UserName
            };

           
           
                
                var mail = userRepository.GetByFilter(x => x.UserMail == user.UserMail);
            if (mail == null)//Inserts the mail if it doesn't exist with the database
            {
                userRepository.Insert(user);
                return RedirectToAction("SignIn");
            }

           
            else
            {
                ModelState.AddModelError("emailused", "Mail adresi daha önce alınmış");
                return View();
            }


        }

        [HttpGet]
        public  IActionResult SignIn()
        {
            //Redirects the user according to it's role if it's signed in before
         if( User.IsInRole("Administrator"))
            { return RedirectToAction("Index", "Category", new { area = "Admin" });}  

         if(User.IsInRole("Member"))
            {  return RedirectToAction("Index", "List", new { area = "Member" }); }
            //If it's not signed in, redirects to the sign in page.
            var Userid = String.IsNullOrEmpty(HttpContext.User.Identity.Name);

            if (Userid)
                ViewBag.isauthenticated = false;
            else
                ViewBag.isauthenticated = true;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSignInViewModel p)
        {
            //Checks the username and password attributes on if they are empty or not
            LoginValidator validator = new LoginValidator();
            ValidationResult result = validator.Validate(p);
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();

            }
            if (result.IsValid)
            {
                string role = "";
                User user=ControlLogin(p);

             
                if(user!=null)
                {
                    role=user.UserAdminStatus ?  "Administrator" : "Member";
                 
                    //Authentication processes are done with cookies
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, role),
                };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                   
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);//Sign out if there's a previous process going on
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                    authProperties);//Sign in again

                    //Redirects according to user's role
                    return user.UserAdminStatus 
                        ? RedirectToAction("Index", "Category", new { area = "Admin" }) 
                        : RedirectToAction("Index", "List", new { area = "Member" });
                  

                }

                else
            {
                ViewBag.message = "Hatalı Kullanıcı adı veya Parola";
            }
                }
          

            return View();
           
        }
        private User ControlLogin(UserSignInViewModel p)
        {
           //Checks the mail and passwords from database
            var user = userRepository.GetByFilter(x => x.UserMail == p.email && x.UserPassword == p.password);
            return user;

        }

        public async Task<IActionResult> LogOut()
        {
            //Sign out
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
    }
}
