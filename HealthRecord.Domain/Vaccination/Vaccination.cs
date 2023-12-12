using System;
using System.Collections.Generic;
using System.Text;
using HealthRecord.Domain.HealthRecord;
using PedigreePortalen.Framework;

namespace HealthRecord.Domain.Vaccination
{
   public class Vaccination: Entity<VaccinationId>
    {
        public Guid VaccinationId { get; private set; }

        protected Vaccination() { }
        // Entity state properties



        public Guid HealthRecordId { get; set; }

        public HealthRecord.HealthRecord HealthRecord { get; private set; }

        public Name Name { get; private set; }

        public Date Date { get; private set; }

        public IsDeleted IsDeleted { get; private set; }


        public Vaccination
            (
        VaccinationId vaccinationId,
        HealthRecordId healthRecordId,
        Name name,
        Date date,
        IsDeleted isDeleted

        )
        {
            Apply(new Events.VaccinationEvents.CreatedVaccination
            {
                VaccinationId=vaccinationId,
                HealthRecordId = healthRecordId,
                Name = name,
                Date = date,
                IsDeleted = isDeleted



            });
        }

        public void UpdateVaccination
                (
            
            Name name,
            Date date,
            IsDeleted isDeleted
           )
        {
            Apply(new Events.VaccinationEvents.UpdatedVaccination
            {
               
                Name = name,
                Date = date,
                IsDeleted = isDeleted

            });

        }

        public void DeleteVaccination
            (
           
            IsDeleted isDeleted
            )
        {
            Apply(new Events.VaccinationEvents.DeletedVacciantion
            {
                
                IsDeleted=isDeleted

            });
        }


        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.VaccinationEvents.CreatedVaccination e:
                    Id = new VaccinationId(e.VaccinationId);
                    HealthRecordId = new HealthRecordId(e.HealthRecordId);
                    Name = new Name(e.Name);
                    Date = new Date(e.Date);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    VaccinationId = e.VaccinationId;
                    break;

                case Events.VaccinationEvents.UpdatedVaccination e:
                    VaccinationId = new VaccinationId(e.VaccinationId);
                    Name = new Name(e.Name);
                    Date = new Date(e.Date);
                    IsDeleted = new IsDeleted(e.IsDeleted);
                    break;

                case Events.VaccinationEvents.DeletedVacciantion e:
                    Id = new VaccinationId(e.VaccinationId);
                    Name = new Name(e.Name);
                    Date = new Date(e.Date);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    VaccinationId = e.VaccinationId;
                    break;
            }
        }
    }
}
