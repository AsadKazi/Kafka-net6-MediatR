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
            //save the demographic in persistent storage
            Log.Information("Submitted customer {Customer}", JsonConvert.SerializeObject(message));
            return Task.CompletedTask;
        }
    }
}