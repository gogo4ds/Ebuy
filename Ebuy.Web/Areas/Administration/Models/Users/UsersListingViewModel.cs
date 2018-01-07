namespace Ebuy.Web.Areas.Administration.Models.Users
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public class UsersListingViewModel
    {
        public IEnumerable<AdminUsersListingViewModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}