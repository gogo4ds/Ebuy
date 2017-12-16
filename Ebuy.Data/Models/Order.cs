namespace Ebuy.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId  { get; set; }

        public Customer Customer { get; set; }

        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }

        public Seller Seller { get; set; }

        public decimal TotalAmount { get; set; }

        public bool IsPaid { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }

        public Address Address { get; set; }
    }
}