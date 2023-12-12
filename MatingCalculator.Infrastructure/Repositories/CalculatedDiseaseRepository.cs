using MatingCalculator.Application.Interfaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
    public class CalculatedDiseaseRepository : ICalculatedDiseaseRepository, IDisposable
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public CalculatedDiseaseRepository(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddCalculatedDisease(Domain.CalculatedDisease.CalculatedDisease entity)
            => await _dbContext.CalculatedDiseases.AddAsync(entity);

        public async Task<bool> CalculatedDiseaseExists(Guid id)
            => await _dbContext.CalculatedDiseases.FindAsync(id) != null;

        public async Task<Domain.CalculatedDisease.CalculatedDisease> LoadCalculatedDisease(Guid id)
            => await _dbContext.CalculatedDiseases.FindAsync(id);
    }
}
