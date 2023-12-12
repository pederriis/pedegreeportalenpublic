using MatingCalculator.Application.Interfaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
    public class MatingCalculatorRepository : IMatingCalculationRepository, IDisposable
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public MatingCalculatorRepository(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddMatingCalculation(Domain.MatingCalculation.MatingCalculation entity)
            => await _dbContext.MatingCalculations.AddAsync(entity);

        public async Task<bool> MatingCalculationExists(Guid id)
            => await _dbContext.MatingCalculations.FindAsync(id) != null;

        public async Task<Domain.MatingCalculation.MatingCalculation> LoadMatingCalculation(Guid id)
            => await _dbContext.MatingCalculations.FindAsync(id);
    }
}
