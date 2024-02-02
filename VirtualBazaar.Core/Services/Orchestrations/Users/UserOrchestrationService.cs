using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using VirtualBazaar.Core.Services.Foundations.Orders;
using VirtualBazaar.Core.Services.Foundations.Telegrams.Users;
using VirtualBazaar.Core.Services.Orchestrations.Mains;

namespace VirtualBazaar.Core.Services.Orchestrations.Users
{
    public class UserOrchestrationService : IUserOrchestrationService
    {
        private readonly IMainOrchestrationService mainOrchestrationService;
        private readonly IUserTelegramService userTelegramService;
        private readonly IOrderService orderService;

        public UserOrchestrationService(
            IUserTelegramService userTelegramService,
            IOrderService orderService,
            IMainOrchestrationService mainOrchestrationService)
        {
            this.userTelegramService = userTelegramService;
            this.orderService = orderService;
            this.mainOrchestrationService = mainOrchestrationService;
        }

        public void StartWork() =>
            this.userTelegramService.StartBot(HandleUserMessageAsync);

        private async Task HandleUserMessageAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
