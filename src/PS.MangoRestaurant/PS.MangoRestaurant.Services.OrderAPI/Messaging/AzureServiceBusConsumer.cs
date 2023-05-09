using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using PS.MangoRestaurant.Services.OrderAPI.Messages;
using System.Text;

namespace PS.MangoRestaurant.Services.OrderAPI.Messaging
{
    public class AzureServiceBusConsumer
    {
        private async Task OnCheckoutMessageReceived(ProcessMessageEventArgs args)
        {
            var message = args.Message;
            var body = Encoding.UTF8.GetString(message.Body);

            CheckoutHeaderDto checkoutHeaderDto = JsonConvert.DeserializeObject<CheckoutHeaderDto>(body);
        }
    }
}
