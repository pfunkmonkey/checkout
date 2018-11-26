namespace Checkout
{
    public interface IItem
    {
        string SKU { get; set; }
        string Description { get; set; }
        SpecialPrice SpecialPrice { get; set; }
        decimal Price { get; set; }
    }
}