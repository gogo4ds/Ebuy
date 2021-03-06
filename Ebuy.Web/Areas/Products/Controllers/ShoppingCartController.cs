﻿namespace Ebuy.Web.Areas.Products.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Ebuy.Data.Models;
    using Ebuy.Services.Data.Products;
    using Ebuy.Web.Areas.Products.Models;
    using Ebuy.Web.Areas.Products.Models.ShoppingCart;
    using Ebuy.Web.Common;
    using Ebuy.Web.Common.Extensions;
    using Ebuy.Web.Controllers;
    using Microsoft.ApplicationInsights.AspNetCore.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Area(WebConstants.Products)]
    public class ShoppingCartController : BaseController
    {
        private readonly IProductsDataService productsData;
        private readonly UserManager<User> userManager;

        public ShoppingCartController(IProductsDataService productsData, UserManager<User> userManager)
        {
            this.productsData = productsData;
            this.userManager = userManager;
        }

        public IActionResult Checkout()
        {
            return this.View();
        }

        public IActionResult Index()
        {
            var cart = this.HttpContext.Session
                .GetObjectFromJson<ShoppingCartViewModel>(WebConstants.ShoppingCartSessionKey);

            if (cart == null || cart.CartItems.Count == 0)
            {               
                this.TempData.AddInfoMessage("The Shopping Cart is empty");
                if (this.HttpContext.Request.Headers["Referer"].ToString() == this.HttpContext.Request.GetUri().AbsoluteUri)
                {
                    return this.View(new ShoppingCartViewModel());
                }

                return this.RedirectBack();
            }

            return this.View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var product = await this.productsData
                .GetByIdQuery(productId)
                .ProjectTo<ProductViewModel>()
                .FirstOrDefaultAsync();

            if (product == null)
            {
                this.TempData.AddErrorMessage("No such product");
                return this.RedirectToHome();
            }

            var cart = this.HttpContext.Session
                .GetObjectFromJson<ShoppingCartViewModel>(WebConstants.ShoppingCartSessionKey);

            if (cart == null)
            {
                cart = new ShoppingCartViewModel();

                var user = await this.userManager.GetUserAsync(this.User);
                
                if (user != null)
                {
                    cart.UserId = user.Id;
                }
            }

            if (cart.CartItems.All(item => item.ProductId != productId))
            {
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Product = product,
                    Quantity = 1
                });
            }
            else
            {
                this.TempData.AddInfoMessage("Item is already in the cart");
                return this.RedirectBack();
            }

            this.HttpContext.Session.SetObjectAsJson(WebConstants.ShoppingCartSessionKey, cart);

            this.TempData.AddSuccessMessage("Item added to cart");
            return this.RedirectToAction("Products", "Categories", new {area = "Products", id = product.CategoryId });
        }

        public IActionResult RemoveFromCart(int productId)
        {           
            var cart = this.HttpContext.Session
                .GetObjectFromJson<ShoppingCartViewModel>(WebConstants.ShoppingCartSessionKey);

            if (cart != null)
            {
                var product = cart.CartItems.FirstOrDefault(ci => ci.Product.Id == productId);
                cart.CartItems.Remove(product);
            }

            this.HttpContext.Session.SetObjectAsJson(WebConstants.ShoppingCartSessionKey, cart);

            return this.RedirectToAction("Index", "ShoppingCart");
        }
    }
}