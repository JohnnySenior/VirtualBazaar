using System.Threading.Tasks;
using VirtualBazaar.Core.Brokers.Loggings;
using VirtualBazaar.Core.Brokers.Storages;
using VirtualBazaar.Core.Models.Foundations;

namespace VirtualBazaar.Core.Services.Foundations.Admins
{
    public class AdminService : IAdminService
    {
        private readonly IStorageBroker storageBroker;
        private readonly ILoggingBroker loggingBroker;

        public AdminService(
            IStorageBroker storageBroker,
            ILoggingBroker loggingBroker)
        {
            this.storageBroker = storageBroker;
            this.loggingBroker = loggingBroker;
        }

        public async ValueTask<Admin> AddAdminAsync(Admin admin) =>
            await this.storageBroker.InsertAdminAsync(admin);

        public async ValueTask<Admin> ModifyAdminAsync(Admin admin) =>
            await this.storageBroker.UpdateAdminAsync(admin);
    }
}
