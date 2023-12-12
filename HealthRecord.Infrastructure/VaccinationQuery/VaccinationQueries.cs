using HealthRecord.Infrastructure.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Queries.VaccinationQuriesDto;

namespace HealthRecord.Infrastructure.VaccinationQuery
{
   public class VaccinationQueries
    {
        private readonly HealthRecordDbContext _context;

        public VaccinationQueries(HealthRecordDbContext healthRecordDbContext)
        {
            _context = healthRecordDbContext;
        }

        public async Task<List<VacciantionDetails>> GetAllVaccinationDetails()
        {
            return await _context.Vaccinations.Select(x => new VacciantionDetails


            {
                VaccinationId=x.Id.Value,
                Name = x.Name,
                IsDeleted = x.IsDeleted

            }).AsNoTracking()
              .ToListAsync();

        }

        public async Task<VacciantionDetails> GetSingleVaccinationDetails(Guid VaccinationId)
        {
            return await _context.Vaccinations.Select(x => new VacciantionDetails


            {
                VaccinationId = x.Id.Value,
                Name = x.Name,
                IsDeleted = x.IsDeleted

            }).AsNoTracking()
            .FirstOrDefaultAsync(p => p.VaccinationId == VaccinationId);





        }
    }
}
