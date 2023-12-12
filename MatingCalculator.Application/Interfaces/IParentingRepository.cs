using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.Interfaces
{
    public interface IParentingRepository
    {
        Task AddParenting(Domain.Parenting.Parenting entity);
        Task<bool> ParentingExists(Guid id);
        Task<Domain.Parenting.Parenting> LoadParenting(Guid id);
    }
}
