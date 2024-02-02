using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace VirtualBazaar.Core.Brokers.Telegrams.Admins
{
    public class AdminTelegramBroker : IAdminTelegramBroker
    {
        private readonly ITelegramBotClient telegramBotClient;

        public AdminTelegramBroker()
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
