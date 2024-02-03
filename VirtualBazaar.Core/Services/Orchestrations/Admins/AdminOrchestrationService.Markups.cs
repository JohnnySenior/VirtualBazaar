using Telegram.Bot.Types.ReplyMarkups;

namespace VirtualBazaar.Core.Services.Orchestrations.Admins
{
    public partial class AdminOrchestrationService
    {
        private static ReplyKeyboardMarkup ContactMarkup()
        {
            return new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
               new KeyboardButton[]{ new KeyboardButton("Share contact 📱") { RequestContact = true } },
            })
            {
                ResizeKeyboard = true
            };
        }
    }
}
