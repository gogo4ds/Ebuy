namespace Ebuy.Services.Data.Categories
{
    using Ebuy.Data;
    using Ebuy.Data.Models;

    public class CategoriesDataService : BaseDataService<Category>, ICategoriesDataService
    {
        public CategoriesDataService(EbuyDbContext context) : base(context)
        {
        }
    }
}