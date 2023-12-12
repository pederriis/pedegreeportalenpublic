using PedigreePortalen.Shared.UserMicroserviceDto.Querys;
using PedigreePortalen.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Mapper.UserMicroServiceMapper
{
    public static class AnimalMapper
    {
        public class AnimalDetailsMapper
        {
            public static AnimalViewModel.DetailsAnimal Map(AnimalQuriesDto.AnimalDetails dto)
            {
                if (dto == null)
                { return null; }
                return new AnimalViewModel.DetailsAnimal
                {
                    AnimalId = dto.AnimalId,
                    OwnerId = dto.UserId,
                    ShortName = dto.Name,
                    IsDeleted = dto.IsDeleted
                };
            }

            public static IEnumerable<AnimalViewModel.DetailsAnimal> Map(IEnumerable<AnimalQuriesDto.AnimalDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<AnimalQuriesDto.AnimalDetails> Map(IEnumerable<AnimalViewModel.DetailsAnimal> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static AnimalQuriesDto.AnimalDetails Map(AnimalViewModel.DetailsAnimal model)
            {
                if (model == null)
                { return null; }
                return new AnimalQuriesDto.AnimalDetails
                {
                    AnimalId = model.AnimalId,
                    UserId = model.OwnerId,
                    Name = model.ShortName,
                    IsDeleted = model.IsDeleted
                };
            }
        }
    }
}
