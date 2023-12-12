using HealthRecord.Domain.HealthCertificate;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthRecord.Domain.Events
{
    public class HealthCertificateEvents
    {

        public class CreatedHealthCertificate 
        {
            public Guid HealthCertificateId { get; set; }

            public Guid HealthRecordId { get;  set; }
            public string Name { get; set; }

            public DateTime Date { get; set; }

            public string Note { get; set; }
            public bool IsDeleted { get; set; }

            
        }

        public class UpdatedHealthCertificate
        {
            
                public Guid HealthCertificateId { get; set; }
                public string Name { get; set; }

                public DateTime Date { get; set; }

                public string Note { get; set; }
                public bool IsDeleted { get; set; }



        }

        public class DeletedHealthCertificate
        {

            public Guid HealthCertificateId { get; set; }
            
            public bool IsDeleted { get; set; }



        }
    }
}
