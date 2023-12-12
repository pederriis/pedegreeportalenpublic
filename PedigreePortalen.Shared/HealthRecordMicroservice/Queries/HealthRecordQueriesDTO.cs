using System;
using System.Collections.Generic;
using System.Text;


namespace PedigreePortalen.Shared.HealthRecordMicroservice.Queries
{
   public static class HealthRecordQueriesDTO
    {
        
        public class HealthRecordDetails
        {
            public Guid HealthRecordID { get; set; }

            public Guid  AnimalId { get; set; }

            public bool IsDeleted { get; set; }
            public List<DiseaseQuerysDto.DiseaseDetails>DiseaseDetails { get; set; }
            public List<VaccinationQuriesDto.VacciantionDetails> VaccinationDetails { get; set; }

            public List<HealthCertificateQueriesDTO.HealthCertificateDetails> HealthCertificateDetails { get; set; }


        }
    }
}

