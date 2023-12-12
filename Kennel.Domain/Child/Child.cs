using Kennel.Domain.Animal;
using Kennel.Domain.Litter;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Child
{
    public class Child : Entity<ChildId>
    {
        public Guid ChildId { get; private set; }
        public Guid AnimalId { get; private set; }
        public Guid? LitterId { get; private set; }

        // Satisfy the serialization requirements
        protected Child() { }

        // Entity state properties
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Animal.Animal Animal { get; private set; }
        public Litter.Litter Litter { get; private set; }


        public Child(ChildId childId, AnimalId animalId, IsDeleted isDeleted)
        {
            Apply(new Events.ChildEvents.CreateChild
            {
                ChildId = childId,
                AnimalId = animalId,
                IsDeleted = isDeleted
            });
        }

        public void AddChildToLitter(LitterId litterId)
        {
            Apply(new Events.ChildEvents.AddChildToLitter
            {
                ChildId = ChildId,
                LitterId = litterId,
            });
        }

        public void DeleteChild(IsDeleted isDeleted)
        {
            Apply(new Events.ChildEvents.DeleteChild
            {
                ChildId = ChildId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.ChildEvents.CreateChild e:
                    Id = new ChildId(e.ChildId);
                    AnimalId = new AnimalId(e.AnimalId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ChildId = e.ChildId;
                    break;

                case Events.ChildEvents.DeleteChild e:
                    Id = new ChildId(e.ChildId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    ChildId = e.ChildId;
                    break;

                case Events.ChildEvents.AddChildToLitter e:
                    Id = new ChildId(e.ChildId);
                    LitterId = new LitterId(e.LitterId);

                    ChildId = e.ChildId;
                    break;
            }
        }
    }
}
