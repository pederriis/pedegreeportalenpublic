using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.Interfaces
{
    public interface IMatingCalculationRepository
    {
        Task AddMatingCalculation(Domain.MatingCalculation.MatingCalculation entity);
        Task<bool> MatingCalculationExists(Guid id);
        Task<Domain.MatingCalculation.MatingCalculation> LoadMatingCalculation(Guid id);
    }
}

