namespace Ebuy.Services.Data.Products
{
    using System.Linq;
    using Ebuy.Data;
    using Ebuy.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ProductsDataService : BaseDataService<Product>, IProductsDataService
    {
        private readonly DbSet<Product> products;

        public ProductsDataService(EbuyDbContext context)
            : base(context)
        {
            this.products = this.Repository;
        }

        public IQueryable<Product> GetAllByCategoryId(int categoryId) =>
            this.products.Where(p => p.CategoryId == categoryId);
    }
}