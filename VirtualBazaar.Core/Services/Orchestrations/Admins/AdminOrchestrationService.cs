using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using VirtualBazaar.Core.Services.Foundations.Admins;
using VirtualBazaar.Core.Services.Foundations.Products;
using VirtualBazaar.Core.Services.Foundations.Telegrams.Admins;
using VirtualBazaar.Core.Services.Orchestrations.Mains;

namespace VirtualBazaar.Core.Services.Orchestrations.Admins
{
    public partial class AdminOrchestrationService : IAdminOrchestrationService
    {
        private readonly IMainOrchestrationService mainOrchestrationService;
        private readonly IAdminTelegramService adminTelegramService;
        private readonly IProductService productService;
        private readonly IAdminService adminService;

        private const string startCommant = "/start";
        public AdminOrchestrationService(
            IAdminTelegramService adminTelegramService,
            IProductService productService,
            IMainOrchestrationService mainOrchestrationService,
            IAdminService adminService)
        {
            this.adminTelegramService = adminTelegramService;
            this.productService = productService;
            this.mainOrchestrationService = mainOrchestrationService;
            this.adminService = adminService;
        }

        public void StartWork() =>
            this.adminTelegramService.StartBot(HandleAdminMessageAsync);

        private async Task HandleAdminMessageAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            if (await StartAsync(update))
                return;
            if (await RegisterAsync(update))
                return;

            return;
        }

        private static async Task<string> IfTypeOfMessageIsLocation(Update update, string address)
        {
            if (update.Message.Type is MessageType.Location)
            {
                double longitude = update.Message.Location.Longitude;
                double latitude = update.Message.Location.Latitude;

                using (var httpClient = new HttpClient())
                {
                    string apiKey = "e2e8a7f702ae48b0b602f87993c98955";
                    string
                        apiUrlForLocation = $"https://api.opencagedata" +
                        $".com/geocode/v1/json?key={apiKey}&q={latitude}+{longitude}";

                    HttpResponseMessage responseForLocation = await httpClient.GetAsync(apiUrlForLocation);
                    string contentForLocation = await responseForLocation.Content.ReadAsStringAsync();
                    dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(contentForLocation);

                    string city = result.results[0].components.city;
                    string street = result.results[0].components.road;
                    string houseNumber = result.results[0].components.house_number;

                    address = $"{city}, {street}, {houseNumber}";
                }
            }

            return address;
        }
    }
}
