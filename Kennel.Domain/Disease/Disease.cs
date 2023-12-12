using Kennel.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Disease
{
    public class Disease : Entity<DiseaseId>
    {
        // Properties to handle the persistence
        public Guid DiseaseId { get; private set; }
        public Guid HealthRecordId { get; private set; }

        // Satisfy the serialization requirements
        protected Disease() { }

        // Entity state properties
        public DiseaseName DiseaseName { get; private set; }
        public DiseaseDate DiseaseDate { get; private set; }
        public DiseaseNote DiseaseNote { get; private set; }
        public IsHereditary IsHereditary { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public HealthRecord.HealthRecord HealthRecord { get; private set; }

        public Disease(
            DiseaseId diseaseId
            , HealthRecordId healthRecordId
            , DiseaseName diseaseName
            , DiseaseDate diseaseDate
            , DiseaseNote diseaseNote
            , IsHereditary isHereditary
            , IsDeleted isDeleted
            )
        {
            Apply(new Events.DiseaseEvents.CreateDisease
            {
                DiseaseId = diseaseId,
                HealthRecordId = healthRecordId,
                DiseaseName = diseaseName,
                DiseaseDate = diseaseDate,
                DiseaseNote = diseaseNote,
                IsHereditary = isHereditary,
                IsDeleted = isDeleted
            });
        }

        public void UpdateDisease(
            DiseaseName diseaseName
            , DiseaseDate diseaseDate
            , DiseaseNote diseaseNote
            , IsHereditary isHereditary
            )
        {
            Apply(new Events.DiseaseEvents.UpdateDisease
            {
                DiseaseId = DiseaseId,
                DiseaseName = diseaseName,
                DiseaseDate = diseaseDate,
                DiseaseNote = diseaseNote,
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
                    DiseaseName = new DiseaseName(e.DiseaseName);
                    DiseaseDate = new DiseaseDate(e.DiseaseDate);
                    DiseaseNote = new DiseaseNote(e.DiseaseNote);
                    IsHereditary = new IsHereditary(e.IsHereditary);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    DiseaseId = e.DiseaseId;
                    break;

                case Events.DiseaseEvents.UpdateDisease e:
                    DiseaseName = new DiseaseName(e.DiseaseName);
                    DiseaseDate = new DiseaseDate(e.DiseaseDate);
                    DiseaseNote = new DiseaseNote(e.DiseaseNote);
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
