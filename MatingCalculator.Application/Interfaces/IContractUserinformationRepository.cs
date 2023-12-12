using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.Interfaces
{
   public interface IContractUserinformationRepository
    {
        Task AddContractUserinformation(Domain.ContractUserinformation.ContractUserinformation entity);
        Task<bool> ContractUserinformationExists(Guid id);
        Task<Domain.ContractUserinformation.ContractUserinformation> LoadContractUserinformation(Guid id);
    }
}
