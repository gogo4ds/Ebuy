namespace Ebuy.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public List<ProductImage> Products { get; set; } = new List<ProductImage>();
    }
}