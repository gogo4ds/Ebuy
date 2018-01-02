namespace Ebuy.Web.Areas.Products.Controllers
{
    using Ebuy.Data.Models;
    using Ebuy.Services.Data.Categories;
    using Ebuy.Services.Data.Products;
    using Ebuy.Web.Areas.Products.Models;
    using Ebuy.Web.Common;
    using Ebuy.Web.Common.Extensions;
    using Ebuy.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.Products)]
    public class ProductsController : BaseController
    {
        private readonly IProductsDataService productsData;
        private readonly ICategoriesDataService categoriesData;

        public ProductsController(IProductsDataService productsData, ICategoriesDataService categoriesData)
        {
            this.productsData = productsData;
            this.categoriesData = categoriesData;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Create(int categoryId)
        {
            var category = this.categoriesData.GetById(categoryId);

            if (category == null)
            {
                this.TempData.AddErrorMessage("Category does not exist");
                return this.RedirectToHome();
            }

            var model = new ProductViewModel
            {
                CategoryId = categoryId,
                CategoryName = category.Name
            };

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel model)
        {
            var product = new Product
            {
                CategoryId = model.CategoryId,
                Name = model.Name,
                BrandName = model.BrandName,
                Price = model.Price,
                //TODO: add picture
            };

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            this.productsData.AddOrUpdate(product);

            this.TempData.AddSuccessMessage($"Successfully added new product {model.Name} to the category {model.CategoryName}");
            return this.RedirectToHome();
        }
    }
}
