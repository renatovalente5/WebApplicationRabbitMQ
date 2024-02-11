using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace WebApplicationRabbitMQ.Helpers.RabbitMQ
{
    public class RabbitMQOperations<T> : IRabbitMQOperations<T>
    {
        private readonly RabbitMQConfiguration _rabbitMQConfiguration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQOperations(string hostName)
        {
            ConnectionFactory factory = new() { HostName = hostName };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public RabbitMQOperations(RabbitMQConfiguration rabbitMQConfiguration)
        {
            //_rabbitMQConfiguration = rabbitMQConfiguration;

            //ConnectionFactory factory = new()
            //{
            //    HostName = _rabbitMQConfiguration.HostName,
            //    Port = _rabbitMQConfiguration.Port,
            //    VirtualHost = _rabbitMQConfiguration.VirtualHost,
            //    UserName = _rabbitMQConfiguration.UserName,
            //    Password = _rabbitMQConfiguration.Password
            //};

            //_connection = factory.CreateConnection();
            //_channel = _connection.CreateModel();
        }

        public void Publish(string queueName, RabbitMQMessage<T> message)
        {
            _channel.QueueDeclare(queueName, false, false, false);
            var output = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            _channel.BasicPublish(string.Empty, queueName, null, output);

            Console.WriteLine("Message Published!");
        }

        public void Consume(string queueName, Action<RabbitMQMessage<T>> onMessage)
        {
            _channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                try
                {
                    var body = Encoding.UTF8.GetString(ea.Body.Span);
                    var message = JsonConvert.DeserializeObject<RabbitMQMessage<T>>(body);

                    onMessage(message);
                    Console.WriteLine("Message Consumed!");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error deserializing message: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            };

            _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            Console.WriteLine("Message Consumed!");
        }
    }

}
