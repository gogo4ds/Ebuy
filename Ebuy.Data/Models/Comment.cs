namespace Ebuy.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Ebuy.Data.Models.Products;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Product))]
        public int? ProductId { get; set; }

        public Product Product { get; set; }

        [ForeignKey(nameof(Review))]
        public int? ReviewId { get; set; }

        public Review Review { get; set; }
    }
}