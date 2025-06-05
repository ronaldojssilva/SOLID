namespace Checkout
{
    public class Cart
    {
        public IEnumerable<Item> Items { get; internal set; }
    }

    public class Item
    {
        public int Stock { get; internal set; }
        public int Quantity { get; internal set; }
        public string Name { get; internal set; }
        public decimal Price { get; internal set; }
    }
}
