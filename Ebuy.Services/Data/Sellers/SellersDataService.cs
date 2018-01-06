namespace Ebuy.Services.Data.Sellers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Ebuy.Data;
    using Ebuy.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class SellersDataService : BaseDataService<Seller>, ISellersDataService
    {
        private readonly DbSet<Seller> sellers;

        public SellersDataService(EbuyDbContext context) : base(context)
        {
            this.sellers = this.Repository;
        }

        public Seller GetSellerByUserId(string userId) =>
            this.sellers.FirstOrDefault(s => s.UserId == userId);

        public async Task<Seller> CreateAsyncByUserId(string userId)
        {
            var seller = new Seller { UserId = userId };
            this.sellers.Add(seller);
            await this.Context.SaveChangesAsync();
            return seller;
        }
    }
}