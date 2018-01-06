namespace Ebuy.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Ebuy.Data.Models;

    public class EbuyDbContext : IdentityDbContext<User>
    {
        public EbuyDbContext(DbContextOptions<EbuyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<CustomerProduct> CustomerProducts { get; set; }

        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Product>()
                .HasOne(p => p.Seller)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SellerId);

            builder
                .Entity<CustomerProduct>()
                .HasKey(cp => new { cp.CustomerId, cp.ProductId });

            builder
                .Entity<CustomerProduct>()
                .HasOne(cp => cp.Customer)
                .WithMany(s => s.Products)
                .HasForeignKey(cp => cp.CustomerId);

            builder
                .Entity<CustomerProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.Buyers)
                .HasForeignKey(cp => cp.ProductId);

            builder
                .Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.UserId);

            builder
                .Entity<Review>()
                .HasOne(r => r.Author)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.UserId);

            builder.Entity<Category>()
                .HasOne(p => p.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(p => p.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}