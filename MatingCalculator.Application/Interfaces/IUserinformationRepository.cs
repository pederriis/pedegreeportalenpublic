using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.Interfaces
{
   public interface IUserinformationRepository

    {
        Task AddUserinformation(Domain.Userinformation.Userinformation entity);
        Task<bool> UserinformationExists(Guid id);
        Task<Domain.Userinformation.Userinformation> LoadUserinformation(Guid id);
    }
}
