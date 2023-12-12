using System;
using System.Collections.Generic;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.AnimalQuerysDto;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Querys
{
    public static class SubRaceQuerysDto
    {
        public class SubRaceDetails 
        {
            public Guid SubRaceId { get; set; }
            public Guid RaceId { get; set; }
            public string SubRaceName { get; set; }
            public bool IsDeleted { get; set; }

            // List
            public List<AnimalDetails> Animals { get; set; }
        }
    }
}
