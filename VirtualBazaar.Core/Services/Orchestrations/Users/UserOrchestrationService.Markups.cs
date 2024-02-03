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
               new KeyboardButton[]{ new KeyboardButton("Share contact 📞") 
               { RequestContact = true } },
            })
            {
                ResizeKeyboard = true
            };
        }
        
        private static ReplyKeyboardMarkup LocationMarkup()
        {
            return new ReplyKeyboardMarkup(new KeyboardButton[][]
            {
               new KeyboardButton[]{ new KeyboardButton("Share location 📍") 
               { RequestLocation = true } },
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
                    new KeyboardButton("Me 👤"),
                    new KeyboardButton("Settings ⚙️"),
                    new KeyboardButton("Review 📝"),
                    new KeyboardButton("Contact us ☎️")
                }
            };

            return new ReplyKeyboardMarkup(keyboardButtons)
            {
                ResizeKeyboard = true
            };
        }
        
        private static ReplyKeyboardMarkup SettingsMarkup()
        {
            var keyboardButtons = new List<KeyboardButton[]>
            {
                new KeyboardButton[]
                {
                    new KeyboardButton("Change name 🪄"),
                    new KeyboardButton("Change address 🏡"),
                    new KeyboardButton("Change phone number 📲")
                },
                new KeyboardButton[]
                {
                    new KeyboardButton("⬅️ Back")
                }
            };

            return new ReplyKeyboardMarkup(keyboardButtons)
            {
                ResizeKeyboard = true
            };
        }
    }
}
