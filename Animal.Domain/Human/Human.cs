using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;

namespace Animal.Domain.Human
{
    public class Human : Entity<HumanId>
    {
        // Properties to handle the persistence
        public Guid HumanId { get; private set; }

        // Satisfy the serialization requirements
        protected Human() { }

        // Entity state properties
        public IsDeleted IsDeleted { get; private set; }

        // List
        public List<Animal.Animal> Animals { get; }
        public List<Litter.Litter> Litters { get; }

        public Human(HumanId humanId , IsDeleted isDeleted)
        {
            Animals = new List<Animal.Animal>();
            Litters = new List<Litter.Litter>();
            Apply(new Events.HumanEvents.CreateHuman
            {
                HumanId = humanId,
                IsDeleted = isDeleted
            });
        }

        public void DeleteHuman(IsDeleted isDeleted)
        {
            Apply(new Events.HumanEvents.DeleteHuman
            {
                HumanId = HumanId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.HumanEvents.CreateHuman e:
                    Id = new HumanId(e.HumanId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    HumanId = e.HumanId;
                    break;

                case Events.HumanEvents.DeleteHuman e:
                    Id = new HumanId(e.HumanId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    HumanId = e.HumanId;
                    break;
            }
        }
    }
}
