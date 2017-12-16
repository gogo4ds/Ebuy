namespace Ebuy.Web.Areas.Administration.Models
{
    using Ebuy.Data.Models;
    using Ebuy.Web.Infrastructure.Mapping;

    public class AdminUsersListingViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string Email { get; set; }
    }
}