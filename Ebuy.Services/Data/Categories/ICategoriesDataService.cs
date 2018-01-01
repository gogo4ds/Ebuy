namespace Ebuy.Services.Data.Categories
{
    using System.Linq;
    using Ebuy.Data.Models;

    public interface ICategoriesDataService : IDataService<Category>
    {
        void CreateNewByNameOrderAndParentId(string name, int order, int? parentId);

        IQueryable<Category> GetByIdQuery(int categoryId);

        Category GetById(int categoryId);
    }
}