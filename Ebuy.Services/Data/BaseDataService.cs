namespace Ebuy.Services.Data
{
    using System.Linq;
    using Ebuy.Data;
    using Ebuy.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseDataService<TModel> : IDataService<TModel>
        where TModel : class, new()
    {
        private readonly EbuyDbContext context;

        protected BaseDataService(EbuyDbContext context)
        {
            this.context = context;
            this.Repository = this.GetRepository();
        }

        protected DbSet<TModel> Repository { get; }

        public IQueryable<TModel> GetAll() => this.Repository;

        private dynamic GetRepository()
        {
            if (typeof(TModel) == typeof(User)) { return this.context.Users; }

            if (typeof(TModel) == typeof(Product)) { return this.context.Products; }

            if (typeof(TModel) == typeof(Category)) { return this.context.Categories; }

            if (typeof(TModel) == typeof(Order)) { return this.context.Orders; }

            if (typeof(TModel) == typeof(Comment)) { return this.context.Comments; }

            if (typeof(TModel) == typeof(Address)) { return this.context.Addresses; }

            if (typeof(TModel) == typeof(Customer)) { return this.context.Customers; }

            if (typeof(TModel) == typeof(Review)) { return this.context.Reviews; }

            if (typeof(TModel) == typeof(Seller)) { return this.context.Sellers; }

            return null;
        }
    }
}