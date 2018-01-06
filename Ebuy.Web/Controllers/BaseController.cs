namespace Ebuy.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BaseController : Controller
    {
        public IActionResult RedirectToHome() =>
            this.RedirectToAction(nameof(HomeController.Index), "Home", new {area = string.Empty});

        public IActionResult RedirectBack()
        {
            var returnUrl = this.HttpContext.Request.Headers["Referer"].ToString();
            return string.IsNullOrWhiteSpace(returnUrl)
                ? this.RedirectToHome()
                : this.Redirect(returnUrl);
        }
    }
}