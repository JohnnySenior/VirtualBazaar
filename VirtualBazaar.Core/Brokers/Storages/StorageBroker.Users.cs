using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualBazaar.Core.Models.Foundations.Users;

namespace VirtualBazaar.Core.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }

        public async ValueTask<User> InsertUserAsync(User user) =>
            await InsertAsync(user);

        public async ValueTask<User> UpdateUserAsync(User user) =>
            await UpdateAsync(user);
    }
}
