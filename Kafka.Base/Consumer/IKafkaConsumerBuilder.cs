using Confluent.Kafka;

namespace Kafka.Base.Consumer
{
    public interface IKafkaConsumerBuilder
    {
        IConsumer<string, string> Build();
    }
}