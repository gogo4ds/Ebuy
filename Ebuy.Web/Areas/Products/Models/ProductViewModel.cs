namespace Ebuy.Web.Areas.Products.Models
{
    using Ebuy.Data.Models;
    using Ebuy.Web.Infrastructure.Mapping;

    public class ProductViewModel : IMapFrom<Product>
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}