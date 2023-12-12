using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Litter
{
    public class Litter:Entity<LitterId>
    {
        public Guid LitterId { get; private set; }


        protected Litter() { }
        public Name Name { get; private set; }

        public Date Date { get; private set; }

        public IsDeleted IsDeleted { get; set; }

        public List<Dog.Dog> Dogs { get; }
        public List<Parenting.Parenting> Parentings { get; }

        public Litter(LitterId litterId, Name Name, Date Date, IsDeleted isDeleted)
        {
            Dogs = new List<Dog.Dog>();
            Parentings = new List<Parenting.Parenting>();

            Apply(new Events.LitterEvents.CreateLitter
            {
                LitterId = litterId,
                Name = Name,
                Date = Date,
                IsDeleted = isDeleted
            });
        }

        public void UpdateLitter(Name litterName, Date litterBirthDate)
        {
            Apply(new Events.LitterEvents.UpdateLitter
            {
                LitterId = LitterId,
                Name = litterName,
                Date = litterBirthDate,
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
                    Name = new Name(e.Name);
                    Date = new Date(e.Date);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    LitterId = e.LitterId;
                    break;

                case Events.LitterEvents.UpdateLitter e:

                    Name = new Name(e.Name);
                    Date = new Date(e.Date);
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
