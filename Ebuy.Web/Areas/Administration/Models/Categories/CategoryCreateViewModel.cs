namespace Ebuy.Web.Areas.Administration.Models.Categories
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Ebuy.Data.Models;
    using Ebuy.Web.Infrastructure.Mapping;

    public class CategoryCreateViewModel : IMapFrom<Category>, IHaveCustomMapping
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2), MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Order { get; set; }

        public string ParentName { get; set; }

        public int? ParentId { get; set; }

        public void ConfigureMapping(Profile mapper)
        {
            mapper
                .CreateMap<Category, CategoryCreateViewModel>()
                .ForMember(ccvm => ccvm.ParentName, opt => opt.MapFrom(c => c.Parent.Name));
        }
    }
}