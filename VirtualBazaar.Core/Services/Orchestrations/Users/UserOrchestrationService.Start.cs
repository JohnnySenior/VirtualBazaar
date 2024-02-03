using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace VirtualBazaar.Core.Services.Orchestrations.Users
{
    public partial class UserOrchestrationService
    {
        private async ValueTask<bool> StartAsync(Update update)
        {
            if (update.Message.Text is startCommant)
            {
                var markup = ContactMarkup();

                await this.userTelegramService.SendMessageAsync(
                    userTelegramId: update.Message.Chat.Id,
                    replyMarkup: markup,
                    message: "Welcome to Virtual Bazaar!\nSend your number please!");

                return true;
            }

            return false;
        }
    }
}
