using System.Threading.Tasks;
using VirtualBazaar.Core.Models.Foundations.Users;

namespace VirtualBazaar.Core.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertUserAsync(User user);
        ValueTask<User> UpdateUserAsync(User user);
    }
}
