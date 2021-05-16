using Exp.Order.Domain.Abstraction;

namespace Exp.Order.Domain.Events
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
