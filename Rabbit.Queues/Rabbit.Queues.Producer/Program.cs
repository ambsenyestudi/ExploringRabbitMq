namespace Rabbit.Queues.Producer
{

    class Program
    {
        private const string HOST_NAME = "localhost";
        private const string QUEUE_NAME = "task_queue";
        public static void Main(string[] args)
        {
            var publisher = new Producer(HOST_NAME);
            string message = "First taks ..";
            publisher.PublishSingleMessage(message, QUEUE_NAME);
        }
    }
}
