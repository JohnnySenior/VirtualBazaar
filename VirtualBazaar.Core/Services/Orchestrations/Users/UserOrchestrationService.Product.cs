using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using VirtualBazaar.Core.Models.Foundations.Users;

namespace VirtualBazaar.Core.Services.Orchestrations.Users
{
    public partial class UserOrchestrationService
    {
        private async ValueTask<bool> ProductAsync(Update update)
        {
            var user = this.userService.RetrieveAllUsers()
                .FirstOrDefault(u => u.TelegramId == update.Message.Chat.Id);

            if (user is not null)
            {
                if (user.UserStatus is UserStatus.Category)
                {
                    var product = this.productService
                        .RetrieveAllProducts().FirstOrDefault(p => p.Name == update.Message.Text);

                    user.UserStatus = UserStatus.Product;
                    await this.userService.ModifyUserAsync(user);
                    var markup = ProductMarkup();

                    await this.userTelegramService.SendPhotoAsync(
                        telegramId: update.Message.Chat.Id,
                        replyMarkup: markup,
                        photo: InputFile.FromUri($"{product.PhotoUrl}"),
                        caption: $"Dish 🍓: {product.Name}\nPrice: {product.Price} 💵\nRemind: {product.Count} 💡");

                    return true;
                }

                return false;
            }

            return false;
        }
    }
}
