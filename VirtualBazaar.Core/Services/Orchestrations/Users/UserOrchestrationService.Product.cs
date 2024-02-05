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
                var checkProductOrNot = CheckOnChooseProduct(update);

                if (user.UserStatus is UserStatus.Category
                    && checkProductOrNot is true)
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
                        caption: $"Dish 🍓: {product.Name}\nPrice 💵: {product.Price}\nRemindn 💡: {product.Count}");

                    return true;
                }

                return false;
            }

            return false;
        }

        public bool CheckOnChooseProduct(Update update)
        {
            int count = 0;

            var products = this.productService
                       .RetrieveAllProducts();

            foreach (var product in products)
            {
                if (update.Message.Text == product.Name)
                {
                    count++;
                }
            }

            if (count > 0)
                return true;
            else
                return false;
        }
    }
}
