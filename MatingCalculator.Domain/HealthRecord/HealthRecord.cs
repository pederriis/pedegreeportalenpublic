using MatingCalculator.Domain.Dog;
using MatingCalculator.Domain.HealthRecord;
using MatingCalculator.Domain.MatingCalculation;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;

namespace MatingCalculator.Domain.HealthRecord
{
    public class HealthRecord :Entity<HealthRecordId>
    {
        // Properties to handle the persistence
        public Guid HealthRecordId { get; private set; }
        public Guid DogId { get; private set; }

        // Satisfy the serialization requirements
        public HealthRecord() { }

        // Entity state properties
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Dog.Dog Dog { get; set; }
        public List<Disease.Disease> Diseases { get; }


        public HealthRecord(HealthRecordId healthRecordId, DogId dogId, IsDeleted isDeleted)
        {
            Diseases = new List<Disease.Disease>();
            Apply(new Events.HealthRecordEvents.CreateHealthRecord
            {
                HealthRecordId = healthRecordId,
                DogId = dogId,
                IsDeleted = isDeleted
            });
        }

        public void DeleteHealthRecord(IsDeleted isDeleted)
        {
            Apply(new Events.HealthRecordEvents.DeleteHealthRecord
            {
                HealthRecordId = HealthRecordId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.HealthRecordEvents.CreateHealthRecord e:
                    Id = new HealthRecordId(e.HealthRecordId);
                    DogId = new DogId(e.DogId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    HealthRecordId = e.HealthRecordId;
                    break;

                case Events.HealthRecordEvents.DeleteHealthRecord e:
                    Id = new HealthRecordId(e.HealthRecordId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    HealthRecordId = e.HealthRecordId;
                    break;
            }
        }
    }
}
