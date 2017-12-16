namespace Ebuy.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Address
    {
        [Key]
        public int Id { get; set; }

        [MinLength(5), MaxLength(200)]
        public string Text { get; set; }

        [MinLength(3), MaxLength(100)]
        public string Country { get; set; }

        [MinLength(2), MaxLength(100)]
        public string CityName { get; set; }

        public int PostCode { get; set; }
    }
}