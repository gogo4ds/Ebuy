namespace Ebuy.Web.Areas.Administration.Models.Categories
{
    using System.Collections.Generic;
    using AutoMapper;
    using Ebuy.Data.Models;
    using Ebuy.Web.Infrastructure.Mapping;

    public class CategoryDeleteViewModel : IMapFrom<Category>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Category> Children { get; set; } = new List<Category>();

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Category, CategoryDeleteViewModel>()
                .ForMember(ccvm => ccvm.Children, opt => opt.MapFrom(c => c.Children));
        }
    }
}