using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.HealthRecordQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.DiseaseQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.HealthCertificateQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.VaccinationQuerysDto;

namespace Kennel.Infrastructure.Query
{
    public class HealthRecordQuerys
    {
        private readonly KennelDbContext _context;

        public HealthRecordQuerys(KennelDbContext context)
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
                    IsDeleted = x.IsDeleted.Value,

                    Diseases = x.Diseases.Select(x => new DiseaseDetails
                    {
                        DiseaseId = x.Id.Value,
                        HealthRecordId = x.HealthRecordId,
                        DiseaseName = x.DiseaseName.Value,
                        DiseaseDate = x.DiseaseDate.Value,
                        DiseaseNote = x.DiseaseNote.Value,
                        IsHereditary = x.IsHereditary.Value,
                        IsDeleted = x.IsDeleted.Value,
                    }).Where(x => x.IsDeleted == false)
                    .ToList(),

                    HealthCertificates = x.HealthCertificates.Select(x => new HealthCertificateDetails
                    {
                        HealthCertificateId = x.Id.Value,
                        HealthRecordId = x.HealthRecordId,
                        HealthCertificateName = x.HealthCertificateName.Value,
                        HealthCertificateDate = x.HealthCertificateDate.Value,
                        HealthCertificateNote = x.HealthCertificateNote.Value,
                        IsDeleted = x.IsDeleted.Value,
                    }).Where(x => x.IsDeleted == false)
                    .ToList(),

                    Vaccinations = x.Vaccinations.Select(x => new VaccinationDetails
                    {
                        VaccinationId = x.Id.Value,
                        HealthRecordId = x.HealthRecordId,
                        VaccinationName = x.VaccinationName.Value,
                        VaccinationDate = x.VaccinationDate.Value,
                        IsDeleted = x.IsDeleted.Value,
                    }).Where(x => x.IsDeleted == false)
                    .ToList(),
                })
                 .ToListAsync();
        }
    }
}
