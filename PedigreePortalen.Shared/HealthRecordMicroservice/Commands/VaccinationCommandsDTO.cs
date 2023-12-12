using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.HealthRecordMicroservice.Commands
{
    public class VaccinationCommandsDTO
    {

        
            public static class V1
            {
                public class CreateVaccination
                {
                    public Guid VaccinationId { get; set; }

                    public string Name { get; set; }

                    public DateTime Date { get; set; }
                    public bool IsDeleted { get; set; } = false;

                    public Guid HealthRecordId { get; set; }

            }

                public class UpdateVaccination
                {
                public Guid VaccinationId { get; set; }

                public string Name { get; set; }

                public DateTime Date { get; set; }
                public bool IsDeleted { get; set; }
            }

                public class DeleteVaccination
                {
                public Guid VaccinationId { get; set; }

                public string Name { get; set; }

                public DateTime Date { get; set; }
                public bool IsDeleted { get; set; }
            }
            }
        
    }
}
