using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
    public class HealthRecordCommandsDto
    {
        public static class V1
        {
            public class CreateHealthRecord
            {
                public Guid HealthRecordId { get; set; }
                public Guid DogId { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class DeleteHealthRecord
            {
                public Guid HealthRecordId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}