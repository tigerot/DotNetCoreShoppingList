using Microsoft.AspNetCore.Mvc;

namespace ShoppingListCore.ViewComponents.Home
{
    public class _Banner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
