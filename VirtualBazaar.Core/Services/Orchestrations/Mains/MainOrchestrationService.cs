using VirtualBazaar.Core.Services.Foundations.Telegrams.Admins;
using VirtualBazaar.Core.Services.Foundations.Telegrams.Users;

namespace VirtualBazaar.Core.Services.Orchestrations.Mains
{
    public class MainOrchestrationService : IMainOrchestrationService
    {
        private readonly IAdminTelegramService adminTelegramService;
        private readonly IUserTelegramService userTelegramService;

        public MainOrchestrationService(
            IAdminTelegramService adminTelegramService, 
            IUserTelegramService userTelegramService)
        {
            this.adminTelegramService = adminTelegramService;
            this.userTelegramService = userTelegramService;
        }
    }
}
