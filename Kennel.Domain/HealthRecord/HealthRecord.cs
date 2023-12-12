using Kennel.Domain.Animal;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.HealthRecord
{
    public class HealthRecord : Entity<HealthRecordId>
    {
        // Properties to handle the persistence
        public Guid HealthRecordId { get; private set; }
        public Guid AnimalId { get; private set; }
        
        // Satisfy the serialization requirements
        protected HealthRecord() { }

        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public Animal.Animal Animal { get; }

        // List
        public List<Disease.Disease> Diseases { get; }
        public List<HealthCertificate.HealthCertificate> HealthCertificates { get; }
        public List<Vaccination.Vaccination> Vaccinations { get; }


        public HealthRecord(HealthRecordId healthRecordId, AnimalId animalId, IsDeleted isDeleted)
        {
            Diseases = new List<Disease.Disease>();
            HealthCertificates = new List<HealthCertificate.HealthCertificate>();
            Vaccinations = new List<Vaccination.Vaccination>();
            Apply(new Events.HealthRecordEvents.CreateHealthRecord
            {
                HealthRecordId = healthRecordId,
                AnimalId = animalId,
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
                    AnimalId = new AnimalId(e.AnimalId);
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
