using System.Linq;
using System.Threading.Tasks;
using System;
using VirtualBazaar.Core.Models.Foundations.Orders;

namespace VirtualBazaar.Core.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Order> InsertOrderAsync(Order product);
        ValueTask<Order> UpdateOrderAsync(Order product);
        ValueTask<Order> SelectOrderByIdAsync(Guid id);
        IQueryable<Order> SelectAllOrders();
        ValueTask<Order> DeleteOrderByIdAsync(Order product);
    }
}
