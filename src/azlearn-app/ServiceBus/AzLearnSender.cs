using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Azure;

namespace azlearn_app.ServiceBus
{
public class AzLearnSender{
private readonly ServiceBusSender _sender;
public AzLearnSender(IConfiguration configuration, IAzureClientFactory<ServiceBusClient> serviceBusClientFactory)
{
    _sender = serviceBusClientFactory.CreateClient("sb-azlearn").CreateSender(configuration["Azure:ServiceBus:QueueName"]);
}

public async Task SendMessageAsync(object input){
    await _sender.SendMessageAsync(new ServiceBusMessage(JsonSerializer.Serialize(input)));
}

}
}
