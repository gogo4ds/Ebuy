namespace Ebuy.Services.Data
{
    using System.Linq;

    public interface IDataService<out TModel> : IService
        where TModel : class, new()
    {
        IQueryable<TModel> GetAll();
    }
}