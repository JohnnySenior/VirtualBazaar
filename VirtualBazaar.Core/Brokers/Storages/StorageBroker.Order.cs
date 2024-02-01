using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using VirtualBazaar.Core.Models.Foundations;

namespace VirtualBazaar.Core.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Order> Orders { get; set; }

        public async ValueTask<Order> InsertOrderAsync(Order product) =>
            await InsertOrderAsync(product);

        public async ValueTask<Order> SelectOrderByIdAsync(Guid id) =>
            await SelectAsync<Order>(id);

        public IQueryable<Order> SelectAllOrders() =>
            SelectAll<Order>();

        public async ValueTask<Order> UpdateOrderAsync(Order product) =>
            await UpdateOrderAsync(product);

        public async ValueTask<Order> DeleteOrderByIdAsync(Order product) =>
            await DeleteOrderAsync(product);
    }
}
