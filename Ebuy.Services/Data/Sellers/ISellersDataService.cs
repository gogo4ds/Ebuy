namespace Ebuy.Services.Data.Sellers
{
    using System.Threading.Tasks;
    using Ebuy.Data.Models;
    public interface ISellersDataService : IDataService<Seller>
    {
        Seller GetSellerByUserId(string userId);

        Task<Seller> CreateAsyncByUserId(string userId);
    }
}