using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PedigreePortalen.Shared.HealthRecordMicroservice.Queries;

namespace HealthRecord.Infrastructure.Mappers
{
    public static class AnimalMapper
    {
        public static class AnimalDtoMapper
        {
            public static AnimalQuriesDTO.AnimalDetails Map(Domain.Animal.Animal dto)
            {
                if (dto == null)
                { return null; }
                return new AnimalQuriesDTO.AnimalDetails
                {
                    AnimalId=dto.AnimalId,
                    Name=dto.Name,
                    OwnerId=dto.OwnerId,
                    IsDeleted=dto.IsDeleted,
                    HealthRecordDetails=HealthRecordMapper.HealthRecordDtoMapper.Map(dto.HealthRecord)
                    
                };
            }

            public static IEnumerable<AnimalQuriesDTO.AnimalDetails> Map(IEnumerable<Domain.Animal.Animal> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }


        }
    }
}
