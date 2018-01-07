namespace Ebuy.Web.Areas.Products.Models.ShoppingCart
{
    using Ebuy.Data.Models;

    public class CartItem
    {
        public int ProductId { get; set; }

        public ProductViewModel Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price => this.Product.Price * this.Quantity;
    }
}