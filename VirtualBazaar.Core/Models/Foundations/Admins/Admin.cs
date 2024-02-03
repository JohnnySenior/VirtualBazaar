using System;

namespace VirtualBazaar.Core.Models.Foundations.Admins
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public long TelegramId { get; set; }

        public AdminStatus AdminStatus { get; set; }
    }
}
