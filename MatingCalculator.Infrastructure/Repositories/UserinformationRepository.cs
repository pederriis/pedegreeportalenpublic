using MatingCalculator.Application.Interfaces;
using MatingCalculator.Infrastructure.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Infrastructure.Repositories
{
   public class UserinformationRepository : IUserinformationRepository, IDisposable
    {
        private readonly MatingCalculatorDbContext _dbContext;

        public UserinformationRepository(MatingCalculatorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose() => _dbContext.Dispose();

        public async Task AddUserinformation(Domain.Userinformation.Userinformation entity)
            => await _dbContext.Userinformations.AddAsync(entity);

        public async Task<bool> UserinformationExists(Guid id)
            => await _dbContext.Userinformations.FindAsync(id) != null;

        public async Task<Domain.Userinformation.Userinformation> LoadUserinformation(Guid id)
            => await _dbContext.Userinformations.FindAsync(id);
    }
}
