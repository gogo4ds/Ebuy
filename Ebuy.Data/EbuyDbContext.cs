namespace Ebuy.Data
{
    using Ebuy.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class EbuyDbContext : IdentityDbContext<User>
    {
        public EbuyDbContext(DbContextOptions<EbuyDbContext> options)
            :base(options)
        {
        }

        public DbSet<Camera> Cameras { get; set; }
    }
}