using System.Threading.Tasks;
using System.Threading;
using System;
using Telegram.Bot;
using VirtualBazaar.Core.Brokers.Loggings;
using VirtualBazaar.Core.Brokers.Telegrams.Admins;
using VirtualBazaar.Core.Services.Foundations.Telegrams.Admins;
using Telegram.Bot.Types;
using VirtualBazaar.Core.Services.Foundations.Products;
using VirtualBazaar.Core.Services.Orchestrations.Mains;

namespace VirtualBazaar.Core.Services.Orchestrations.Admins
{
    public class AdminOrchestrationService : IAdminOrchestrationService
    {
        private readonly IMainOrchestrationService mainOrchestrationService; 
        private readonly IAdminTelegramService adminTelegramService;
        private readonly IProductService productService;

        public AdminOrchestrationService(
            IAdminTelegramService adminTelegramService,
            IProductService productService,
            IMainOrchestrationService mainOrchestrationService)
        {
            this.adminTelegramService = adminTelegramService;
            this.productService = productService;
            this.mainOrchestrationService = mainOrchestrationService;
        }

        public void StartWork() => 
            this.adminTelegramService.StartBot(HandleAdminMessageAsync);

        private async Task HandleAdminMessageAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            throw new NotImplementedException();
        }


    }
}
