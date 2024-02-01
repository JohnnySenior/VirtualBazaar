namespace VirtualBazaar.Core.Models.Foundations
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
