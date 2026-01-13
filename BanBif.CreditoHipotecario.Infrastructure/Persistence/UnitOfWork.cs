using BanBif.CreditoHipotecario.Application.Interfaces;
using BanBif.CreditoHipotecario.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanBif.CreditoHipotecario.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PanelContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(PanelContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            _transaction = await _context.Database
                .BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
            await _transaction!.CommitAsync(cancellationToken);
        }

        public async Task RollbackAsync(CancellationToken cancellationToken)
        {
            if (_transaction != null)
                await _transaction.RollbackAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
