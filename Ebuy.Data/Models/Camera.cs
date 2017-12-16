namespace Ebuy.Data.Models
{
    using Ebuy.Data.Enumerations;

    public class Camera : Product
    {
        public CameraType Type { get; set; }
    }
}