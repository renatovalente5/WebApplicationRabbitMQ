using Serilog;
using WebApplicationRabbitMQ.Helpers.RabbitMQ;
using WebApplicationRabbitMQ.Services.Interfaces;

namespace WebApplicationRabbitMQ.Services.Implementation
{
    public class RabbitMQHostedService : IHostedService
    {
        private IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public RabbitMQHostedService(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var rabbitMQOperations = scope.ServiceProvider.GetRequiredService<IRabbitMQOperations<string>>();

                RabbitMQConfiguration _rabbitMQConfiguration = new();
                _configuration.GetSection("RabbitMQ").Bind(_rabbitMQConfiguration);

                Console.WriteLine("RabbitMQOperations starting!");
                Log.Information("RabbitMQOperations starting!");

                RabbitMQMessage<string> message = new();
                message.Body = "olaaa";

                if (!string.IsNullOrEmpty(_rabbitMQConfiguration.QueueName))
                {
                    //rabbitMQOperations.Publish(_rabbitMQConfiguration.QueueName, message);
                    //rabbitMQOperations.Consume(_rabbitMQConfiguration.QueueName, OnMessage);
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //_channel?.Dispose();
            //_connection?.Dispose();
            Console.WriteLine("RabbitMQOperations stopped!");
            throw new NotImplementedException();
        }

        private async void OnMessage(RabbitMQMessage<string> message)
        {
            try
            {
                Console.WriteLine($"Received message: {message}");
                using (var scope = _serviceProvider.CreateScope())
                {
                    var rabbitMQService = scope.ServiceProvider.GetRequiredService<IRabbitMQService>();
                    await rabbitMQService.Add(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing message: {ex.Message}");
            }
        }
    }
}
