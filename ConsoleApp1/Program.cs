using VirtualBazaar.Core.Brokers.Storages;
using VirtualBazaar.Core.Models.Foundations.Categories;
using VirtualBazaar.Core.Models.Foundations.Orders;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
        };
        
        var category = new Category
        {
            Id = Guid.NewGuid(),
        };

        var storage = new StorageBroker();

        await storage.InsertOrderAsync(order);
        await storage.InsertCategoryAsync(category);
    }
}