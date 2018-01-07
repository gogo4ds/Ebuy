namespace Ebuy.Web.Areas.Administration.Models.Reviews
{
    using System.ComponentModel.DataAnnotations;
    using Ebuy.Data.Models;
    using Ebuy.Web.Infrastructure.Mapping;

    public class ReviewViewModel : IMapFrom<Review>
    {
        [Required]
        public string Title{ get; set; }

        [Required]
        public string Content { get; set; }

        public int ProductId { get; set; }

        public double Score { get; set; }
    }
}