namespace Ebuy.Services.Extensions
{
    using Microsoft.EntityFrameworkCore;

    public static class DbSetExtensions
    {
        public static void SaveChanges<T>(this DbSet<T> dbSet, DbContext context)
            where T : class
        {
            context.SaveChanges();
        }
    }
}