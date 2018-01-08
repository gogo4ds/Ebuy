namespace Ebuy.Services.Data.Reviews
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Ebuy.Data;
    using Ebuy.Data.Models;

    public class ReviewsDataService : BaseDataService<Review>, IReviewsDataService
    {
        public ReviewsDataService(EbuyDbContext context) : base(context)
        {           
        }

        public async Task CreateAsync(int productId, string title, string content, double rating, string userId)
        {
            var review = new Review
            {
                ProductId = productId,
                Title = title,
                UserId = userId,
                Content = content,
                CreatedOn = DateTime.UtcNow,
                Score = rating
            };

            this.Repository.Add(review);

            await this.Context.SaveChangesAsync();
        }

        public IQueryable<Review> GetByProductIdQuery(int productId) =>
            this.Repository.Where(r => r.ProductId == productId);
    }
}