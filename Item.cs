namespace Checkout
{
    public class Item : IItem
    {
        public string SKU { get; set; }
        public string Description { get; set; }
        public SpecialPrice SpecialPrice { get; set; }
        public decimal Price { get; set; }
    }
}