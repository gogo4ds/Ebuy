namespace Ebuy.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Ebuy.Services.Data.Users;
    using Ebuy.Web.Areas.Administration.Models.Users;
    using Microsoft.AspNetCore.Mvc;
    
    public class UsersController : AdministrationBaseController
    {
        private readonly IUsersDataService usersData;

        public UsersController(IUsersDataService usersData)
        {
            this.usersData = usersData;
        }

        public IActionResult Index()
        {
            var users = this.usersData.GetAll().ProjectTo<AdminUsersListingViewModel>().ToList();
            return this.View(users);
        }
    }
}
