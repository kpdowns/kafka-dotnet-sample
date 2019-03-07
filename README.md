# kafka-dotnet-sample
A heavily documented sample dotnet core consumer, producer, and setup steps for running Apache Kafka locally.

---

These samples assume that we will be running both Kafka and Zookeeper locally, i.e. **we will not be using Docker** for this example.

## Required software

A base requirement to run the samples is the .NET Core 2.2 SDK (https://dotnet.microsoft.com/download).

Java (x64) is required to run both Apache Zookeeper and Kafka. Please ensure that this is on your path.

### Apache Zookeeper 3.4.13
https://zookeeper.apache.org/


### Apache Kafka 2.11
https://kafka.apache.org/

## Running the sample code

1. Rename the `zoo_sample.cfg` file in the `zookeeper-x.x.x\conf` folder to `zoo.cfg`. Change the `dataDir` property to `./data`.

2. Start Zookeeper by running `zookeeper-x.x.x/bin/zkServer.cmd`. This will start Zookeeper listing on port 2181 by default (defined in `zoo.cfg`).

3. Change the `log.dirs` property in `kafka_x.x.x-x.x.x\config\server.properties` to `./kafka-logs`

4. Start Kafka by running the following command in the `bin\windows` directory where you installed Kafka.

```
.\kafka-server-start.bat ..\..\config\server.properties
```

5. Create a Kafka topic by running the following command in the `bin\windows` directory where you installed Kafka.

```
.\kafka-topics.bat --create --zookeeper localhost:2181 --replication-factor 1 --partitions 1 --topic test
```

The above command will create a topic named `test`.

6. Build and run KafkaConsumer.

~~7. Build and run KafkaProducer.~~ NOT YET IMPLEMENTED

## Troubleshooting

To test that Kafka/Zookeeper is correctly setup and running you can run the following commands in the `bin\windows` directory where Kafka was installed.

```
.\kafka-console-producer.bat --broker-list localhost:9092 --topic test
```

Then:

```
.\kafka-console-consumer.bat --bootstrap-server localhost:9092 --topic test --from-beginning

```

After this, you can type messages in the **producer**. They should appear on the consumer window.

