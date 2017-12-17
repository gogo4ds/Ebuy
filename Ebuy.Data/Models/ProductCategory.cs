namespace Ebuy.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ProductCategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int ParentId { get; set; }

        public ProductCategory Parent { get; set; }

        [InverseProperty(nameof(Parent))]
        public List<ProductCategory> Children { get; set; } = new List<ProductCategory>();

        public int Order { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
