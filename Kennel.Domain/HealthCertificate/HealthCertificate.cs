using Kennel.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.HealthCertificate
{
    public class HealthCertificate : Entity<HealthCertificateId>
    {
        // Properties to handle the persistence
        public Guid HealthCertificateId { get; private set; }
        public Guid HealthRecordId { get; private set; }

        // Satisfy the serialization requirements
        protected HealthCertificate() { }

        // Entity state properties
        public HealthCertificateName HealthCertificateName { get; private set; }
        public HealthCertificateDate HealthCertificateDate { get; private set; }
        public HealthCertificateNote HealthCertificateNote { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        // Obj to handle the persistence
        public HealthRecord.HealthRecord HealthRecord { get; private set; }

        public HealthCertificate(
            HealthCertificateId healthCertificateId
            , HealthRecordId healthRecordId
            , HealthCertificateName healthCertificateName
            , HealthCertificateDate healthCertificateDate
            , HealthCertificateNote healthCertificateNote
            , IsDeleted isDeleted
            )
        {
            Apply(new Events.HealthCertificateEvents.CreateHealthCertificate
            {
                HealthCertificateId = healthCertificateId,
                HealthRecordId = healthRecordId,
                HealthCertificateName = healthCertificateName,
                HealthCertificateDate = healthCertificateDate,
                HealthCertificateNote = healthCertificateNote,
                IsDeleted = isDeleted
            });
        }

        public void UpdateHealthCertificate(
            HealthCertificateName healthCertificateName
            , HealthCertificateDate healthCertificateDate
            , HealthCertificateNote healthCertificateNote
            )
        {
            Apply(new Events.HealthCertificateEvents.UpdateHealthCertificate
            {
                HealthCertificateId = HealthCertificateId,
                HealthCertificateName = healthCertificateName,
                HealthCertificateDate = healthCertificateDate,
                HealthCertificateNote = healthCertificateNote,
            });
        }

        public void DeleteHealthCertificate(IsDeleted isDeleted)
        {
            Apply(new Events.HealthCertificateEvents.DeleteHealthCertificate
            {
                HealthCertificateId = HealthCertificateId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.HealthCertificateEvents.CreateHealthCertificate e:
                    Id = new HealthCertificateId(e.HealthCertificateId);
                    HealthRecordId = new HealthRecordId(e.HealthRecordId);
                    HealthCertificateName = new HealthCertificateName(e.HealthCertificateName);
                    HealthCertificateDate = new HealthCertificateDate(e.HealthCertificateDate);
                    HealthCertificateNote = new HealthCertificateNote(e.HealthCertificateNote);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    HealthCertificateId = e.HealthCertificateId;
                    break;

                case Events.HealthCertificateEvents.UpdateHealthCertificate e:
                    HealthCertificateName = new HealthCertificateName(e.HealthCertificateName);
                    HealthCertificateDate = new HealthCertificateDate(e.HealthCertificateDate);
                    HealthCertificateNote = new HealthCertificateNote(e.HealthCertificateNote);

                    break;
                case Events.HealthCertificateEvents.DeleteHealthCertificate e:
                    Id = new HealthCertificateId(e.HealthCertificateId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    HealthCertificateId = e.HealthCertificateId;
                    break;
            }
        }
    }
}
