using System.Threading.Tasks;
using VirtualBazaar.Core.Models.Foundations.Admins;

namespace VirtualBazaar.Core.Services.Foundations.Admins
{
    public interface IAdminService
    {
        ValueTask<Admin> AddAdminAsync(Admin admin);
        ValueTask<Admin> ModifyAdminAsync(Admin admin);
    }
}
