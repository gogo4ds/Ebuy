namespace Ebuy.Services.Data.Users
{
    using Ebuy.Data;
    using Ebuy.Data.Models;

    public class UsersDataService : BaseDataService<User>, IUsersDataService
    {
        public UsersDataService(EbuyDbContext context)
            : base(context)
        {
        }
    }
}