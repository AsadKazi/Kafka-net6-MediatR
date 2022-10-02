# Kafka-net6-MediatR
Simple publisher and consumer using kafka Smart way (topic name using attribute), .net6 and MediatR pattern

## Implement kafka a smart way
Most of the blogs shows how to implement kafka consumer and they showed that everything configured inside the consumer. So if you have multiple consumer then you need to write same code for each consumer. The topic name and configuration configured in the following way
![architecture](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/hard-coded-way.png?raw=true)

 But it could be made a kafka framework and reuse for different consumer

Here is a simple kafka producer and consumer.
![architecture](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/architecture.png?raw=true)
 Here, there is one producer and two consumers. The main point is the kafka framework part. It configures the producer and consumer. 

 In the sample demo, there is a producer named `Customer Registered`. When a customer is registered, it will publish the message in the kafka topic. The interesting part is that the topic name is registered using attribute
 ![architecture](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/topic-name-using-attribute.png?raw=true)
  
 So the producer uses these lines to configure the configuration

```csharp
builder.Services.AddOptions<KafkaConfigurations>()
                .Bind(builder.Configuration.GetSection("Kafka"));
builder.Services.AddKafkaProducer();
```

There are two consumers, one for the capturing customer basic information and another for sending the email to the customer.
The consumer uses the following lines to configure the consumer
```csharp
builder.Services.AddOptions<KafkaConfigurations>()
                .Bind(builder.Configuration.GetSection("Kafka"));
builder.Services.AddKafkaConsumer(typeof(Program));
```
Let's play the demo.
Go to the solution directory and run the following command to run the kafka and zookeeper
![kafka start](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/kafka-start.PNG?raw=true)
Run the `Customer.Register.Producer` project and register a consumer.
![customer register](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/generate-topic.PNG?raw=true)
It will create the topic in kafka. Let's connect the kafka using `Kafka Tool` and see the topic.
Connect the kafka using `Kafka Tool`
![customer register](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/kafka-tool-connection1.PNG?raw=true)
![customer register](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/kafka-tool-connection2.PNG?raw=true)
![topic name](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/kafka-tool-topic.PNG?raw=true)

Now make the multiple startup project
![multiple startup](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/multiproject-start.PNG?raw=true)

Now register new customer and see that both `Customer.Demographic.Consumer` and `Customer.EmailSender.Consumer` consumer handle the request.
![customer register](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/customer-register.PNG?raw=true)

Customer demographic consumer
![customer register](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/customer-demographic-consumer.png?raw=true)

Customer email sender consumer
![customer register](https://github.com/AsadKazi/Kafka-net6-MediatR/blob/master/docs/customer-email-consumer.png?raw=true)
