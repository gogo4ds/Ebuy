namespace Ebuy.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Review
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string UserId { get; set; }

        public User Author { get; set; }

        public double Score { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}