using System.Threading.Tasks;
using VirtualBazaar.Core.Models.Foundations;

namespace VirtualBazaar.Core.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<Admin> InsertAdminAsync(Admin admin);
        ValueTask<Admin> UpdateAdminAsync(Admin admin);
    }
}
