using Kafka.Base;

namespace Models
{
    //topic name
    [MessageTopic("customer-registered")]
    public class Customer : IMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public double Age { get; set; }
    }
}