using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.Intefaces
{
    public interface IDiseaseRepository
    {
        Task AddDisease(Domain.Disease.Disease entity);
        Task<bool> DiseaseExists(Guid id);
        Task<Domain.Disease.Disease> LoadDisease(Guid id);
    }
}
