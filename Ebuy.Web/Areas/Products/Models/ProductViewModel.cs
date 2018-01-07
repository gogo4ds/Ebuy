namespace Ebuy.Web.Areas.Products.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using Ebuy.Data.Models;
    using Ebuy.Web.Infrastructure.Mapping;

    public class ProductViewModel : IMapFrom<Product>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public int? SellerId { get; set; }

        public string SellerUserName { get; set; }

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

        [StringLength(1000)]
        public string Description { get; set; }

        public List<string> ImageNames { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.CategoryName, opt => opt.MapFrom(p => p.Category.Name));

            mapper
                .CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.SellerUserName, opt => opt.MapFrom(p => p.Seller.User.UserName));

            mapper
                .CreateMap<Product, ProductViewModel>()
                .ForMember(m => m.ImageNames, opt => opt.MapFrom(p =>  p.Images.Select(i => i.Image.Title)));
        }
    }
}