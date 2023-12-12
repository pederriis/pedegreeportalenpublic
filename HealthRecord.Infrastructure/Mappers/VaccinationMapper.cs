using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PedigreePortalen.Shared.HealthRecordMicroservice.Queries;

namespace HealthRecord.Infrastructure.Mappers
{
    public static class VaccinationMapper
    {
        public class VaccinationDtoMapper
        {
            public static VaccinationQuriesDto.VacciantionDetails Map(Domain.Vaccination.Vaccination dto)
            {
                if (dto == null)
                { return null; }
                return new VaccinationQuriesDto.VacciantionDetails
                {
                    VaccinationId=dto.VaccinationId,
                    Name=dto.Name,
                    Date=dto.Date,
                    IsDeleted=dto.IsDeleted
                };
            }

            public static IEnumerable<VaccinationQuriesDto.VacciantionDetails> Map(IEnumerable<Domain.Vaccination.Vaccination> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

        }
    }
}
