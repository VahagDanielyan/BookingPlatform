using System.Text;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using UserService.Application.Interfaces;
using UserService.Infrastructure.Configurations;

namespace UserService.Infrastructure.EventProducers;

public class KafkaProducer<TKey, TValue> : IKafkaProducer<TKey, TValue>
{
    private readonly IProducer<TKey, TValue> _producer;

    public KafkaProducer(IOptions<KafkaSettings> options)
    {
        _producer = new ProducerBuilder<TKey, TValue>(new ProducerConfig
        {
            BootstrapServers = options.Value.BootstrapServers
        }).Build();
    }

    public async Task ProduceAsync(
        string topic,
        TKey key,
        TValue value,
        IDictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default)
    {
        var message = new Message<TKey, TValue>
        {
            Key = key,
            Value = value,
            Headers = BuildHeaders(headers)
        };

        await _producer.ProduceAsync(topic, message, cancellationToken);
    }

    private static Headers BuildHeaders(IDictionary<string, string>? headers)
    {
        var kafkaHeaders = new Headers();
        if (headers != null)
            foreach (var (k, v) in headers)
                kafkaHeaders.Add(k, Encoding.UTF8.GetBytes(v));

        return kafkaHeaders;
    }

    public void Dispose() => _producer.Dispose();
}