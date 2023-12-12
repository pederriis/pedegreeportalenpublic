using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HealthRecord.Domain.Vaccination;


namespace HealthRecord.Application
{
    public interface IVaccinationRepository
    {

        Task AddVaccination(Vaccination entity);
        Task<bool> VaccinationExists(Guid id);
        Task<Vaccination> LoadVaccination(Guid id);
    }
}
