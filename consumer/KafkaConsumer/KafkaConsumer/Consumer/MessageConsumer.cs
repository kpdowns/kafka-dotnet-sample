using System;
using System.Collections.Generic;
using System.Text;

// requires Confluent.Kafka nuget package
using Confluent.Kafka;
using Confluent.Kafka.Serialization;

namespace KafkaConsumer.Consumer
{
    public class MessageConsumer : IMessageConsumer
    {
        public void Listen(Action<Message<Null, string>> processMessage, Dictionary<string, object> configuration, string topic)
        {
            using (var consumer = new Consumer<Null,string>(configuration, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe(topic);
                consumer.OnMessage += (_, message) =>
                {
                    processMessage(message);
                    //consumer.CommitAsync(message); //manually commit that the message was processed
                };
                while (true)
                {
                    // blocks until a new message is received, or the timeout expires
                    consumer.Poll(10000);
                }
                
            }
        }
    }
}
