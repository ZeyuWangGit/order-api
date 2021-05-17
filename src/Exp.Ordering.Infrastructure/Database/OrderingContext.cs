using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Exp.Ordering.Domain.OrderAggregate;
using Exp.Ordering.Infrastructure.Database.EntityConfigurations;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Exp.Ordering.Infrastructure.Database
{
    public class OrderingContext : EFContext
    {
        public OrderingContext(DbContextOptions options, IMediator mediator, ICapPublisher capBus) : base(options, mediator, capBus)
        {
        }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
