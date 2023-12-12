using System;
using System.Collections.Generic;
using System.Text;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.DiseaseQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.VaccinationQuerysDto;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.HealthCertificateQuerysDto;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Querys
{
    public class HealthRecordQuerysDto
    {
        public class HealthRecordDetails
        {
            public Guid? HealthRecordId { get; set; }
            public Guid? AnimalId { get; set; }
            public bool? IsDeleted { get; set; }

            // list 
            public List<DiseaseDetails> Diseases { get; set; }
            public List<HealthCertificateDetails> HealthCertificates { get; set; }
            public List<VaccinationDetails> Vaccinations { get; set; }
        }
    }
}
