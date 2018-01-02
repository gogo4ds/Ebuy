namespace Ebuy.Web.Areas.Products.Models.Categories
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Ebuy.Data.Models;
    using Ebuy.Web.Infrastructure.Mapping;

    public class CategoryProductsViewModel : IMapFrom<Category>, IHaveCustomMapping
    {
        public int CategoryId { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Category, CategoryProductsViewModel>()
                .ForMember(m => m.CategoryId, opt => opt.MapFrom(c => c.Id))
                .ForMember(m => m.Products, opt => opt.MapFrom(c => c.Products));
        }
    }
}
