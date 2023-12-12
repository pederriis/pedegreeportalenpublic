using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;

namespace Animal.Domain.Race
{
    public class Race :Entity<RaceId>
    {
        // Properties to handle the persistence
        public Guid RaceId { get; private set; }

        // Satisfy the serialization requirements
        protected Race() { }

        // Entity state properties
        public RaceName RaceName { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        // List
        public List<SubRace.SubRace> SubRaces { get; }

        public Race(RaceId raceId, RaceName raceName, IsDeleted isDeleted)
        {
            SubRaces = new List<SubRace.SubRace>();
            Apply(new Events.RaceEvents.CreateRace
            {
                RaceId = raceId,
                RaceName = raceName,
                IsDeleted = isDeleted
            });
        }

        public void UpdateRace(RaceName raceName)
        {
            Apply(new Events.RaceEvents.UpdateRace
            {
                RaceId = RaceId,
                RaceName = raceName
            });
        }

        public void DeleteRace(IsDeleted isDeleted)
        {
            Apply(new Events.RaceEvents.DeleteRace
            {
                RaceId = RaceId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.RaceEvents.CreateRace e:
                    Id = new RaceId(e.RaceId);
                    RaceName = new RaceName(e.RaceName);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    RaceId = e.RaceId;
                    break;

                case Events.RaceEvents.UpdateRace e:
                    RaceName = new RaceName(e.RaceName);
                    break;

                case Events.RaceEvents.DeleteRace e:
                    Id = new RaceId(e.RaceId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    RaceId = e.RaceId;
                    break;
            }
        }
    }
}
