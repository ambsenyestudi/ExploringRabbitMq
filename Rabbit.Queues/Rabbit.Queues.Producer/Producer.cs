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
               
                channel.QueueDeclare(queue: "task_queue",
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);
                
                //Marking messages as persistent doesn't fully guarantee that a message won't be lost
                //Although save to disk where massage accepted but not saved yet
                //for betehre ensurence use publisher confirm
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "",
                                     routingKey: "task_queue",
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
