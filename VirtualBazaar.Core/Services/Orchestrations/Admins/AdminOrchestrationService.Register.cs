using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using VirtualBazaar.Core.Models.Foundations.Admins;

namespace VirtualBazaar.Core.Services.Orchestrations.Admins
{
    public partial class AdminOrchestrationService
    {
        private async ValueTask<bool> RegisterAsync(Update update)
        {
            var admin = this.adminService.RetrieveAllAdmins()
                .FirstOrDefault(a => a.TelegramId == update.Message.Chat.Id);

            if (admin is not null)
            {
                if (admin.AdminStatus is AdminStatus.Register)
                {
                    string phoneNumber = update.Message.Text;

                    if (update.Message.Type is MessageType.Contact)
                    {
                        phoneNumber = update.Message.Contact.PhoneNumber;
                    }
                    if (CheckPhoneNumber(phoneNumber))
                    {
                        admin.PhoneNumber = phoneNumber;
                        admin.AdminStatus = AdminStatus.Contact;
                        await this.adminService.ModifyAdminAsync(admin);

                        ReplyKeyboardMarkup markup = LocationMarkup();

                        await this.adminTelegramService.SendMessageAsync(
                            userTelegramId: update.Message.Chat.Id,
                            replyMarkup: markup,
                            message: "Good, please share or send your address 📍:");
                    }
                    else
                    {
                        await this.adminTelegramService.SendMessageAsync(
                            userTelegramId: update.Message.Chat.Id,
                            message: "Number is invalid, please try again.");
                    }

                    return true;
                }
                if (admin.AdminStatus is AdminStatus.Contact)
                {
                    string address = update.Message.Text;
                    address = await IfTypeOfMessageIsLocation(update, address);
                    admin.Address = address;
                    admin.AdminStatus = AdminStatus.Location;
                    await this.adminService.ModifyAdminAsync(admin);

                    await this.adminTelegramService.SendMessageAsync(
                        userTelegramId: update.Message.Chat.Id,
                        replyMarkup: new ReplyKeyboardRemove(),
                        message: "Good, Write organization name 👀:");

                    return true;
                }
                if (admin.AdminStatus is AdminStatus.Location)
                {
                    string organizationName = update.Message.Text;
                    admin.OrganizationName = organizationName;
                    admin.AdminStatus = AdminStatus.Active;
                    await this.adminService.ModifyAdminAsync(admin);
                    ReplyKeyboardMarkup markup = MenuMarkup();

                    await this.adminTelegramService.SendMessageAsync(
                        userTelegramId: update.Message.Chat.Id,
                        replyMarkup: markup,
                        message: "Good, Choose options 👀:");

                    return true;
                }
            }

            return false;
        }

        private bool CheckPhoneNumber(string phoneNumber)
        {
            if (phoneNumber[0] == '+'
                && phoneNumber.Length >= 8)
            {
                return true;
            }

            return false;
        }
    }
}
