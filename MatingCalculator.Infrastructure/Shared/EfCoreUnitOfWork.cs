using MatingCalculator.Infrastructure.Shared;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Shared
{
    
     public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public EfCoreUnitOfWork(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}
