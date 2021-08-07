namespace Rabbit.Queues.Consumers
{
    class Program
    {
        private const string HOST_NAME = "localhost";
        private const string QUEUE_NAME = "hello";
        public static void Main()
        {
            var consumer = new Consumer(HOST_NAME);
            consumer.StartListeningOnQueue(QUEUE_NAME);
        }
    }
}
