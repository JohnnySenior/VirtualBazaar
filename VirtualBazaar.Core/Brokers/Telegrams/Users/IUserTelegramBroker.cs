using System.Threading.Tasks;
using System;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;

namespace VirtualBazaar.Core.Brokers.Telegrams.Users
{
    public interface IUserTelegramBroker
    {
        ValueTask SendMessageAsync(long userTelegramId,
            string message,
            int? replyToMessageId = null,
            ParseMode? parseMode = null,
            IReplyMarkup? replyMarkup = null);

        void StartBot(
             Func<ITelegramBotClient, Update, CancellationToken, Task> handleUpdate);
    }
}
