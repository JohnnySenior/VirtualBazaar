using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using VirtualBazaar.Core.Models.Foundations.Users;

namespace VirtualBazaar.Core.Services.Orchestrations.Users
{
    public partial class UserOrchestrationService
    {
        private const string changeNameCommand = "Change name 🪄";
        private const string changePhoneNumberCommand = "Change phone number 📲";

        private async ValueTask<bool> SettingsAsync(Update update)
        {
            var user = this.userService.RetrieveAllUsers()
                .FirstOrDefault(u => u.TelegramId == update.Message.Chat.Id);

            if (user is not null)
            {
                if(await HandleSettingsCommand(update, user))
                    return true;
                if (await ChangeNameAsync(update, user))
                    return true;
                if(await ChangePhoneNumberAsync(update, user))
                    return true;
            }

            return false;
        }

        private async ValueTask<bool> HandleSettingsCommand(Update update, Models.Foundations.Users.User user)
        {
            if (update.Message.Text is settingsCommand)
            {
                user.UserStatus = UserStatus.Settings;
                await this.userService.ModifyUserAsync(user);
                ReplyKeyboardMarkup markup = SettingsMarkup();

                await this.userTelegramService.SendMessageAsync(
                       userTelegramId: update.Message.Chat.Id,
                       replyMarkup: markup,
                       message: "Settings 👀:");

                return true;
            }

            return false;
        }

        private async ValueTask<bool> ChangePhoneNumberAsync(Update update, Models.Foundations.Users.User user)
        {
            if (update.Message.Text is changePhoneNumberCommand
                                && user.UserStatus is UserStatus.Settings)
            {
                user.UserStatus = UserStatus.ChangePhoneNumber;
                await this.userService.ModifyUserAsync(user);

                await this.userTelegramService.SendMessageAsync(
                      userTelegramId: update.Message.Chat.Id,
                      message: "Please, send your new phone number 👻:");

                return true;
            }
            if (user.UserStatus is UserStatus.ChangePhoneNumber)
            {
                string phoneNumber = update.Message.Text;

                if (update.Message.Type is MessageType.Contact)
                {
                    phoneNumber = update.Message.Contact.PhoneNumber;
                }

                if (CheckUserPhoneNumber(phoneNumber))
                {
                    user.PhoneNumber = phoneNumber;
                    user.UserStatus = UserStatus.Active;
                    await this.userService.ModifyUserAsync(user);
                    ReplyKeyboardMarkup markup = MenuMarkup();

                    await this.userTelegramService.SendMessageAsync(
                          userTelegramId: update.Message.Chat.Id,
                          replyMarkup: markup,
                          message: "Changed 😁");
                }
                else
                {
                    await this.userTelegramService.SendMessageAsync(
                        userTelegramId: update.Message.Chat.Id,
                        message: "Number is invalid, please try again.");

                }

                return true;
            }

            return false;
        }

        private async ValueTask<bool> ChangeNameAsync(Update update, Models.Foundations.Users.User user)
        {
            if (update.Message.Text is changeNameCommand
                && user.UserStatus is UserStatus.Settings)
            {
                user.PhoneNumber = update.Message.Text;
                user.UserStatus = UserStatus.ChangeName;
                await this.userService.ModifyUserAsync(user);

                await this.userTelegramService.SendMessageAsync(
                      userTelegramId: update.Message.Chat.Id,
                      message: "Please, send your new name 👻:");

                return true;
            }
            if (user.UserStatus is UserStatus.ChangeName)
            {
                user.Name = update.Message.Text;
                user.UserStatus = UserStatus.Active;
                await this.userService.ModifyUserAsync(user);
                ReplyKeyboardMarkup markup = MenuMarkup();

                await this.userTelegramService.SendMessageAsync(
                      userTelegramId: update.Message.Chat.Id,
                      replyMarkup: markup,
                      message: "Changed 😁");

                return true;
            }

            return false;
        }
    }
}
