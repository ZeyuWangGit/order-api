using Exp.Ordering.Domain.OrderAggregate;
using Exp.Ordering.Infrastructure.Database;
using Exp.Ordering.Infrastructure.Interfaces;

namespace Exp.Ordering.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, long, OrderingContext>, IOrderRepository
    {
        public OrderRepository(OrderingContext context) : base(context)
        {
        }
    }
}
