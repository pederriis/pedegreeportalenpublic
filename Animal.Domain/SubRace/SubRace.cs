using Animal.Domain.Race;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;

namespace Animal.Domain.SubRace
{
    public class SubRace :Entity<SubRaceId>
    {
        // Properties to handle the persistence
        public Guid SubRaceId { get; private set; }
        public Guid RaceId { get; private set; }

        // Satisfy the serialization requirements
        protected SubRace() { }

        // Entity state properties
        public SubRaceName SubRaceName { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Race.Race Race { get; private set; }

        // List
        public List<Animal.Animal> Animals { get; }

        public SubRace(SubRaceId subRaceId, RaceId raceId, SubRaceName subRaceName, IsDeleted isDeleted)
        {
            Animals = new List<Animal.Animal>();
            Apply(new Events.SubRaceEvents.CreateSubRace
            {
                SubRaceId = subRaceId,
                RaceId = raceId,
                SubRaceName = subRaceName,
                IsDeleted = isDeleted
            });
        }

        public void UpdateSubRace(SubRaceName subRaceName)
        { 
            Apply(new Events.SubRaceEvents.UpdateSubRace
            {
                SubRaceId = SubRaceId,
                SubRaceName = subRaceName
            });
        }

        public void DeleteSubRace(IsDeleted isDeleted)
        {
            Apply(new Events.SubRaceEvents.DeleteSubRace
            {
                SubRaceId = SubRaceId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.SubRaceEvents.CreateSubRace e:
                    Id = new SubRaceId(e.SubRaceId);
                    RaceId = new RaceId(e.RaceId);
                    SubRaceName = new SubRaceName(e.SubRaceName);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    SubRaceId = e.SubRaceId;
                    break;

                case Events.SubRaceEvents.UpdateSubRace e:
                    SubRaceName = new SubRaceName(e.SubRaceName);
                    break;

                case Events.SubRaceEvents.DeleteSubRace e:
                    Id = new SubRaceId(e.SubRaceId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    SubRaceId = e.SubRaceId;
                    break;
            }
        }
    }
}
