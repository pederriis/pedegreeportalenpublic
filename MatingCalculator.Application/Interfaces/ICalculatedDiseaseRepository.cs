using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.Interfaces
{
    public interface ICalculatedDiseaseRepository
    {
        Task AddCalculatedDisease(Domain.CalculatedDisease.CalculatedDisease entity);
        Task<bool> CalculatedDiseaseExists(Guid id);
        Task<Domain.CalculatedDisease.CalculatedDisease> LoadCalculatedDisease(Guid id);
    }
}
