namespace Ebuy.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Seller
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Address))]
        public int? AddressId { get; set; }

        public Address Address { get; set; }

        public List<Order> Orders { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}