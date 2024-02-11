namespace WebApplicationRabbitMQ.Helpers.RabbitMQ
{
    public class RabbitMQMessage<T>
    {
        public T Body { get; set; }
        public DateTime Datetime { get; set; }
    }
}
