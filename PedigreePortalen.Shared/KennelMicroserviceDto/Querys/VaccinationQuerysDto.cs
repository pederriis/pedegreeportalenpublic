using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Querys
{
    public class VaccinationQuerysDto
    {
        public class VaccinationDetails
        {
            public Guid VaccinationId { get; set; }
            public Guid HealthRecordId { get; set; }
            public string VaccinationName { get; set; }
            public DateTime VaccinationDate { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
