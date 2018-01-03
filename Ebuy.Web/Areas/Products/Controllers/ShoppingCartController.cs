namespace Ebuy.Web.Areas.Products.Controllers
{
    using System.Linq;
    using Ebuy.Data.Models;
    using Ebuy.Services.Data.Products;
    using Ebuy.Web.Areas.Products.Models.ShoppingCart;
    using Ebuy.Web.Common;
    using Ebuy.Web.Common.Extensions;
    using Ebuy.Web.Controllers;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = this.productsData.GetById(productId);

            if (product == null)
            {
                this.TempData.AddErrorMessage("No such product");
                return this.RedirectToHome();
            }

            var cart = this.HttpContext.Session
                .GetObjectFromJson<ShoppingCartViewModel>(WebConstants.ShoppingCartSessionKey);

            if (cart == null)
            {
                var user = this.userManager.GetUserAsync(this.User);
                cart = new ShoppingCartViewModel
                {
                    UserId = user.Id
                };            
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
                cart.CartItems.First(item => item.ProductId == productId).Quantity++;
            }

            this.HttpContext.Session.SetObjectAsJson(WebConstants.ShoppingCartSessionKey, cart);

            this.TempData.AddSuccessMessage("Item added to cart");
            return this.RedirectToAction("Products", "Categories", new {area = "Products", id = product.CategoryId });
        }
    }
}