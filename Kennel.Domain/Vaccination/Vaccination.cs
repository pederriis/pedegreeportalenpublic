using Kennel.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Vaccination
{
    public class Vaccination : Entity<VaccinationId>
    {
        public Guid VaccinationId { get; private set; }
        public Guid HealthRecordId { get; private set; }

        // Satisfy the serialization requirements
        protected Vaccination() { }

        // Entity state properties
        public VaccinationName VaccinationName { get; private set; }
        public VaccinationDate VaccinationDate { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public HealthRecord.HealthRecord HealthRecord { get; private set; }

        public Vaccination(
            VaccinationId vaccinationId
            , HealthRecordId healthRecordId
            , VaccinationName vaccinationName
            , VaccinationDate vaccinationDate
            , IsDeleted isDeleted
            )
        {
            Apply(new Events.VaccinationEvents.CreateVaccination
            {
                VaccinationId = vaccinationId,
                HealthRecordId = healthRecordId,
                VaccinationName = vaccinationName,
                VaccinationDate = vaccinationDate,
                IsDeleted = isDeleted
            });
        }

        public void UpdateVaccination(VaccinationName vaccinationName, VaccinationDate vaccinationDate)
        {
            Apply(new Events.VaccinationEvents.UpdateVaccination
            {
                VaccinationId = VaccinationId,
                VaccinationName = vaccinationName,
                VaccinationDate = vaccinationDate,
            });
        }

        public void DeleteVaccination(IsDeleted isDeleted)
        {
            Apply(new Events.VaccinationEvents.DeleteVaccination
            {
                VaccinationId = VaccinationId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.VaccinationEvents.CreateVaccination e:
                    Id = new VaccinationId(e.VaccinationId);
                    HealthRecordId = new HealthRecordId(e.HealthRecordId);
                    VaccinationName = new VaccinationName(e.VaccinationName);
                    VaccinationDate = new VaccinationDate(e.VaccinationDate);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    VaccinationId = e.VaccinationId;
                    break;

                case Events.VaccinationEvents.UpdateVaccination e:
                    VaccinationName = new VaccinationName(e.VaccinationName);
                    VaccinationDate = new VaccinationDate(e.VaccinationDate);

                    break;
                case Events.VaccinationEvents.DeleteVaccination e:
                    Id = new VaccinationId(e.VaccinationId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    VaccinationId = e.VaccinationId;
                    break;
            }
        }
    }
}
