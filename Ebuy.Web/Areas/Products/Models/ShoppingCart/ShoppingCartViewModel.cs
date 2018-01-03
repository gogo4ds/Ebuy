namespace Ebuy.Web.Areas.Products.Models.ShoppingCart
{
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCartViewModel
    {
        public int UserId { get; set; }

        public IList<CartItem> CartItems { get; set; } = new List<CartItem>();

        public decimal TotalPrice => this.CartItems.Sum(ci => ci.Price);
    }
}