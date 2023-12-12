using HealthRecord.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthRecord.Domain.Disease
{
    public class Disease: Entity<DiseaseId>
    {
        // Properties to handle the persistence
        public Guid DiseaseId { get; private set; }

        protected Disease() { }
        // Entity state properties

        public Guid HealtRecordId { get; set; }

        public HealthRecord.HealthRecord HealthRecord { get; private set; }

      
        public Name Name { get; private set; }

        public Date Date { get; private set; }

        public Note Note { get; private set; }

        public Probability Probability { get; private set; }
        public IsHereditary IsHereditary { get; private set; }

        public IsDeleted IsDeleted { get; private set; }

        public Disease(
            DiseaseId diseaseId, 
            HealthRecordId healthRecordId,
            Name name, 
            Date date, 
            Note note, 
            Probability probability,
            IsHereditary isHereditary,
            IsDeleted isDeleted
            
            )
        {
            Apply(new Events.DiseaseEvents.CreatedDisease
            {
                DiseaseId = diseaseId,
                HealthRecordId = healthRecordId,
                Name=name,
                Date=date,
                Note=note,
                Probability=probability,
                IsHereditary=isHereditary,
                IsDeleted=isDeleted

            });
        }

        public void UpdateDisease(
           
            Name name,
            Date date,
            Note note,
            Probability probability,
            IsHereditary isHereditary,
            IsDeleted isDeleted
           )
        {
            Apply(new Events.DiseaseEvents.UpdatedDisease
            {
                
                Name=name,
                Date=date,
                Note=note,
                Probability =probability,
                IsHereditary=isHereditary,
                IsDeleted = isDeleted
            });

        }

        public void DeleteDisease(IsDeleted isDeleted)
        {
            Apply(new Events.DiseaseEvents.DeletedDisease
            {
               DiseaseId=DiseaseId,
                IsDeleted =isDeleted
            });
        }


        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.DiseaseEvents.CreatedDisease e:
                    Id = new DiseaseId(e.DiseaseId);

                    HealtRecordId = new HealthRecordId(e.HealthRecordId);
                    Name = new Name(e.Name);
                    Date  = new Date(e.Date);
                    Note = new Note(e.Note);
                    Probability = new Probability(e.Probability);
                    IsHereditary = new IsHereditary(e.IsHereditary);
                    IsDeleted = new IsDeleted(e. IsDeleted);

                    DiseaseId = e.DiseaseId;

                    break;

                case Events.DiseaseEvents.UpdatedDisease e:
                   // DiseaseId = new DiseaseId(e.DiseaseId);
                    Name = new Name(e.Name);
                    Date = new Date(e.Date);
                    Note = new Note(e.Note);
                    Probability = new Probability(e.Probability);
                    IsHereditary = new IsHereditary(e.IsHereditary);
                    

                    break;
                case Events.DiseaseEvents.DeletedDisease e:
                    DiseaseId = new DiseaseId(e.DiseaseId);
                    IsDeleted = new IsDeleted(e.IsDeleted);


                    break;

            }
        }


    }
}
