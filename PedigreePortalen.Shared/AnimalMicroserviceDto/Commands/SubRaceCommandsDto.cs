using System;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Commands
{
    public class SubRaceCommandsDto
    {
        public static class V1
        {
            public class CreateSubRace
            {
                public Guid SubRaceId { get; set; }
                public Guid RaceId { get; set; }
                public string SubRaceName { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateSubRace
            {
                public Guid SubRaceId { get; set; }
                public string SubRaceName { get; set; }
                public DateTime Date { get; set; }
            }

            public class DeleteSubRace
            {
                public Guid SubRaceId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
