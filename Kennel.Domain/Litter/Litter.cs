using Kennel.Domain.Animal;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Litter
{
    public class Litter : Entity<LitterId>
    {
        // Properties to handle the persistence
        public Guid LitterId { get; private set; }
        
        // Satisfy the serialization requirements
        protected Litter() { }

        // Entity state properties
        public LitterName LitterName { get; private set; }
        public LitterBirthDate LitterBirthDate { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        // List
        public List<Parrent.Parrent> Parrents { get; }
        public List<Child.Child> Children { get; }

        public Litter(LitterId litterId, LitterName litterName, LitterBirthDate litterBirthDate, IsDeleted isDeleted)
        {
            Parrents = new List<Parrent.Parrent>();
            Children = new List<Child.Child>();
            Apply(new Events.LitterEvents.CreateLitter
            {
                LitterId = litterId,
                LitterName = litterName,
                LitterBirthDate = litterBirthDate,
                IsDeleted = isDeleted
            });
        }

        public void UpdateLitter(LitterName litterName, LitterBirthDate litterBirthDate)
        {
            Apply(new Events.LitterEvents.UpdateLitter
            {
                LitterId = LitterId,
                LitterName = litterName,
                LitterBirthDate = litterBirthDate,
            });
        }

        public void DeleteLitter(IsDeleted isDeleted)
        {
            Apply(new Events.LitterEvents.DeleteLitter
            {
                LitterId = LitterId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.LitterEvents.CreateLitter e:

                    Id = new LitterId(e.LitterId);
                    LitterName = new LitterName(e.LitterName);
                    LitterBirthDate = new LitterBirthDate(e.LitterBirthDate);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    LitterId = e.LitterId;
                    break;

                case Events.LitterEvents.UpdateLitter e:

                    LitterName = new LitterName(e.LitterName);
                    LitterBirthDate = new LitterBirthDate(e.LitterBirthDate);
                    break;

                case Events.LitterEvents.DeleteLitter e:

                    Id = new LitterId(e.LitterId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    LitterId = e.LitterId;
                    break;
            }
        }
    }
}
