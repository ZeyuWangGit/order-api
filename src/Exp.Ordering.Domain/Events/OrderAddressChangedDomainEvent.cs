using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exp.Ordering.Domain.Abstraction;
using Exp.Ordering.Domain.OrderAggregate;

namespace Exp.Ordering.Domain.Events
{
    public class OrderAddressChangedDomainEvent : IDomainEvent
    {
        public Order Order { get; private set; }

        public OrderAddressChangedDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
