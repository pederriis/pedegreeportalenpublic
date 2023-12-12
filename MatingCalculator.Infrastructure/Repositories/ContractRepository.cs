using MatingCalculator.Application.Interfaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
    public class ContractRepository : IContractRepository, IDisposable
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public ContractRepository(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddContract(Domain.Contract.Contract entity)
            => await _dbContext.Contracts.AddAsync(entity);

        public async Task<bool> ContractExists(Guid id)
            => await _dbContext.Contracts.FindAsync(id) != null;

        public async Task<Domain.Contract.Contract> LoadContract(Guid id)
            => await _dbContext.Contracts.FindAsync(id);
    }
}
