using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Events
{
    public class VaccinationEvents
    {
        public class CreateVaccination
        {
            public Guid VaccinationId { get; set; }
            public Guid HealthRecordId { get; set; }
            public string VaccinationName { get; set; }
            public DateTime VaccinationDate { get; set; }
            public bool IsDeleted { get; set; }
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
            public bool IsDeleted { get; set; }
        }
    }
}
