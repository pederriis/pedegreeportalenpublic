using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.HealthRecordMicroservice.Commands
{
    public class HealthRecordCommandsDTO
    {
        public static class V1
        {
            public class CreateHealthRecord
            {
                public Guid HealthRecordId { get; set; }
                public Guid AnimalId { get; set; }


            }

            public class UpdateHealthRecord
            {
                public Guid HealthRecordId { get; set; }

            }

            public class DeleteHealthRecord
            {
                public Guid HealthRecordId { get; set; }
                public bool IsDeleted { get; set; }


            }
        }
    }
}

