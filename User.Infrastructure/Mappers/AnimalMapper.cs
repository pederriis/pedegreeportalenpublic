using PedigreePortalen.Shared.UserMicroserviceDto.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace User.Infrastructure.Mappers
{
  public static class AnimalMapper
    { 
    public static class AnimalDtoMapper
    {
        public static AnimalQuriesDto.AnimalDetails Map(Domain.Animal.Animal dto)
        {
            if (dto == null)
            { return null; }
            return new AnimalQuriesDto.AnimalDetails
            {
                AnimalId=dto.AnimalId,
                UserId=dto.UserId,
                Name=dto.Name,
                IsDeleted = dto.IsDeleted
            };
        }

        public static IEnumerable<AnimalQuriesDto.AnimalDetails> Map(IEnumerable<Domain.Animal.Animal> model)
        {
            return model.Select(x => Map(x)).AsEnumerable();
        }


    }
}
}
