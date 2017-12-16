namespace Ebuy.Data.Models.Products
{
    using Ebuy.Data.Enumerations;

    public class Tv : Product
    {
        public double Inches { get; set; }

        public DisplayType Display { get; set; }
    }
}