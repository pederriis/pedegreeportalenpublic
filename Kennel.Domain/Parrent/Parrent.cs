using Kennel.Domain.Animal;
using Kennel.Domain.Litter;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Parrent
{
    public class Parrent : Entity<ParrentId>
    {
        // Properties to handle the persistence
        public Guid ParrentId { get; private set; }
        public Guid AnimalId { get; private set; }
        public Guid? LitterId { get; private set; }

        // Satisfy the serialization requirements
        protected Parrent() { }

        // Entity state properties
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Animal.Animal Animal { get; private set; }
        public Litter.Litter Litter { get; private set; }


        public Parrent(ParrentId parrentId, AnimalId animalId, IsDeleted isDeleted)
        {
            Apply(new Events.ParrentEvents.CreateParrent
            {
                ParrentId = parrentId,
                AnimalId = animalId,
                IsDeleted = isDeleted
            });
        }

        public void DeleteParrent(IsDeleted isDeleted)
        {
            Apply(new Events.ParrentEvents.DeleteParrent
            {
                ParrentId = ParrentId,
                IsDeleted = isDeleted
            });
        }

        public void AddParrentToLitter(LitterId litterId)
        {
            Apply(new Events.ParrentEvents.AddParrentToLitter
            {
                ParrentId = ParrentId,
                LitterId = litterId,
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.ParrentEvents.CreateParrent e:
                    Id = new ParrentId(e.ParrentId);
                    AnimalId = new AnimalId(e.AnimalId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ParrentId = e.ParrentId;
                    break;

                case Events.ParrentEvents.DeleteParrent e:
                    Id = new ParrentId(e.ParrentId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ParrentId = e.ParrentId;
                    break;

                case Events.ParrentEvents.AddParrentToLitter e:
                    Id = new ParrentId(e.ParrentId);
                    LitterId = new LitterId(e.LitterId);

                    ParrentId = e.ParrentId;
                    break;
            }
        }
    }
}
