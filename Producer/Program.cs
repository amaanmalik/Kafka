using Confluent.Kafka;

namespace Producer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092", // Replace with your Kafka broker address
            };

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                var topic = "mytopic"; // Replace with your source topic
                while (true)
                {
                    // Simulate real-time events (e.g., generate timestamped messages)
                    var message = $"Event at {DateTime.UtcNow}";
                    var deliveryReport = await producer.ProduceAsync(topic, new Message<string, string> { Key = null, Value = message });
                    Console.WriteLine($"Produced message: {message}");
                    await Task.Delay(TimeSpan.FromSeconds(1)); // Simulate real-time delay
                }
            }
        }
    }
}