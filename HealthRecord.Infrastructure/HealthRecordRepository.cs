using HealthRecord.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using HealthRecord.Application;

namespace HealthRecord.Infrastructure
{
    public class HealthRecordRepository : IHealthRecordRepository, IDisposable
    {
        private readonly HealthRecordDbContext _dbContext;

        public HealthRecordRepository(HealthRecordDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddHealthRecord(Domain.HealthRecord.HealthRecord entity)
            => await _dbContext.HealthRecord.AddAsync(entity);

        public async Task<bool> HealthRecordExists(Guid id)
            => await _dbContext.HealthRecord.FindAsync(id) != null;

        public async Task<Domain.HealthRecord.HealthRecord> LoadHealthRecord(Guid id)
            => await _dbContext.HealthRecord.FindAsync(id);
    }
}

