using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.DiseaseQuerysDto;

namespace Kennel.Infrastructure.Query
{
    public class DiseaseQuerys
    {
        private readonly KennelDbContext _context;

        public DiseaseQuerys(KennelDbContext context)
        {
            _context = context;
        }

        public async Task<List<DiseaseDetails>> GetAllDiseases()
        {
            return await _context.Diseases.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new DiseaseDetails
                {
                    DiseaseId = x.Id.Value,
                    HealthRecordId = x.HealthRecordId,
                    DiseaseName = x.DiseaseName.Value,
                    DiseaseDate = x.DiseaseDate.Value,
                    DiseaseNote = x.DiseaseNote.Value,
                    IsHereditary = x.IsHereditary.Value,
                    IsDeleted = x.IsDeleted.Value,
                })
                 .ToListAsync();
        }
    }
}
