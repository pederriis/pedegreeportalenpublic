using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PedigreePortalen.Shared.HealthRecordMicroservice.Queries;

namespace HealthRecord.Infrastructure.Mappers
{
    public static class DiseaseMapper
    {
        public static class DiseaseDtoMapper
        {
            public static DiseaseQuerysDto.DiseaseDetails Map(Domain.Disease.Disease dto)
            {
                if (dto == null)
                { return null; }
                return new DiseaseQuerysDto.DiseaseDetails
                {
                    DiseaseId = dto.DiseaseId,
                    Name = dto.Name,
                    Date=dto.Date,
                    Note=dto.Note,
                    Probabilty=dto.Probability,
                    IsHereditary=dto.IsHereditary,
                    IsDeleted = dto.IsDeleted
                };
            }

            public static IEnumerable<DiseaseQuerysDto.DiseaseDetails> Map(IEnumerable<Domain.Disease.Disease> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

           
        }
    }
}
