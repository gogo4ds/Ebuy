namespace Ebuy.Services.Data
{
    using System.Linq;

    public interface IDataService<TModel> : IService
        where TModel : class, new()
    {
        IQueryable<TModel> GetAll();

        void Update(TModel entity);

        void Delete(TModel entity);
    }
}