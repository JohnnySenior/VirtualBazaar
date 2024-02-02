using System.Linq;
using System.Threading.Tasks;
using System;
using VirtualBazaar.Core.Models.Foundations;

namespace VirtualBazaar.Core.Services.Foundations.Orders
{
    public interface IOrderService
    {
        ValueTask<Order> AddOrderAsync(Order order);
        ValueTask<Order> RetrieveOrderWithTeacherByIdAsync(Guid orderId);
        IQueryable<Order> RetrieveAllOrders();
        ValueTask<Order> ModifyOrderAsync(Order order);
        ValueTask<Order> RemoveOrderAsync(Order order);
    }
}
