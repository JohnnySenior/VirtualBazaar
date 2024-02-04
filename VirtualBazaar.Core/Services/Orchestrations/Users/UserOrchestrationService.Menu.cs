using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using VirtualBazaar.Core.Models.Foundations.Users;

namespace VirtualBazaar.Core.Services.Orchestrations.Users
{
    public partial class UserOrchestrationService
    {
        private const string menuCommant = "Menu 🛍";

        private async ValueTask<bool> MenuAsync(Update update)
        {
            var user = this.userService.RetrieveAllUsers()
                .FirstOrDefault(u => u.TelegramId == update.Message.Chat.Id);

            if (update.Message.Text is menuCommant)
            {
                ReplyKeyboardMarkup markup = CategoriesMarkup();
                user.UserStatus = UserStatus.Menu;
                await this.userService.ModifyUserAsync(user);

                await this.userTelegramService.SendMessageAsync(
                           userTelegramId: update.Message.Chat.Id,
                           replyMarkup: markup,
                           message: "Welcome to Menu, choose what you like 🍓:");

                return true;
            }

            return false;
        }
    }
}
