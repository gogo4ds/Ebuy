namespace Ebuy.Web.Areas.Products.Controllers
{
    using Ebuy.Web.Areas.Products.Models;
    using Ebuy.Web.Common;
    using Ebuy.Web.Common.Extensions;
    using Ebuy.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.Products)]
    public class ProductsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Create(int categoryId)
        {
            var model = new ProductViewModel {CategoryId = categoryId};
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            this.TempData.AddSuccessMessage($"Successfully added new {model.Name} to the category {model.CategoryName}");
            return this.RedirectToHome();
        }
    }
}
