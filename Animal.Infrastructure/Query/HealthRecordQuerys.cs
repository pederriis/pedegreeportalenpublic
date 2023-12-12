using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.HealthRecordQuerysDto;

namespace Animal.Infrastructure.Query
{
    public class HealthRecordQuerys
    {
        private readonly AnimalDbContext _context;

        public HealthRecordQuerys(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<List<HealthRecordDetails>> GetAllHealthRecords()
        {
            return await _context.HealthRecords.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new HealthRecordDetails
                {
                    HealthRecordId = x.Id.Value,
                    AnimalId = x.AnimalId,
                    IsDeleted = x.IsDeleted.Value
                })
                 .ToListAsync();
        }
    }
}
