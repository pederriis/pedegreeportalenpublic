using MatingCalculator.Application.Interfaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
    public class ParentingRepository : IParentingRepository, IDisposable
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public ParentingRepository(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddParenting(Domain.Parenting.Parenting entity)
            => await _dbContext.Parentings.AddAsync(entity);

        public async Task<bool> ParentingExists(Guid id)
            => await _dbContext.Parentings.FindAsync(id) != null;

        public async Task<Domain.Parenting.Parenting> LoadParenting(Guid id)
            => await _dbContext.Parentings.FindAsync(id);
    }
}
