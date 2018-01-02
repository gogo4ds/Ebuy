namespace Ebuy.Services.Data
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using Ebuy.Data;
    using Ebuy.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public abstract class BaseDataService<TModel> : IDataService<TModel>
        where TModel : class, new()
    {
        protected readonly EbuyDbContext Context;

        protected BaseDataService(EbuyDbContext context)
        {
            this.Context = context;
            this.Repository = this.GetRepository();
        }

        protected DbSet<TModel> Repository { get; }

        public IQueryable<TModel> GetAll() => this.Repository;

        public void Update(TModel entity)
        {
            this.Repository.Update(entity);
            this.Context.SaveChanges();
        }

        public void Delete(TModel entity)
        {
            this.Repository.Remove(entity);
            this.Context.SaveChanges();
        }

        public void AddOrUpdate(TModel entity)
        {
            var t = typeof(TModel);
            PropertyInfo keyField = null;
            foreach (var propt in t.GetProperties())
            {
                var keyAttr = propt.GetCustomAttribute<KeyAttribute>();
                if (keyAttr != null)
                {
                    keyField = propt;
                    break; // assume no composite keys
                }
            }

            var keyVal = keyField?.GetValue(entity);
            var dbVal = this.Repository.Find(keyVal);

            if (dbVal == null)
            {
                this.Repository.Add(entity);
            }
            else
            {
                this.Repository.Update(entity);
            }
            
            this.Context.SaveChanges();
        }

        private dynamic GetRepository()
        {
            if (typeof(TModel) == typeof(User)) { return this.Context.Users; }

            if (typeof(TModel) == typeof(Product)) { return this.Context.Products; }

            if (typeof(TModel) == typeof(Category)) { return this.Context.Categories; }

            if (typeof(TModel) == typeof(Order)) { return this.Context.Orders; }

            if (typeof(TModel) == typeof(Comment)) { return this.Context.Comments; }

            if (typeof(TModel) == typeof(Address)) { return this.Context.Addresses; }

            if (typeof(TModel) == typeof(Customer)) { return this.Context.Customers; }

            if (typeof(TModel) == typeof(Review)) { return this.Context.Reviews; }

            if (typeof(TModel) == typeof(Seller)) { return this.Context.Sellers; }

            return null;
        }
    }
}