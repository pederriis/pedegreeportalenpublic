using MatingCalculator.Application.Interfaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
   public class DogMatingCalculationRepository : IDogMatingCalculationRepository, IDisposable
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public DogMatingCalculationRepository(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddDogMatingCalculation(Domain.DogMatingCalculation.DogMatingCalculation entity)
            => await _dbContext.DogMatingCalculations.AddAsync(entity);

        public async Task<bool> DogMatingCalculationExists(Guid id)
            => await _dbContext.DogMatingCalculations.FindAsync(id) != null;

        public async Task<Domain.DogMatingCalculation.DogMatingCalculation> LoadDogMatingCalculation(Guid id)
            => await _dbContext.DogMatingCalculations.FindAsync(id);
    }
}
