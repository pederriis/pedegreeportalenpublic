using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Infrastructure.Shared
{
    
     public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly HealthRecordDbContext _dbContext;

        public EfCoreUnitOfWork(HealthRecordDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}
