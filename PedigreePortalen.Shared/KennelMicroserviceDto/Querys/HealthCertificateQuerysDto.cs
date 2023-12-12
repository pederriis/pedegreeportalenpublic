using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Querys
{
    public class HealthCertificateQuerysDto
    {
        public class HealthCertificateDetails
        {
            public Guid HealthCertificateId { get; set; }
            public Guid HealthRecordId { get; set; }
            public string HealthCertificateName { get; set; }
            public DateTime HealthCertificateDate { get; set; }
            public string HealthCertificateNote { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
