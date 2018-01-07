namespace Ebuy.Services.Data.Images
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Ebuy.Data.Models;

    public interface IImagesDataService : IDataService<Image>
    {
        Task DeleteByImageNamesAndRootDirectory(IEnumerable<string> imageNames, string rootDirectoryPath);
    }
}