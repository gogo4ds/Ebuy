namespace Ebuy.Data.Models.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Ebuy.Data.Models.Contracts;

    public class Product : IProduct
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string BrandName { get; set; }

        public decimal Price { get; set; }

        public byte[] Picture { get; set; }

        public double? Rating { get; set; }

        public List<SellerProduct> Sellers { get; set; } = new List<SellerProduct>();

        public List<CustomerProduct> Buyers { get; set; } = new List<CustomerProduct>();
    }
}