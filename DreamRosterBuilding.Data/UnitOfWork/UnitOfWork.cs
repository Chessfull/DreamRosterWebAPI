using DreamRosterBuilding.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRosterBuilding.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DreamRosterBuildingDbContext _context;
        private IDbContextTransaction _transaction; // -> for dbcontext transaction processes 'in efcore'

        public UnitOfWork(DreamRosterBuildingDbContext context)
        {
            _context = context;
        }
        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); // -> For permission to Garbage Collector memory management
        }

        public async Task RollBackTransaction()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
