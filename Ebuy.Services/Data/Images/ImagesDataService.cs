namespace Ebuy.Services.Data.Images
{
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Ebuy.Data;
    using Ebuy.Data.Models;
    using Ebuy.Web.Common.Extensions;
    using Microsoft.EntityFrameworkCore;

    public class ImagesDataService : BaseDataService<Image>, IImagesDataService
    {
        public ImagesDataService(EbuyDbContext context) : base(context)
        {
        }

        public async Task DeleteByImageNamesAndRootDirectory(IEnumerable<string> imageNames, string rootDirectoryPath)
        {
            foreach (var imageName in imageNames)
            {
                var image = await this.Repository.FirstOrDefaultAsync(i => i.Title == imageName);
                this.Repository.Remove(image);

                var file = new FileInfo(Path.Combine(rootDirectoryPath, imageName));
                await file.DeleteAsync();
            }
            
            await this.Context.SaveChangesAsync();
        }
    }
}