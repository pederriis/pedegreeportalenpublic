using MatingCalculator.Application.Intefaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
    public class DiseaseRepository : IDiseaseRepository, IDisposable
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public DiseaseRepository(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddDisease(Domain.Disease.Disease entity)
            => await _dbContext.Diseases.AddAsync(entity);

        public async Task<bool> DiseaseExists(Guid id)
            => await _dbContext.Diseases.FindAsync(id) != null;

        public async Task<Domain.Disease.Disease> LoadDisease(Guid id)
            => await _dbContext.Diseases.FindAsync(id);
    }
}
