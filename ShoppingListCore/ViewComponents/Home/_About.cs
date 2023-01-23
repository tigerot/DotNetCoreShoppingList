using Microsoft.AspNetCore.Mvc;

namespace ShoppingListCore.ViewComponents.Home
{
    public class _About : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
