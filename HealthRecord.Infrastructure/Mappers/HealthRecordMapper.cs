using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PedigreePortalen.Shared.HealthRecordMicroservice.Queries;

namespace HealthRecord.Infrastructure.Mappers
{
    public static class HealthRecordMapper
    {
        public class HealthRecordDtoMapper
        {
            public static HealthRecordQueriesDTO.HealthRecordDetails Map(Domain.HealthRecord.HealthRecord dto)
            {
                if (dto == null)
                { return null; }
                return new HealthRecordQueriesDTO.HealthRecordDetails
                {
                    HealthRecordID = dto.HealthRecordId,
                    AnimalId = dto.AnimalId,
                    DiseaseDetails = DiseaseMapper.DiseaseDtoMapper.Map(dto.Diseases).ToList(),
                    HealthCertificateDetails=HealthCertificateMapper.HealthCertificateDtoMapper.Map(dto.HealthCertificates).ToList(),
                    VaccinationDetails=VaccinationMapper.VaccinationDtoMapper.Map(dto.Vaccinations).ToList()

                    
                };
            }

            public static IEnumerable<HealthRecordQueriesDTO.HealthRecordDetails> Map(IEnumerable<Domain.HealthRecord.HealthRecord> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

        }
    }
}
