namespace Ebuy.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        public IActionResult RedirectToHome()
        {
            return this.RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}