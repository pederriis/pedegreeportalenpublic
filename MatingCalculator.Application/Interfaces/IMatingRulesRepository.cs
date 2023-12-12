using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.Interfaces
{
   public  interface IMatingRulesRepository
    {
        Task AddMatingRules(Domain.MatingRules.MatingRules entity);
        Task<bool> MatingRulesExists(Guid id);
        Task<Domain.MatingRules.MatingRules> LoadMatingRules(Guid id);
    }
}
