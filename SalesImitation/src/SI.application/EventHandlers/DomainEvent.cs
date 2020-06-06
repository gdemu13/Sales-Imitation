using MediatR;
using SI.Domain.Abstractions.DomainEvents;

namespace SI.Application.EventHandlers
{
    public class DomainEventFactory
    {
        public static DomainEvent<B> CreateInstanse<B>(B a) where B : IDomainEvent
        {
            return new DomainEvent<B>(a);
        }
    }
    public class DomainEvent<T> : INotification where T : IDomainEvent
    {
        public DomainEvent(T instanse)
        {
            Instanse = instanse;
        }

        public T Instanse { get; }
    }
}