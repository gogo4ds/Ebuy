namespace Ebuy.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        public byte? PhoneNumber { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public List<Address> Addresses { get; set; } = new List<Address>();

        public List<CustomerProduct> Products { get; set; } = new List<CustomerProduct>();
    }
}