using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.Interfaces
{
    public interface IDogMatingCalculationRepository
    {
        Task AddDogMatingCalculation(Domain.DogMatingCalculation.DogMatingCalculation entity);
        Task<bool> DogMatingCalculationExists(Guid id);
        Task<Domain.DogMatingCalculation.DogMatingCalculation> LoadDogMatingCalculation(Guid id);
    }
}
