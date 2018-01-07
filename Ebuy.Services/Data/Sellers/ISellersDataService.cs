namespace Ebuy.Services.Data.Sellers
{
    using System.Threading.Tasks;
    using Ebuy.Data.Models;
    public interface ISellersDataService : IDataService<Seller>
    {
        Seller GetSellerByUserId(string userId);

        string GetSellerUserNameByProductId(int productId);

        Task<Seller> CreateAsyncByUserId(string userId);
    }
}