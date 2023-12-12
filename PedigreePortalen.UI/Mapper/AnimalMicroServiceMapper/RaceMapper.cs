using PedigreePortalen.Shared.AnimalMicroserviceDto.Querys;
using PedigreePortalen.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper
{
    public static class RaceMapper
    {
        public class RaceDetailsMapper
        {
            public static RaceViewModel.RaceDetails Map(RaceQuerysDto.RaceDetails dto)
            {
                if (dto == null)
                { return null; }
                return new RaceViewModel.RaceDetails
                {
                    RaceId = dto.RaceId,
                    RaceName = dto.RaceName,
                    IsDeleted = dto.IsDeleted
                };
            }

            public static IEnumerable<RaceViewModel.RaceDetails> Map(IEnumerable<RaceQuerysDto.RaceDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<RaceQuerysDto.RaceDetails> Map(IEnumerable<RaceViewModel.RaceDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static RaceQuerysDto.RaceDetails Map(RaceViewModel.RaceDetails model)
            {
                if (model == null)
                { return null; }
                return new RaceQuerysDto.RaceDetails
                {
                    RaceId = model.RaceId,
                    RaceName = model.RaceName,
                    IsDeleted = model.IsDeleted
                };
            }
        }
    }
}
