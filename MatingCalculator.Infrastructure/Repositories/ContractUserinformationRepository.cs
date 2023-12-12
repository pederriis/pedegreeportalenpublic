using MatingCalculator.Application.Interfaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
    public class ContractUserinformationRepository : IContractUserinformationRepository, IDisposable
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public ContractUserinformationRepository(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();
         
        public async Task AddContractUserinformation(Domain.ContractUserinformation.ContractUserinformation entity)
            => await _dbContext.ContractUserinformations.AddAsync(entity);

        public async Task<bool> ContractUserinformationExists(Guid id)
            => await _dbContext.ContractUserinformations.FindAsync(id) != null;

        public async Task<Domain.ContractUserinformation.ContractUserinformation> LoadContractUserinformation(Guid id)
            => await _dbContext.ContractUserinformations.FindAsync(id);
    }
}
