using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Domain.Events
{
    public class RaceEvents
    {
        public class CreateRace
        {
            public Guid RaceId { get; set; }
            public string RaceName { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class UpdateRace
        {
            public Guid RaceId { get; set; }
            public string RaceName { get; set; }
        }

        public class DeleteRace
        {
            public Guid RaceId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
