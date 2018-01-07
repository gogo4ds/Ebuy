namespace Ebuy.Services.Data.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Ebuy.Data.Models;

    public interface IProductsDataService : IDataService<Product>
    {
        IQueryable<Product> GetAllByCategoryId(int categoryId);

        Product GetById(int productId);

        IQueryable<Product> GetByIdQuery(int productId);

        Task<int> DeleteByIdAsync(int productId);

        Task<List<string>> GetImageNamesByIdAsync(int productId);

        Task<bool> ExistsById(int productId);
    }
}