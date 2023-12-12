using System;
using System.Collections.Generic;
using System.Text;
using HealthRecord.Domain.Animal;
using PedigreePortalen.Framework;


namespace HealthRecord.Domain.HealthRecord
{
    public class HealthRecord : AggregateRoot<HealthRecordId>
    {
        // Properties to handle the persistence
        public Guid AnimalId { get; private set; }
        public Guid HealthRecordId { get; private set; }

        // Satisfy the serialization requirements
        protected HealthRecord() { }

        public Animal.Animal Animal { get; }
        public List<Disease.Disease> Diseases { get; }
        public List<HealthCertificate.HealthCertificate> HealthCertificates { get; }
        public List<Vaccination.Vaccination> Vaccinations { get; }


        public HealthRecord
           (
            HealthRecordId healthRecordId,
            AnimalId animalId
           )

        {
            Diseases = new List<Disease.Disease>();
            HealthCertificates = new List<HealthCertificate.HealthCertificate>();
            Vaccinations = new List<Vaccination.Vaccination>();
            

            Apply(new Events.HealthRecordEvents.CreatedHealthRecord
            {
                HealthRecordId = healthRecordId,
                AnimalId = animalId

            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.HealthRecordEvents.CreatedHealthRecord e:
                    //HealthRecordId = new HealthRecordId(e.HealthRecordId);

                    Id=new HealthRecordId(e.HealthRecordId);
                    AnimalId = new AnimalId(e.AnimalId);

                    HealthRecordId = e.HealthRecordId;
                    break;

            }
        }
        protected override void EnsureValidState()
        {
            var valid = Id != null;
            if (!valid)
            {
                throw new DomainExceptions.InvalidEntityState(this, $"Post-checks failed.");
            }
        }
    }
}