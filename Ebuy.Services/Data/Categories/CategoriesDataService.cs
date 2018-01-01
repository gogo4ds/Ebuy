namespace Ebuy.Services.Data.Categories
{
    using System.Linq;
    using Ebuy.Data;
    using Ebuy.Data.Models;
    using Ebuy.Services.Extensions;
    using Microsoft.EntityFrameworkCore;

    public class CategoriesDataService : BaseDataService<Category>, ICategoriesDataService
    {
        private readonly DbSet<Category> categories;

        public CategoriesDataService(EbuyDbContext context) : base(context)
        {
            this.categories = this.Repository;
        }

        public void CreateNewByNameOrderAndParentId(string name, int order, int? parentId)
        {
            var category = new Category
            {
                Name = name,
                Order = order,
                ParentId = parentId
            };

            this.categories.Add(category);
            this.categories.SaveChanges(this.Context);
        }

        public IQueryable<Category> GetByIdQuery(int categoryId) =>
            this.categories.Where(c => c.Id == categoryId);

        public Category GetById(int categoryId) =>
            this.categories.Find(categoryId);
    }
}