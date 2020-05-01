using System.Threading.Tasks;

namespace SI.Domain.Abstractions.DomainEvents
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent devent);
    }
}