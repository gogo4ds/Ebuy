namespace Ebuy.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;
    using Ebuy.Data.Models;
    using Ebuy.Services.Data.Users;
    using Ebuy.Web.Areas.Administration.Models.Users;
    using Ebuy.Web.Common.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    public class UsersController : AdministrationBaseController
    {
        private readonly IUsersDataService usersData;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;

        public UsersController(
            IUsersDataService usersData,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager)
        {
            this.usersData = usersData;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = this.usersData.GetAll().ProjectTo<AdminUsersListingViewModel>().ToList();
            var roles = await this.roleManager
                .Roles
                .Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
                .ToListAsync();

            var model = new UsersListingViewModel
            {
                Users = users,
                Roles = roles
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var roleExists = await this.roleManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);           

            if (!roleExists || user == null)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid identity details.");
            }

            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction(nameof(this.Index));
            }

            await this.userManager.AddToRoleAsync(user, model.Role);

            if (user != null)
            {
                this.TempData.AddSuccessMessage($"Successfully added user: {user.UserName} to the {model.Role} role.");
            }

            return this.RedirectToAction(nameof(this.Index));
        }
    }
}