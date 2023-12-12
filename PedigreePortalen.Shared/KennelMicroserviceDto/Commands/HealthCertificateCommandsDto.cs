using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Commands
{
    public class HealthCertificateCommandsDto
    {
        public static class V1 
        {
            public class CreateHealthCertificate
            {
                public Guid HealthCertificateId { get; set; }
                public Guid HealthRecordId { get; set; }
                public string HealthCertificateName { get; set; }
                public DateTime HealthCertificateDate { get; set; }
                public string HealthCertificateNote { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateHealthCertificate
            {
                public Guid HealthCertificateId { get; set; }
                public string HealthCertificateName { get; set; }
                public DateTime HealthCertificateDate { get; set; }
                public string HealthCertificateNote { get; set; }
            }

            public class DeleteHealthCertificate
            {
                public Guid HealthCertificateId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
