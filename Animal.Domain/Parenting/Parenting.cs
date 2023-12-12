using Animal.Domain.Animal;
using Animal.Domain.Litter;
using PedigreePortalen.Framework;
using System;

namespace Animal.Domain.Parenting
{
    public class Parenting :Entity<ParentingId>
    {
        // Properties to handle the persistence
        public Guid ParentingId { get; private set; }
        public Guid AnimalId { get; private set; }
        public Guid? LitterId { get; private set; }

        // Satisfy the serialization requirements
        protected Parenting() { }

        // Entity state properties
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Animal.Animal Animal { get; private set; }
        public Litter.Litter Litter { get; private set; }

        public Parenting(ParentingId parentingId, AnimalId animalId, LitterId litterId, IsDeleted isDeleted)
        {
            Apply(new Events.ParentingEvents.CreateParenting
            {
                ParentingId = parentingId,
                AnimalId = animalId,
                LitterId = litterId,
                IsDeleted = isDeleted
            });
        }

        public void DeleteParenting(IsDeleted isDeleted)
        {
            Apply(new Events.ParentingEvents.DeleteParenting
            {
                ParentingId = ParentingId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.ParentingEvents.CreateParenting e:
                    Id = new ParentingId(e.ParentingId);
                    AnimalId = new AnimalId(e.AnimalId);
                    LitterId = new LitterId(e.LitterId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ParentingId = e.ParentingId;
                    break;

                case Events.ParentingEvents.DeleteParenting e:
                    Id = new ParentingId(e.ParentingId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ParentingId = e.ParentingId;
                    break;
            }
        }
    }
}
