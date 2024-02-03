using System;

namespace VirtualBazaar.Core.Models.Foundations.Orders
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
