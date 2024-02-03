using System.Threading.Tasks;
using VirtualBazaar.Core.Models.Foundations.Admins;

namespace VirtualBazaar.Core.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Admin> InsertAdminAsync(Admin admin);
        ValueTask<Admin> UpdateAdminAsync(Admin admin);
    }
}
