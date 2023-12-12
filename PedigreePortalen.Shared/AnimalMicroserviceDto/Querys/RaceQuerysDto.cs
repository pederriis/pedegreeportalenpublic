using System;
using System.Collections.Generic;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.SubRaceQuerysDto;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Querys
{
    public static class RaceQuerysDto
    {
        public class RaceDetails 
        {
            public Guid RaceId { get; set; }
            public string RaceName { get; set; }
            public bool IsDeleted { get; set; }

            // List
            public List<SubRaceDetails> SubRaces { get; set; }
        }
    }
}
