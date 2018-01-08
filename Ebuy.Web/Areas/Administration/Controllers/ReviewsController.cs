namespace Ebuy.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Ebuy.Services.Data.Products;
    using Ebuy.Services.Data.Reviews;
    using Ebuy.Web.Areas.Administration.Models.Reviews;
    using Ebuy.Web.Areas.Products.Models.Products;
    using Ebuy.Web.Common;
    using Ebuy.Web.Common.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Authorize(Roles = WebConstants.AdministratorRole + "," + WebConstants.ReviewerRole)]
    public class ReviewsController : AdministrationBaseController
    {
        private readonly IProductsDataService productsData;
        private readonly IReviewsDataService reviewsData;

        public ReviewsController(
            IProductsDataService productsData,
            IReviewsDataService reviewsData)
        {
            this.productsData = productsData;
            this.reviewsData = reviewsData;
        }

        public async Task<IActionResult> Create(int productId)
        {
            if (!this.User.IsReviewer() && !this.User.IsAdmin())
            {
                this.TempData.AddErrorMessage(WebConstants.NoPrivillegesMessage);
                return this.RedirectBack();
            }

            var productExists = await this.productsData.ExistsById(productId);

            if (!productExists)
            {
                this.TempData.AddErrorMessage("The product for which you want to make review does not exist");
                return this.RedirectBack();
            }

            var product = await this.productsData
                .GetByIdQuery(productId)
                .ProjectTo<SimpleProductViewModel>()
                .FirstOrDefaultAsync();

            var review = new ReviewViewModel { ProductId = product.Id };

            var model = new CreateReviewViewModel
            {
                Product = product,
                Review = review
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateReviewViewModel model)
        {
            if (!this.User.IsAdmin() && !this.User.IsReviewer())
            {
                this.TempData.AddErrorMessage(WebConstants.NoPrivillegesMessage);
                return this.RedirectBack();
            }

            var product = this.productsData.GetById(model.Review.ProductId);

            if (product == null)
            {
                this.TempData.AddErrorMessage("The product does not exist!");
                return this.RedirectBack();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            await this.reviewsData.CreateAsync(
                model.Review.ProductId,
                model.Review.Title,
                model.Review.Content,
                model.Review.Score,
                this.User.GetId());

            this.TempData.AddSuccessMessage($"Successfully added review for the product {model.Product.Name}");
            return this.RedirectToAction("Details", "Products", new { id = model.Review.ProductId, area="Products"});
        }
    }
}