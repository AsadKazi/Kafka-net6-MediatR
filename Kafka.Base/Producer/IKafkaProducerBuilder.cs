using Confluent.Kafka;

namespace Kafka.Base.Producer
{
    public interface IKafkaProducerBuilder
    {
        IProducer<string, string> Build();
    }
}