namespace Ebuy.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Ebuy.Data.Models.Contracts;

    public abstract class Product : IProduct
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}