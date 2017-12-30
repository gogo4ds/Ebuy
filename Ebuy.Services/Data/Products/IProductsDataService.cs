namespace Ebuy.Services.Data.Products
{
    using System.Linq;
    using Ebuy.Data.Models;

    public interface IProductsDataService : IDataService<Product>
    {
        IQueryable<Product> GetAllByCategoryId(int categoryId);
    }
}