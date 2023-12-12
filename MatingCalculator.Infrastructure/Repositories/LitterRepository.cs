using MatingCalculator.Application.Interfaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
    public class LitterRepository : ILitterRepository, IDisposable
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public LitterRepository(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddLitter(Domain.Litter.Litter entity)
            => await _dbContext.Litters.AddAsync(entity);

        public async Task<bool> LitterExists(Guid id)
            => await _dbContext.Litters.FindAsync(id) != null;

        public async Task<Domain.Litter.Litter> LoadLitter(Guid id)
            => await _dbContext.Litters.FindAsync(id);
    }
}
