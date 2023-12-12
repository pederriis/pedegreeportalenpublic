using MatingCalculator.Domain;
using MatingCalculator.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Disease
{
    public class Disease: Entity<DiseaseId>
    {

        public Guid DiseaseId { get; private set; }
        public Guid HealthRecordId { get; set; }

        public Disease() { }



        public Name Name { get; private set; }

        public Date Date { get; private set; }

        public Note Note { get; private set; }

        public IsHereditary IsHereditary { get; private set; }

        public Probability Probability { get; set; }

        public IsDeleted IsDeleted { get; private set; }


        public HealthRecord.HealthRecord HealthRecord{ get; private set; }

        public Disease(
           DiseaseId diseaseId
           , HealthRecordId healthRecordId
           , Name name
           , Date date
           , Note note
            ,Probability probability
           , IsHereditary isHereditary
           , IsDeleted isDeleted
           )
        {
            Apply(new Events.DiseaseEvents.CreateDisease
            {
                DiseaseId = diseaseId,
                HealthRecordId = healthRecordId,
                Name = name,
                Date = date,
                Note = note,
                Probability=probability,
                IsHereditary = isHereditary,
                IsDeleted=isDeleted
              
            });
        }

        public void UpdateDisease(
            Name name
            , Date date
            , Note note
            ,Probability probability
            , IsHereditary isHereditary
           
            )
        {
            Apply(new Events.DiseaseEvents.UpdateDisease
            {
                DiseaseId = DiseaseId,
                Name = name,
                Date = date,
                Note = note,
                Probability=probability,
                IsHereditary = isHereditary,
              
            });
        }

        public void DeleteDisease(IsDeleted isDeleted)
        {
            Apply(new Events.DiseaseEvents.DeleteDisease
            {
                DiseaseId = DiseaseId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.DiseaseEvents.CreateDisease e:
                    Id = new DiseaseId(e.DiseaseId);
                    HealthRecordId = new HealthRecordId(e.HealthRecordId);
                    Name = new Name(e.Name);
                    Date = new Date(e.Date);
                    Note = new Note(e.Note);
                    Probability = new Probability(e.Probability);
                    IsHereditary = new IsHereditary(e.IsHereditary);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    DiseaseId = e.DiseaseId;
                    break;

                case Events.DiseaseEvents.UpdateDisease e:
                    Name = new Name(e.Name);
                    Date = new Date(e.Date);
                    Note = new Note(e.Note);
                    Probability = new Probability(e.Probability);
                    IsHereditary = new IsHereditary(e.IsHereditary);

                    break;
                case Events.DiseaseEvents.DeleteDisease e:
                    Id = new DiseaseId(e.DiseaseId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    DiseaseId = e.DiseaseId;
                    break;
            }
        }


    }
}
