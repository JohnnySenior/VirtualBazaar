using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualBazaar.Core.Models.Foundations;

namespace VirtualBazaar.Core.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Product> Products { get; set; }

        public async ValueTask<Product> InsertProductAsync(Product product) =>
            await InsertProductAsync(product);

        public async ValueTask<Product> SelectProductByIdAsync(Guid id) =>
            await SelectAsync<Product>(id);

        public IQueryable<Product> SelectAllProducts() =>
            SelectAll<Product>();

        public async ValueTask<Product> UpdateProductAsync(Product product) =>
            await UpdateProductAsync(product);

        public async ValueTask<Product> DeleteProductByIdAsync(Product product) =>
            await DeleteProductAsync(product);
    }
}
