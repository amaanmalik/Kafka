using Confluent.Kafka;

namespace Consumer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092", // Replace with your Kafka broker address
                GroupId = "test-group", // Use a unique group ID
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };

            using (var consumer = new ConsumerBuilder<string, string>(config).Build())
            {
                var topic = "mytopic"; // Replace with your source topic
                consumer.Subscribe(topic);

                while (true)
                {
                    var consumeResult = consumer.Consume();
                    Console.WriteLine($"Received message: {consumeResult.Message.Value}");
                }
            }
        }
    }
}