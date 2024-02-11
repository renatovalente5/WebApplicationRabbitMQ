using WebApplicationRabbitMQ.Helpers.RabbitMQ;
using WebApplicationRabbitMQ.Services.Interfaces;

namespace WebApplicationRabbitMQ.Services.Implementation
{
    public class RabbitMQService : IRabbitMQService
    {
        public RabbitMQService()
        {

        }

        public async Task Add(RabbitMQMessage<string> request)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
