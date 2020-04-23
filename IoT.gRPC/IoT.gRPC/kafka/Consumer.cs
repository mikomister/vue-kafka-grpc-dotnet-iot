using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace IoT.gRPC.kafka
{
    public class Consumer : ICustomConsumer
    {
        private readonly ILogger<Consumer> _logger;
        private readonly IConsumer<Ignore, String> _consumer;
        private readonly ConsumerConfig _consumerConfig;
        private readonly string _topic = Environment.GetEnvironmentVariable("KAFKA_TOPIC");

        public Consumer(ILogger<Consumer> logger)
        {
            _logger = logger;

            _consumerConfig = new ConsumerConfig
            {
                GroupId = Environment.GetEnvironmentVariable("KAFKA_CONSUMER_GROUP"),
                BootstrapServers = Environment.GetEnvironmentVariable("KAFKA_HOST"),
                AutoOffsetReset = AutoOffsetReset.Latest,
            };

            _consumer = new ConsumerBuilder<Ignore, string>(_consumerConfig)
                        .SetErrorHandler((_, e) => _logger.LogError($"Error: {e.Reason}; Code: {e.Code}; IsFatal: {e.IsFatal}"))
                        .Build();

            _consumer.Subscribe(_topic);
        }

        public async Task<LSData> GetMessage(CancellationToken ct)
        {
            var result = await Task.Run(() =>
            {
                LSData data = null;
                while (!ct.IsCancellationRequested && data == null)
                {
                    try
                    {
                        var cr = _consumer.Consume(ct);
                        data = JsonConvert.DeserializeObject<LSData>(cr.Message.Value);
                        _logger.LogInformation($"Consumed message '{data.Data} {data.Time}' at: '{cr.TopicPartitionOffset}'.");
                    }
                    catch (ConsumeException e)
                    {
                        _logger.LogError($"Error occured: {e.Error.Reason}; Code: {e.Error.Code}; IsFatal: {e.Error.IsFatal}");
                    }
                    catch (OperationCanceledException e)
                    {
                        _logger.LogInformation($"Operation canceled by client: {e.Message}");
                        //_consumer.Close();
                    }
                }
                return data;
            }, ct);
            return result;
        }
    }
}
