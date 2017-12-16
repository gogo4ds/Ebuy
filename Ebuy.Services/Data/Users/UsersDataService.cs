namespace Ebuy.Services.Data.Users
{
    using System.Linq;
    using Ebuy.Data;
    using Ebuy.Data.Models;

    public class UsersDataService : IUsersDataService
    {
        private readonly EbuyDbContext context;

        public UsersDataService(EbuyDbContext context)
        {
            this.context = context;
        }

        public IQueryable<User> GetAll() => this.context.Users;
    }
}