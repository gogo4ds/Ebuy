namespace Ebuy.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
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

        public string ImageName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public double? Rating { get; set; }

        [DefaultValue(1)]
        public int QuantityInStock { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int SellerId { get; set; }

        public Seller Seller { get; set; }

        public List<CustomerProduct> Buyers { get; set; } = new List<CustomerProduct>();
    }
}