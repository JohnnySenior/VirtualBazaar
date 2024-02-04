using System.Linq;
using System.Threading.Tasks;
using VirtualBazaar.Core.Models.Foundations.Categories;

namespace VirtualBazaar.Core.Brokers.Storages
{
    public partial class StorageBroker
    {
        public async ValueTask<Category> InsertCategoryAsync(Category category) =>
           await InsertCategoryAsync(category);

        public IQueryable<Category> SelectAllCategories() =>
            SelectAll<Category>();

        public async ValueTask<Category> DeleteCategoryByIdAsync(Category category) =>
            await DeleteAsync(category);
    }
}
