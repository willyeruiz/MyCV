using MediatR;

namespace MyCV.Domain.Common.Primitives;

public record DomainEvents(Guid Id) : INotification
{
}
