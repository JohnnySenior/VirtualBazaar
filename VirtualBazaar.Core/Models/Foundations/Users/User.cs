using System;

namespace VirtualBazaar.Core.Models.Foundations.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public long TelegramId { get; set; }

        public UserStatus UserStatus { get; set; }
    }
}
