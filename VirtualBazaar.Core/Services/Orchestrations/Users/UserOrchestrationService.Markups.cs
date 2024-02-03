using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;

namespace VirtualBazaar.Core.Services.Orchestrations.Users
{
    public partial class UserOrchestrationService
    {
        private static ReplyKeyboardMarkup ContactMarkup()
        {
            return new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
               new KeyboardButton[]{ new KeyboardButton("Share contact 📞") { RequestContact = true } },
            })
            {
                ResizeKeyboard = true
            };
        }
        
        private static ReplyKeyboardMarkup MenuMarkup()
        {
            var keyboardButtons = new List<KeyboardButton[]>
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("Menu 🛍")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("Contact us ☎️"),
                    new KeyboardButton("Settings ⚙️"),
                    new KeyboardButton("Review 🧾")
                }
            };

            return new ReplyKeyboardMarkup(keyboardButtons)
            {
                ResizeKeyboard = true
            };
        }
    }
}
