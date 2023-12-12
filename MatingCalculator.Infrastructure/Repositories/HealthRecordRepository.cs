using MatingCalculator.Application.Interfaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
   
        public class HealthRecordRepository : IHealthRecordRepository, IDisposable
        {
            private readonly MatingCalculatorDbContext _dbContext;

            public HealthRecordRepository(MatingCalculatorDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public void Dispose() => _dbContext.Dispose();

            public async Task AddHealthRecord(Domain.HealthRecord.HealthRecord entity)
                => await _dbContext.HealthRecords.AddAsync(entity);

            public async Task<bool> HealthRecordExists(Guid id)
                => await _dbContext.HealthRecords.FindAsync(id) != null;

            public async Task<Domain.HealthRecord.HealthRecord> LoadHealthRecord(Guid id)
                => await _dbContext.HealthRecords.FindAsync(id);
        }
   
}
