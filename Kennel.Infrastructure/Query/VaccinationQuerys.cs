using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.VaccinationQuerysDto;

namespace Kennel.Infrastructure.Query
{
    public class VaccinationQuerys
    {
        private readonly KennelDbContext _context;

        public VaccinationQuerys(KennelDbContext context)
        {
            _context = context;
        }

        public async Task<List<VaccinationDetails>> GetAllVaccinations()
        {
            return await _context.Vaccinations.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new VaccinationDetails
                {
                    VaccinationId = x.Id.Value,
                    HealthRecordId = x.HealthRecordId,
                    VaccinationName = x.VaccinationName.Value,
                    VaccinationDate = x.VaccinationDate.Value,
                    IsDeleted = x.IsDeleted.Value,
                })
                 .ToListAsync();
        }
    }
}
