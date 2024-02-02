using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using VirtualBazaar.Core.Brokers.Loggings;
using VirtualBazaar.Core.Brokers.Telegrams.Admins;

namespace VirtualBazaar.Core.Services.Foundations.Telegrams.Users
{
    public class UserTelegramService
    {
        private readonly IAdminTelegramBroker userTelegramBroker;
        private readonly ILoggingBroker loggingBroker;

        public UserTelegramService(IAdminTelegramBroker userTelegramBroker,
            ILoggingBroker loggingBroker)
        {
            this.userTelegramBroker = userTelegramBroker;
            this.loggingBroker = loggingBroker;
        }

        public void StartBot(
              Func<ITelegramBotClient, Update, CancellationToken, Task> handleUpdate)
        {
            this.userTelegramBroker.StartBot(
                handleUpdate: handleUpdate);
        }

        public async ValueTask SendTextMessageAsync(
            long userTelegramId,
            string message,
            int? replyToMessageId = null,
            ParseMode? parseMode = null,
            IReplyMarkup? replyMarkup = null)
        {
            await userTelegramBroker.SendTextMessageAsync(
                userTelegramId: userTelegramId,
                message: message,
                parseMode: parseMode,
                replyToMessageId: replyToMessageId,
                replyMarkup: replyMarkup);
        }
    }
}
