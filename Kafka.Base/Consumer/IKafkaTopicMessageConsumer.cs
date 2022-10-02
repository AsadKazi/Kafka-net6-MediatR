using System.Threading;

namespace Kafka.Base.Consumer
{
    public interface IKafkaTopicMessageConsumer
    {
        void StartConsuming(string topic, CancellationToken cancellationToken);
    }
}