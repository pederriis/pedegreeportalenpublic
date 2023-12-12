using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Domain.Events
{
    public class SubRaceEvents 
    {
        public class CreateSubRace
        {
            public Guid SubRaceId { get; set; }
            public Guid RaceId { get; set; }
            public string SubRaceName { get; set; }
            public bool IsDeleted { get; set; }
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
            public bool IsDeleted { get; set; }
        }
    }
}
