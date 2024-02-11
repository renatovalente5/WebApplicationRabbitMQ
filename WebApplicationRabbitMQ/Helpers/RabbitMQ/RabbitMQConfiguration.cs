﻿namespace WebApplicationRabbitMQ.Helpers.RabbitMQ
{
    public class RabbitMQConfiguration
    {
        public string? HostName { get; set; }
        public int Port { get; set; }
        public string? VirtualHost { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? QueueName { get; set; }
    }
}
