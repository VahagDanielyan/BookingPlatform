namespace UserService.Application.Interfaces;

public interface IKafkaProducer<in TKey, in TValue> : IDisposable
{
    Task ProduceAsync(
        string topic,
        TKey key,
        TValue value,
        IDictionary<string, string>? headers = null,
        CancellationToken cancellationToken = default);
}