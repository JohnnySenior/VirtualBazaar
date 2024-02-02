using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace VirtualBazaar.Core.Brokers.Telegrams.Admins
{
    public interface IAdminTelegramBroker
    {
        ValueTask SendTextMessageAsync(
             long userTelegramId,
             string message,
             int? replyToMessageId = null,
             ParseMode? parseMode = null,
             IReplyMarkup? replyMarkup = null);

        void StartBot(
             Func<ITelegramBotClient, Update, CancellationToken, Task> handleUpdate);


    }
}
