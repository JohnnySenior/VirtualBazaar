using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirtualBazaar.Core.Models.Foundations;

namespace VirtualBazaar.Core.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<Admin> Admins { get; set; }

        public async ValueTask<Admin> InsertAdminAsync(Admin admin) =>
            await InsertAsync(admin);
        
        public async ValueTask<Admin> UpdateAdminAsync(Admin admin) =>
            await UpdateAsync(admin);
    }
}
