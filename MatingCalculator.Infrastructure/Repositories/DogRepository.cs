using MatingCalculator.Application.Intefaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
    public class DogRepository : IDogRepository, IDisposable
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public DogRepository(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddDog(Domain.Dog.Dog entity)
            => await _dbContext.Dogs.AddAsync(entity);

        public async Task<bool> DogExists(Guid id)
            => await _dbContext.Dogs.FindAsync(id) != null;

        public async Task<Domain.Dog.Dog> LoadDog(Guid id)
            => await _dbContext.Dogs.FindAsync(id);
    }
}
