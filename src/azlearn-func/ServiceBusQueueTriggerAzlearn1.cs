using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzLearn.Func
{
    public static class ServiceBusQueueTriggerAzlearn1
    {
        [FunctionName("ServiceBusQueueTriggerAzlearn1")]
        public static void Run([ServiceBusTrigger("sbq-azlearn-prod-01")]string myQueueItem, 
        int deliveryCount,
        DateTime enqueuedTimeUtc,
        string messageId,
        ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            log.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
            log.LogInformation($"DeliveryCount={deliveryCount}");
            log.LogInformation($"MessageId={messageId}");
        }
    }
}
