namespace Ebuy.Web.Areas.Products.Models.Products
{
    using Ebuy.Data.Models;
    using Ebuy.Web.Infrastructure.Mapping;

    public class SimpleProductViewModel : IMapFrom<Product>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string BrandName { get; set; }

        public decimal Price { get; set; }
    }
}