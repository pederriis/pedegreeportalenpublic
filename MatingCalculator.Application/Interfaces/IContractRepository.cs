using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.Interfaces
{
   public interface IContractRepository
    {
        Task AddContract(Domain.Contract.Contract entity);
        Task<bool> ContractExists(Guid id);
        Task<Domain.Contract.Contract> LoadContract(Guid id);
    }
}
