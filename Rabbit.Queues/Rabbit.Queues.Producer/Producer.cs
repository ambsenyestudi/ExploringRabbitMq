using RabbitMQ.Client;
using System;
using System.Text;

namespace Rabbit.Queues.Producer
{
    public class Producer
    {
        private ConnectionFactory factory;

        public Producer(string hostName)
        {
            factory = new ConnectionFactory() { HostName = hostName };
        }
        public void PublishSingleMessage(string message, string queueName)
        {
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
