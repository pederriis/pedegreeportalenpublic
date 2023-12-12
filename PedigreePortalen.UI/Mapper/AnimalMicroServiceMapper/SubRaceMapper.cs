using PedigreePortalen.Shared.AnimalMicroserviceDto.Querys;
using PedigreePortalen.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper
{
    public static class SubRaceMapper
    {
        public class SubRaceDetailsMapper
        {
            public static SubRaceViewModel.SubRaceDetails Map(SubRaceQuerysDto.SubRaceDetails dto)
            {
                if (dto == null)
                { return null; }
                return new SubRaceViewModel.SubRaceDetails
                {
                    SubRaceId = dto.SubRaceId,
                    RaceId = dto.RaceId,
                    SubRaceName = dto.SubRaceName,
                    IsDeleted = dto.IsDeleted
                };
            }

            public static IEnumerable<SubRaceViewModel.SubRaceDetails> Map(IEnumerable<SubRaceQuerysDto.SubRaceDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<SubRaceQuerysDto.SubRaceDetails> Map(IEnumerable<SubRaceViewModel.SubRaceDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static SubRaceQuerysDto.SubRaceDetails Map(SubRaceViewModel.SubRaceDetails model)
            {
                if (model == null)
                { return null; }
                return new SubRaceQuerysDto.SubRaceDetails
                {
                    SubRaceId = model.SubRaceId,
                    RaceId = model.RaceId,
                    SubRaceName = model.SubRaceName,
                    IsDeleted = model.IsDeleted
                };
            }
        }
    }
}
