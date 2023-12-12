using System;
using System.Collections.Generic;
using System.Text;
using HealthRecord.Domain.HealthRecord;
using PedigreePortalen.Framework;

namespace HealthRecord.Domain.HealthCertificate
{
    public class HealthCertificate : Entity<HealthCertificateId>
    {


        public Guid HealthCertificateId { get; private set; }
        public Guid HealthRecordId { get; private set; }

        protected HealthCertificate() { }
        // Entity state properties



       

        public HealthRecord.HealthRecord HealthRecord { get; private set; }

        public Name Name { get; private set; }

        public Date Date { get; private set; }

        public Note Note { get; private set; }

        public IsDeleted IsDeleted { get; private set;}

    

    public HealthCertificate
            (
        HealthCertificateId healtCertificateId,
        HealthRecordId healthRecordId,
        Name name,
        Date date,
        Note note,
        IsDeleted isDeleted
        
        )
    {
        Apply(new Events.HealthCertificateEvents.CreatedHealthCertificate
        {
            HealthCertificateId = healtCertificateId,
            HealthRecordId = healthRecordId,
            Name = name,
            Date = date,
            Note = note,
            IsDeleted=isDeleted
            
            

        });


    }

        public void UpdatehealthCertificate
                (
          
            Name name,
            Date date,
            Note note,
            IsDeleted isDeleted
           )
        {
            Apply(new Events.HealthCertificateEvents.UpdatedHealthCertificate
            {
               
                Name = name,
                Date = date,
                Note = note,
                IsDeleted = isDeleted

            });

        }

        public void DeleteHealthCertificate
            (
            

            IsDeleted isDeleted
            )
        {
            Apply(new Events.HealthCertificateEvents.DeletedHealthCertificate
            {
                HealthCertificateId=HealthCertificateId,
                IsDeleted = isDeleted

            }) ;
        }
    

    protected override void When(object @event)
    {
        switch (@event)
        {
            case Events.HealthCertificateEvents.CreatedHealthCertificate e:
                Id = new HealthCertificateId(e.HealthCertificateId);
                HealthRecordId = new HealthRecordId(e.HealthRecordId);
                Name = new Name(e.Name);
                Date = new Date(e.Date);
                Note = new Note(e.Note);
                IsDeleted = new IsDeleted(e.IsDeleted);

                HealthCertificateId = e.HealthCertificateId;

                break;

            case Events.HealthCertificateEvents.UpdatedHealthCertificate e:
             //   Id = new HealthCertificateId(e.HealthCertificateId);
                Name = new Name(e.Name);
                Date = new Date(e.Date);
                Note = new Note(e.Note);


                
                break;

                case Events.HealthCertificateEvents.DeletedHealthCertificate e:
                    Id = new HealthCertificateId(e.HealthCertificateId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    HealthCertificateId = e.HealthCertificateId;
                    break;
            
        }
    }
    }

}

