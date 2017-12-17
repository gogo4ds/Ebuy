namespace Ebuy.Web.Areas.Products.Controllers
{
    using Ebuy.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        public IActionResult Products(int id)
        {
            return this.View();
        }
    }
}
