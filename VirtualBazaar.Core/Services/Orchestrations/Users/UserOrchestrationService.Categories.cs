using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using VirtualBazaar.Core.Models.Foundations.Users;

namespace VirtualBazaar.Core.Services.Orchestrations.Users
{
    public partial class UserOrchestrationService
    {
        private async ValueTask<bool> CategoriesAsync(Update update)
        {
            var user = this.userService.RetrieveAllUsers()
                .FirstOrDefault(u => u.TelegramId == update.Message.Chat.Id);

            if (user is not null)
            {
                if (user.UserStatus is UserStatus.Menu)
                {
                    var category = this.categoryService
                        .RetrieveAllCategorys().FirstOrDefault(c => c.Name == update.Message.Text);

                    var products = this.productService
                        .RetrieveAllProducts().Where(p => p.CategoryId == category.Id);

                    var markup = ProductsMarkup(products);
                    user.UserStatus = UserStatus.Category;
                    await this.userService.ModifyUserAsync(user);

                    await this.userTelegramService.SendMessageAsync(
                           userTelegramId: update.Message.Chat.Id,
                           replyMarkup: markup,
                           message: $"Good choice, what type of {category.Name} do you want? 🤤");
                }
            }

            return false;
        }
    }
}
