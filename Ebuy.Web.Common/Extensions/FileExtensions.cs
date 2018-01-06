namespace Ebuy.Web.Common.Extensions
{
    using System.IO;
    using System.Threading.Tasks;

    public static class FileExtensions
    {
        public static async Task DeleteAsync(this FileInfo file) =>
            await Task.Factory.StartNew(file.Delete);
    }
}
