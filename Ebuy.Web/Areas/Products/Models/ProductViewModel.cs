namespace Ebuy.Web.Areas.Products.Models
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Ebuy.Data.Models;
    using Ebuy.Web.Infrastructure.Mapping;

    public class ProductViewModel : IMapFrom<Product>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [MinLength(2), MaxLength(100)]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        public string CategoryName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be above 0")]
        public decimal Price { get; set; }

        [MinLength(2)]
        [StringLength(100, ErrorMessage = "Brand Name must be in range 2 and 100 symbols")]
        public string BrandName { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(p => p.Category.Name));
        }
    }
}