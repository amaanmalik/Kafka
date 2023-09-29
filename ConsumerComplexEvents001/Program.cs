using Confluent.Kafka;

namespace ConsumerComplexEvents001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "test-group",
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };

            using (var consumer = new ConsumerBuilder<string, string>(config).Build())
            {
                var topic = "mytopic";
                consumer.Subscribe(topic);

                while (true)
                {
                    var consumeResult = consumer.Consume();

                    // Simulate complex event processing (e.g., deserializing JSON payloads)
                    var complexEventJson = consumeResult.Message.Value;
                    var complexEvent = Newtonsoft.Json.JsonConvert.DeserializeObject<ComplexEvent>(complexEventJson);

                    // Perform complex event-specific processing here
                    ProcessComplexEvent(complexEvent);

                    Console.WriteLine($"Processed complex event with ID: {complexEvent.EventId}");
                }
            }
        }

        static void ProcessComplexEvent(ComplexEvent complexEvent)
        {
            // Add your custom processing logic here
            // For example, you can store events in a database, perform analytics, or trigger actions based on event content.
        }
    }

    class ComplexEvent
    {
        public Guid EventId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Data { get; set; }
    }
}