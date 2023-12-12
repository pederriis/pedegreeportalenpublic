using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.Interfaces
{
    public interface ILitterRepository
    {
        Task AddLitter(Domain.Litter.Litter entity);
        Task<bool> LitterExists(Guid id);
        Task<Domain.Litter.Litter> LoadLitter(Guid id);
    }
}

