using System.Threading.Tasks;
using System;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using System.Threading;
using Telegram.Bot;

namespace VirtualBazaar.Core.Services.Foundations.Telegrams.Users
{
    public interface IUserTelegramService
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
