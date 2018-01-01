namespace Ebuy.Web.Areas.Products.Controllers
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Ebuy.Services.Data.Categories;
    using Ebuy.Services.Data.Products;
    using Ebuy.Web.Areas.Products.Models;
    using Ebuy.Web.Common;
    using Ebuy.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;

    [Area(WebConstants.Products)]
    public class CategoriesController : BaseController
    {
        private readonly IProductsDataService productsData;
        private readonly ICategoriesDataService categoriesData;

        public CategoriesController(IProductsDataService productsData, ICategoriesDataService categoriesData)
        {
            this.productsData = productsData;
            this.categoriesData = categoriesData;
        }

        public IActionResult Index()
        {
            var categories = this.categoriesData.GetAll().ToList();
            return this.View(categories);
        }

        public IActionResult Products(int id)
        {
            var products = this.productsData
                .GetAllByCategoryId(id)
                .ProjectTo<ProductViewModel>();

            return this.View(products);
        }
    }
}
