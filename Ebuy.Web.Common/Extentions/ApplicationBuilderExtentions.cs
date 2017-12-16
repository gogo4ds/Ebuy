namespace Ebuy.Web.Common.Extentions
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    using Ebuy.Data;
    using Ebuy.Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            serviceScope.ServiceProvider.GetService<EbuyDbContext>().Database.Migrate();
            var userManager = serviceScope.ServiceProvider.GetService<UserManager<User>>();
            var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
            Task
                .Run(async () =>
                {
                    var roles = new[]
                    {
                        Constants.AdministratorRole,
                        Constants.ReviewerRole
                    };

                    foreach (var role in roles)
                    {
                        var roleExists = await roleManager.RoleExistsAsync(role);

                        if (!roleExists)
                        {
                            await roleManager.CreateAsync(new IdentityRole
                            {
                                Name = role
                            });
                        }
                    }

                    const string adminEmail = "gadmin@admin.com";
                    const string reviewerEmail = "review@admin.com";

                    var adminUser = await userManager.FindByEmailAsync(adminEmail);
                    var reviewUser = await userManager.FindByEmailAsync(reviewerEmail);

                    if (adminUser == null)
                    {
                        adminUser = new User
                        {
                            Email = adminEmail,
                            UserName = "gadmin",
                            //FirstName = "Georgi",
                            //LastName = "Georgiev",
                            //Birthdate = DateTime.UtcNow
                        };

                        await userManager.CreateAsync(adminUser, "gadmin");

                        await userManager.AddToRoleAsync(adminUser, Constants.AdministratorRole);
                        
                    }

                    if (reviewUser == null)
                    {
                        reviewUser = new User
                        {
                            Email = reviewerEmail,
                            UserName = "Reviewer",
                            //FirstName = "Georgi",
                            //LastName = "Georgiev",
                            //Birthdate = DateTime.UtcNow
                        };

                        await userManager.CreateAsync(reviewUser, "review");

                        await userManager.AddToRoleAsync(reviewUser, Constants.ReviewerRole);
                    }
                })
                .Wait();

            return app;
        }
    }
}