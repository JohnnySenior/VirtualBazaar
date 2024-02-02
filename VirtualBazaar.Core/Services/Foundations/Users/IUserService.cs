using System.Threading.Tasks;
using VirtualBazaar.Core.Models.Foundations;

namespace VirtualBazaar.Core.Services.Foundations.Users
{
    public interface IUserService
    {
        ValueTask<User> AddUserAsync(User user);
        ValueTask<User> ModifyUserAsync(User user);
    }
}
