using Confluent.Kafka;

namespace ProducerComplexEvents001
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
            };

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                var topic = "mytopic";

                while (true)
                {
                    // Simulate generating complex events (e.g., JSON payloads)
                    var complexEvent = new
                    {
                        EventId = Guid.NewGuid(),
                        Timestamp = DateTime.UtcNow,
                        Data = "Some complex data...",
                    };

                    var message = Newtonsoft.Json.JsonConvert.SerializeObject(complexEvent);

                    var deliveryReport = await producer.ProduceAsync(topic, new Message<string, string> { Key = null, Value = message });
                    Console.WriteLine($"Produced message: {message}");
                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }
        }
    }
}