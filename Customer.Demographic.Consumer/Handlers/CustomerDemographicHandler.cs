using Kafka.Base;

using MediatR;

using Newtonsoft.Json;

using Serilog;

namespace Customer.Demographic.Consumer.Handlers
{
    public class CustomerDemographicHandler : INotificationHandler<MessageNotification<Models.Customer>>
    {
        public Task Handle(MessageNotification<Models.Customer> notification, CancellationToken cancellationToken)
        {
            var message = notification.Message;
            Log.Information("Submitting customer {Customer}", JsonConvert.SerializeObject(message));
            return Task.CompletedTask;
        }
    }
}