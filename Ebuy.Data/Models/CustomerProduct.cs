namespace Ebuy.Data.Models
{
    using Ebuy.Data.Models.Products;

    public class CustomerProduct
    {
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}