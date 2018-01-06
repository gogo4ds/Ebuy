﻿namespace Ebuy.Web.Areas.Products.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Ebuy.Data.Models;
    using Ebuy.Services.Data.Categories;
    using Ebuy.Services.Data.Products;
    using Ebuy.Services.Data.Sellers;
    using Ebuy.Web.Areas.Products.Models;
    using Ebuy.Web.Common;
    using Ebuy.Web.Common.Extensions;
    using Ebuy.Web.Controllers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;

    [Area(WebConstants.Products)]
    public class ProductsController : BaseController
    {
        private readonly IProductsDataService productsData;
        private readonly ICategoriesDataService categoriesData;
        private readonly ISellersDataService sellersData;
        private readonly IHostingEnvironment appEnvironment;
        private readonly UserManager<User> userManager;

        public ProductsController(
            IProductsDataService productsData,
            ICategoriesDataService categoriesData,
            ISellersDataService sellersData,
            IHostingEnvironment appEnvironment,
            UserManager<User> userManager)
        {
            this.productsData = productsData;
            this.categoriesData = categoriesData;
            this.sellersData = sellersData;
            this.appEnvironment = appEnvironment;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [Authorize]
        public IActionResult Create(int categoryId)
        {
            var category = this.categoriesData.GetById(categoryId);       
            var seller = this.sellersData.GetSellerByUserId(this.User.GetId());

            if (category == null)
            {
                this.TempData.AddErrorMessage("Category does not exist");
                return this.RedirectToHome();
            }

            var model = new ProductViewModel
            {
                CategoryId = categoryId,
                CategoryName = category.Name,
                SellerId = seller?.Id
            };

            return this.View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var userId = this.User.GetId();
            Seller seller;
            if (model.SellerId == null)
            {
                seller = await this.sellersData.CreateAsyncByUserId(userId);               
            }
            else
            {
                seller = this.sellersData.GetSellerByUserId(userId);
            }

            var product = new Product
            {
                CategoryId = model.CategoryId,
                Seller = seller,
                Name = model.Name,
                BrandName = model.BrandName,
                Price = model.Price,
                Description = model.Description
            };

            await this.productsData.AddOrUpdateAsync(product);

            var image = this.HttpContext.Request.Form.Files.FirstOrDefault();

            if (image != null && image.Length > 0)
            {
                var file = image;
                var uploads = Path.Combine(this.appEnvironment.WebRootPath, "uploads\\img\\products");

                if (file.Length > 0)
                {                    
                    var fileName = ContentDispositionHeaderValue.Parse
                        (file.ContentDisposition).FileName.Value;

                    fileName = fileName.Substring(1, fileName.Length - 2);
                    var indexOfLastDot = fileName.LastIndexOf('.');
                    var fileExtension = fileName.Substring(indexOfLastDot, fileName.Length - indexOfLastDot).ToLower();

                    var modifiedFileName = $"{product.Id}-{product.Name}{fileExtension}";

                    using (var fileStream = new FileStream(Path.Combine(uploads, modifiedFileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    product.ImageName = modifiedFileName;
                }
            }

            await this.productsData.UpdateAsync(product);

            this.TempData.AddSuccessMessage($"Successfully added new product {model.Name} to the category {model.CategoryName}");
            return this.RedirectToHome();
        }

        public IActionResult Delete(int id)
        {           
            var product = this.productsData.GetByIdQuery(id).ProjectTo<ProductViewModel>().FirstOrDefault();

            if (product == null)
            {
                this.TempData.AddErrorMessage("The Product does not exist");
                return this.RedirectToHome();
            }

            if (product.SellerUserName != this.User.Identity.Name)
            {
                this.TempData.AddErrorMessage(WebConstants.NoPrivillegesMessage);
                return this.RedirectToAction("Details", "Products", new {area = "Products"});
            }

            return this.View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductViewModel model)
        {
            if (model == null)
            {
                this.TempData.AddErrorMessage("The Product does not exist");
                return this.RedirectToHome();
            }

            if (model.SellerUserName != this.User.Identity.Name)
            {
                this.TempData.AddErrorMessage(WebConstants.NoPrivillegesMessage);
                return this.RedirectToAction("Details", "Products", new { area = "Products" });
            }

            var file = new FileInfo(Path.Combine(this.appEnvironment.WebRootPath, model.ImageName));

            await file.DeleteAsync();
            await this.productsData.DeleteByIdAsync(model.Id);

            this.TempData.AddSuccessMessage("Product deleted successfully!");
            return this.RedirectToAction("Products", "Categories", new {area = "Products"});
        }

        public IActionResult Details(int id) =>
            this.View(this.productsData
                .GetByIdQuery(id)
                .ProjectTo<ProductViewModel>()
                .FirstOrDefault());
    }
}