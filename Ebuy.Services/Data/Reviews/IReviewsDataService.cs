namespace Ebuy.Services.Data.Reviews
{
    using System.Threading.Tasks;
    using Ebuy.Data.Models;

    public interface IReviewsDataService : IDataService<Review>
    {
        Task CreateAsync(int productId, string title, string content, double rating, string userId);
    }
}
