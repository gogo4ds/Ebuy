namespace Ebuy.Data.Models.Products
{
    using Ebuy.Data.Enumerations;

    public class Camera : Product
    {
        public CameraType Type { get; set; }

        public double Apperture { get; set; }

        public double FocalLenght { get; set; }
    }
}