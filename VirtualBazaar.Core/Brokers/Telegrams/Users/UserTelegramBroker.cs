using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace VirtualBazaar.Core.Brokers.Telegrams.Users
{
    public class UserTelegramBroker : IUserTelegramBroker
    {
        private readonly ITelegramBotClient telegramBotClient;
        private static Func<Update, ValueTask> taskHandler;

        public UserTelegramBroker()
        {
            string token = "";
            this.telegramBotClient = new TelegramBotClient(token);
        }

        public void StartBot(
              Func<ITelegramBotClient, Update, CancellationToken, Task> handleUpdate)
        {
            this.telegramBotClient.StartReceiving(
                updateHandler: handleUpdate,
                pollingErrorHandler: HandleErrorAsync);
        }

        public async ValueTask SendTextMessageAsync(
            long userTelegramId,
            string message,
            int? replyToMessageId = null,
            ParseMode? parseMode = null,
            IReplyMarkup? replyMarkup = null)
        {
            await telegramBotClient.SendTextMessageAsync(
                chatId: userTelegramId,
                text: message,
                parseMode: parseMode,
                replyToMessageId: replyToMessageId,
                replyMarkup: replyMarkup);
        }

        private Task HandleErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
