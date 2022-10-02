using Microsoft.Extensions.DependencyInjection;

namespace Kafka.Base.Producer
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddKafkaProducer(this IServiceCollection services)
        {
            services.AddSingleton<IKafkaProducerBuilder, KafkaProducerBuilder>();

            services.AddSingleton<IMessageProducer, KafkaMessageProducer>();

            return services;
        }
    }
}