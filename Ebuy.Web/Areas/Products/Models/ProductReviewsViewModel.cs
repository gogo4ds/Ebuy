namespace Ebuy.Web.Areas.Products.Models
{
    using System.Collections.Generic;
    using Ebuy.Web.Areas.Administration.Models.Reviews;

    public class ProductReviewsViewModel
    {
        public ProductViewModel Product { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; }
    }
}