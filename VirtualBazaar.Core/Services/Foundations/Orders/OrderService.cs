using System.Linq;
using System.Threading.Tasks;
using System;
using VirtualBazaar.Core.Brokers.Storages;
using VirtualBazaar.Core.Brokers.Loggings;
using VirtualBazaar.Core.Models.Foundations;

namespace VirtualBazaar.Core.Services.Foundations.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public OrderService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Order> AddOrderAsync(Order order) =>
            await this.storageBroker.InsertOrderAsync(order);

        public async ValueTask<Order> RetrieveOrderWithTeacherByIdAsync(Guid orderId) =>
            await this.storageBroker.SelectOrderByIdAsync(orderId);

        public IQueryable<Order> RetrieveAllOrders() =>
            this.storageBroker.SelectAllOrders();

        public async ValueTask<Order> ModifyOrderAsync(Order order) =>
            await this.storageBroker.UpdateOrderAsync(order);

        public async ValueTask<Order> RemoveOrderAsync(Order order) =>
            await this.storageBroker.DeleteOrderByIdAsync(order);
    }
}
