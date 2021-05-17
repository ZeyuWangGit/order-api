using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exp.Ordering.Domain.OrderAggregate;

namespace Exp.Ordering.Infrastructure.Interfaces
{
    public interface IOrderRepository : IRepository<Order, long>
    {

    }
}
