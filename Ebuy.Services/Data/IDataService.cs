namespace Ebuy.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    public interface IDataService<TModel> : IService
        where TModel : class, new()
    {
        IQueryable<TModel> GetAll();

        void Update(TModel entity);

        Task<int> UpdateAsync(TModel entity);

        void Delete(TModel entity);

        Task<int> AddOrUpdateAsync(TModel entity);
    }
}