using Exp.Ordering.Domain.Abstraction;
using Exp.Ordering.Domain.OrderAggregate;

namespace Exp.Ordering.Domain.Events
{
    public class OrderCreatedDomainEvent : IDomainEvent
    {
        public Order Order { get; private set; }
        public OrderCreatedDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
