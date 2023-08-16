namespace MyCV.Domain.Common.Primitives;

public abstract class AggregateRoot
{
    private readonly List<DomainEvents> _domainEvents = new();

    public IReadOnlyCollection<DomainEvents> DomainEvents => _domainEvents.AsReadOnly();

    protected void AddDomainEvent(DomainEvents domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    
}
