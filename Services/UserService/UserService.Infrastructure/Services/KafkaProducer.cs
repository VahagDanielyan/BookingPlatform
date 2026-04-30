// using Confluent.Kafka;
// using Microsoft.Extensions.Options;
// using UserService.Application.Interfaces;
// using UserService.Infrastructure.Configurations;
//
// namespace UserService.Infrastructure.Services;
//
// public class KafkaProducer<TKey, TMessage> : IKafkaProducer<TKey, TMessage>
// {
//     private readonly IProducer<TKey, TMessage> _producer;
//     private readonly string _topic;
//
//     public KafkaProducer(IOptions<KafkaSettings> kafkaSettings)
//     {
//         var settings = kafkaSettings.Value;
//
//         var config = new ProducerConfig
//         {
//             BootstrapServers = settings.BootstrapServers,
//         };
//
//         _producer = new ProducerBuilder<TKey, TMessage>(config).Build();
//         _topic = settings.Topic;
//     }
//
//     public async Task ProduceAsync(
//         TKey key,
//         TMessage value,
//         IDictionary<string, string>? headers = null,
//         CancellationToken cancellationToken = default)
//     {
//         var kafkaHeaders = new Headers();
//
//         if (headers != null)
//             foreach (var header in headers)
//                 kafkaHeaders.Add(header.Key, System.Text.Encoding.UTF8.GetBytes(header.Value));
//
//         var message = new Message<TKey, TMessage>
//         {
//             Key = key,
//             Value = value,
//             Headers = kafkaHeaders
//         };
//
//         await _producer.ProduceAsync(_topic, message, cancellationToken);
//     }
//
//     public void Dispose()
//     {
//         _producer.Dispose();
//         GC.SuppressFinalize(this);
//     }
// }