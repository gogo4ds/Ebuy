namespace Ebuy.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int ParentId { get; set; }

        public Category Parent { get; set; }

        [InverseProperty(nameof(Parent))]
        public List<Category> Children { get; set; } = new List<Category>();

        public int Order { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
