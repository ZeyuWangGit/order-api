using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Exp.Ordering.Infrastructure.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Exp.Ordering.Infrastructure
{
    public class EFContext: DbContext, IUnitOfWork, ITransaction
    {
        protected IMediator _mediator;
        ICapPublisher _capBus;

        public EFContext(DbContextOptions options, IMediator mediator, ICapPublisher capBus) : base(options)
        {
            _mediator = mediator;
            _capBus = capBus;
        }

        #region IUnitOfWork
        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        #endregion

        public IDbContextTransaction GetCurrentTransaction()
        {
            throw new NotImplementedException();
        }

        public bool HasActiveTransaction { get; }
        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            throw new NotImplementedException();
        }

        public Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }
    }
}
