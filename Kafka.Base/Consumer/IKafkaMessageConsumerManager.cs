using System.Threading;

namespace Kafka.Base.Consumer
{
    public interface IKafkaMessageConsumerManager
    {
        void StartConsumers(CancellationToken cancellationToken);
    }
}