using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.AnimalMicroserviceDto.Commands
{
    public class RaceCommandsDto
    {
        public static class V1
        {
            public class CreateRace
            {
                public Guid RaceId { get; set; }
                public string RaceName { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateRace
            {
                public Guid RaceId { get; set; }
                public string RaceName { get; set; }
            }

            public class DeleteRace
            {
                public Guid RaceId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
