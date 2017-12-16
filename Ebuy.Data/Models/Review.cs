namespace Ebuy.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Ebuy.Data.Models.Products;

    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string User { get; set; }

        public double Score { get; set; }
    }
}