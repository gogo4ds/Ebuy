namespace Ebuy.Web.Areas.Products.Controllers
{
    using AutoMapper.QueryableExtensions;
    using Ebuy.Services.Data.Products;
    using Ebuy.Web.Areas.Products.Models;
    using Ebuy.Web.Controllers;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : BaseController
    {
        private readonly IProductsDataService productsData;

        public CategoriesController(IProductsDataService productsData)
        {
            this.productsData = productsData;
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
