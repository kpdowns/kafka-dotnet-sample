using System;
using System.Collections.Generic;
using Confluent.Kafka;
using KafkaConsumer.Consumer;

namespace KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new Dictionary<string, object>()
            {
                { "group.id", "test_consumer" }, // consumer group id (multiple consumers in a group)
                { "bootstrap.servers", "localhost:9092" },
                /* Consumers will (by default) automatically signal to Kafka that a message
                   has been consumed. This could be a problem if the consumer crashes after
                   it has told Kafka that the message was successfully consumed - the 
                   consumer may miss out on processing a specific message.
                 */
                { "enable.auto.commit", "false" }
            };

            const string topic = "test";

            var kafkaConsumer = new MessageConsumer();
            kafkaConsumer.Listen(ProcessMessage, configuration, topic);
        }

        /// <summary>
        /// Function to execute whenever a new message is received.
        /// </summary>
        /// <param name="message">The received message.</param>
        public static void ProcessMessage(Message<Null, string> message)
        {
            Console.WriteLine(message.Value);
        }
    }
}
