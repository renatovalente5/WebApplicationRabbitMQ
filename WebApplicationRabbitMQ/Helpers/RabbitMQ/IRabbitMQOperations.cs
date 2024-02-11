
namespace WebApplicationRabbitMQ.Helpers.RabbitMQ
{
    public interface IRabbitMQOperations<T>
    {
        void Consume(string queueName, Action<RabbitMQMessage<T>> onMessage);
        void Publish(string queueName, RabbitMQMessage<T> message);
    }
}