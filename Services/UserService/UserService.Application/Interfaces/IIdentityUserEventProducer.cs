using Shared.Kafka.TopicMessages;

namespace UserService.Application.Interfaces;

public interface IIdentityUserEventProducer : IDisposable
{
    Task ProduceEventAsync(
        IdentityUserDeletionEvent identityUserDeletionEvent,
        CancellationToken cancellationToken = default);
}