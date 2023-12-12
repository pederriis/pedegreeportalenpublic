using HealthRecord.Application;
using HealthRecord.Domain.Vaccination;
using HealthRecord.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord.Infrastructure
{
    public class VaccinationRepository : IVaccinationRepository, IDisposable
    {
        private readonly HealthRecordDbContext _dbContext;

        public VaccinationRepository(HealthRecordDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddVaccination(Vaccination entity)
            => await _dbContext.Vaccinations.AddAsync(entity);

        public async Task<bool> VaccinationExists(Guid id)
            => await _dbContext.Vaccinations.FindAsync(id) != null;

        public async Task<Vaccination> LoadVaccination(Guid id)
            => await _dbContext.Vaccinations.FindAsync(id);
    }
}
