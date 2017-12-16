namespace Ebuy.Data.Models
{
    public class SellerProduct
    {
        public int SellerId { get; set; }

        public Seller Seller { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public bool IsInStock { get; set; }
    }
}