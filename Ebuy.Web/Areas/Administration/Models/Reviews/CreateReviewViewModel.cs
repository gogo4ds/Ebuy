namespace Ebuy.Web.Areas.Administration.Models.Reviews
{
    using Ebuy.Web.Areas.Products.Models.Products;

    public class CreateReviewViewModel
    {
        public ReviewViewModel Review { get; set; }

        public SimpleProductViewModel Product { get; set; }
    }
}