namespace DddCoreExample.Domain
{
    public interface Handle<T> where T : DomainEvent
    {
        void Handle(T args);
    }
}
