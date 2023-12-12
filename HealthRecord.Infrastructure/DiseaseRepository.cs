using HealthRecord.Application;
using HealthRecord.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthRecord.Domain.Disease;

namespace HealthRecord.Infrastructure
{
    public class DiseaseRepository : IDiseaseRepository, IDisposable
    {
        private readonly HealthRecordDbContext _dbContext;

        public DiseaseRepository(HealthRecordDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddDisease(Disease entity)
            => await _dbContext.Diseases.AddAsync(entity);

        public async Task<bool> DiseaseExists(Guid id)
            => await _dbContext.Diseases.FindAsync(id) != null;

        public async Task<Disease> LoadDisease(Guid id)
            => await _dbContext.Diseases.FindAsync(id);
    }
}
