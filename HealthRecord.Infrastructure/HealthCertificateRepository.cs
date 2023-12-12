using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthRecord.Application;
using HealthRecord.Domain.HealthCertificate;

namespace HealthRecord.Infrastructure.Shared
{
    public class HealthCertificateRepository : IHealthCertificateRepository, IDisposable
    {
        private readonly HealthRecordDbContext _dbContext;

        public HealthCertificateRepository(HealthRecordDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddHealthCertificate(HealthCertificate entity)
            => await _dbContext.HealthCertificates.AddAsync(entity);

        public async Task<bool> HealthCertificateExists(Guid id)
            => await _dbContext.HealthCertificates.FindAsync(id) != null;

        public async Task<HealthCertificate> LoadHealthCertificate(Guid id)
            => await _dbContext.HealthCertificates.FindAsync(id);
    }
}
