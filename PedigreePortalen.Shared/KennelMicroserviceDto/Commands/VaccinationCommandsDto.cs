using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Commands
{
    public class VaccinationCommandsDto
    {
        public static class V1 
        {
            public class CreateVaccination
            {
                public Guid VaccinationId { get; set; }
                public Guid HealthRecordId { get; set; }
                public string VaccinationName { get; set; }
                public DateTime VaccinationDate { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateVaccination
            {
                public Guid VaccinationId { get; set; }
                public string VaccinationName { get; set; }
                public DateTime VaccinationDate { get; set; }
            }

            public class DeleteVaccination
            {
                public Guid VaccinationId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
