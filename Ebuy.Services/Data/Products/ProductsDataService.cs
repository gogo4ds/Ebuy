namespace Ebuy.Services.Data.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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

        public Product GetById(int productId) => this.products.Find(productId);

        public IQueryable<Product> GetByIdQuery(int productId) => this.products.Where(p => p.Id == productId);

        public async Task<int> DeleteByIdAsync(int productId)
        {
            var product = await this.products.FindAsync(productId);
            this.products.Remove(product);
            return await this.Context.SaveChangesAsync();
        }

        public async Task<List<string>> GetImageNamesByIdAsync(int productId) =>
            await this.products
                .Where(p => p.Id == productId)
                .SelectMany(p => p.Images.Select(i => i.Image.Title))
                .ToListAsync();

        public async Task<bool> ExistsById(int productId) =>
            await this.products.FirstOrDefaultAsync(p => p.Id == productId) != null;
    }
}