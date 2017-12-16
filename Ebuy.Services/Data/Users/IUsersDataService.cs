namespace Ebuy.Services.Data.Users
{
    using System.Linq;
    using Ebuy.Data.Models;

    public interface IUsersDataService : IService
    {
        IQueryable<User> GetAll();
    }
}