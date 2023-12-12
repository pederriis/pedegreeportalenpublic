using MatingCalculator.Domain.Dog;
using MatingCalculator.Domain.MatingCalculation;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.DogMatingCalculation
{
    public class DogMatingCalculation : Entity<DogMatingCalculationId>
    {
        // Properties to handle the persistence
        public Guid DogMatingCalculationId { get; private set; }
        public Guid? DogId { get; private set; }
        public Guid? MatingCalculationId { get; private set; }

        // Satisfy the serialization requirements
        protected DogMatingCalculation() { }

        // Entity state properties
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Dog.Dog Dog { get; private set; }
        public MatingCalculation.MatingCalculation MatingCalculation { get; private set; }


        public DogMatingCalculation(DogMatingCalculationId dogMatingCalculationId, DogId dogId, MatingCalculationId matingCalculationId, IsDeleted isDeleted)
        {
            Apply(new Events.DogMatingCalculationEvents.CreateDogMatingCalculation
            {
                DogMatingCalculationId = dogMatingCalculationId,
                DogId = dogId,
                MatingCalculationId = matingCalculationId,
                IsDeleted = isDeleted
            });
        }

        public void DeleteDogMatingCalculation(IsDeleted isDeleted)
        {
            Apply(new Events.DogMatingCalculationEvents.DeleteDogMatingCalculation
            {
                DogMatingCalculationId = DogMatingCalculationId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.DogMatingCalculationEvents.CreateDogMatingCalculation e:
                    Id = new DogMatingCalculationId(e.DogMatingCalculationId);
                    DogId = new DogId(e.DogId);
                    MatingCalculationId = new MatingCalculationId(e.MatingCalculationId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    DogMatingCalculationId = e.DogMatingCalculationId;
                    break;

                case Events.DogMatingCalculationEvents.DeleteDogMatingCalculation e:
                    Id = new DogMatingCalculationId(e.DogMatingCalculationId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    DogMatingCalculationId = e.DogMatingCalculationId;
                    break;
            }
        }
    }
}
