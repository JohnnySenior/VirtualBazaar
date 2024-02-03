using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace VirtualBazaar.Core.Services.Orchestrations.Admins
{
    public partial class AdminOrchestrationService
    {
        private async ValueTask<bool> StartAsync(Update update)
        {
            if (update.Message.Text is startCommant)
            {
                var markup = ContactMarkup();

                await this.adminTelegramService.SendMessageAsync(
                    userTelegramId: update.Message.Chat.Id,
                    replyMarkup: markup,
                    message: "Welcome to Virtual Bazaar my dear admin!\nShare ot send number of your organization please!");

                return true;
            }

            return false;
        }
    }
}
