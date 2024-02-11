using WebApplicationRabbitMQ.Helpers.RabbitMQ;

namespace WebApplicationRabbitMQ.Services.Interfaces
{
    public interface IRabbitMQService
    {
        Task Add(RabbitMQMessage<string> request);
    }
}