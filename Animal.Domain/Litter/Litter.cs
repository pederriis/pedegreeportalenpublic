using Animal.Domain.Animal;
using Animal.Domain.Human;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;

namespace Animal.Domain.Litter
{
    public class Litter :Entity<LitterId>
    {
        // Properties to handle the persistence
        public Guid LitterId { get; private set; }
        //public Guid AnimalLitterId { get; private set; }
        public Guid BreedById { get; private set; }

        // Satisfy the serialization requirements
        protected Litter() { }

        // Entity state properties
        public LitterName LitterName { get; private set; }
        public LitterBirthDate LitterBirthDate { get; private set; }
        public MatingDate MatingDate { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Human.Human BreedBy { get; private set; }

        // List
        public List<Parenting.Parenting> Parentings { get; }
        public List<Animal.Animal> Animals { get; }

        public Litter(LitterId litterId, HumanId BreedById, LitterName litterName, LitterBirthDate litterBirthDate, MatingDate matingDate, IsDeleted isDeleted)
        {
            Parentings = new List<Parenting.Parenting>();
            Animals = new List<Animal.Animal>();
            Apply(new Events.LitterEvents.CreateLitter
            {
                LitterId = litterId,
                BreedById = BreedById,
                LitterName = litterName,
                LitterBirthDate = litterBirthDate,
                MatingDate = matingDate,
                IsDeleted = isDeleted
            });
        }

        public void UpdateLitter(LitterName litterName, LitterBirthDate litterBirthDate, MatingDate matingDate)
        {
            Apply(new Events.LitterEvents.UpdateLitter
            {
                LitterId = LitterId,
                LitterName = litterName,
                LitterBirthDate = litterBirthDate,
                MatingDate = matingDate
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
                    BreedById = new HumanId(e.BreedById);
                    LitterName = new LitterName(e.LitterName);
                    LitterBirthDate = new LitterBirthDate(e.LitterBirthDate);
                    MatingDate = new MatingDate(e.MatingDate);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    LitterId = e.LitterId;
                    break;

                case Events.LitterEvents.UpdateLitter e:

                    LitterName = new LitterName(e.LitterName);
                    LitterBirthDate = new LitterBirthDate(e.LitterBirthDate);
                    MatingDate = new MatingDate(e.MatingDate);
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
