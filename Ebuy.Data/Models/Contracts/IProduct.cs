namespace Ebuy.Data.Models.Contracts
{
    public interface IProduct
    {
        int Id { get; set; }

        string  Name { get; set; }

        decimal Price { get; set; }
    }
}