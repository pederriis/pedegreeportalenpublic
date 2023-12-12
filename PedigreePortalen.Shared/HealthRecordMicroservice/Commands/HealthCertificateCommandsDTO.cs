using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.HealthRecordMicroservice.Commands
{
   public class HealthCertificateCommandsDTO
    {
        public static class V1
        {
            public class HealthCertificate
            {
                public Guid HealthCertificateId { get; set; }

                public Guid HealthRecordId { get; set; }

                public string Name { get; set; }

                public DateTime Date { get; set; }

                public string Note { get; set; } = "";

                public bool IsDeleted { get; set; } = false;


            }

            public class UpdateHealthCertificate
            {
                public Guid HealthCertificateId { get; set; }

                public string Name { get; set; }

                public DateTime Date { get; set; }
                public string Note { get; set; } = "";
                public bool IsDeleted { get; set; } = false;


            }

            public class DeleteHealthCertificate
            {
                public Guid HealthCertificateId { get; set; }

                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
