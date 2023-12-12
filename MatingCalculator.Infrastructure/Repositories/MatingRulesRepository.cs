using MatingCalculator.Application.Interfaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
    public class MatingRulesRepository : IMatingRulesRepository, IDisposable
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public MatingRulesRepository(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddMatingRules(Domain.MatingRules.MatingRules entity)
            => await _dbContext.MatingRules.AddAsync(entity);

        public async Task<bool> MatingRulesExists(Guid id)
            => await _dbContext.MatingRules.FindAsync(id) != null;

        public async Task<Domain.MatingRules.MatingRules> LoadMatingRules(Guid id)
            => await _dbContext.MatingRules.FindAsync(id);
    }
}
