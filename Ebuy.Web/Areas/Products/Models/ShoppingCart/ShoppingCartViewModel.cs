namespace Ebuy.Web.Areas.Products.Models.ShoppingCart
{
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCartViewModel
    {
        public string UserId { get; set; }

        public IList<CartItem> CartItems { get; set; } = new List<CartItem>();        

        public decimal SubTotal => this.CartItems.Sum(ci => ci.Price);

        public decimal ShippingPrice { get; set; }

        public decimal TotalPrice => this.SubTotal + this.ShippingPrice;
    }
}