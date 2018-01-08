namespace Ebuy.Services.Data.Reviews
{
    using System.Linq;
    using System.Threading.Tasks;
    using Ebuy.Data.Models;

    public interface IReviewsDataService : IDataService<Review>
    {
        Task CreateAsync(int productId, string title, string content, double rating, string userId);

        IQueryable<Review> GetByProductIdQuery(int productId);
    }
}