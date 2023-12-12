using System;

namespace Animal.Domain.Events
{
    public class HealthRecordEvents
    {
        public class CreateHealthRecord
        {
            public Guid HealthRecordId { get; set; }
            public Guid AnimalId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class DeleteHealthRecord
        {
            public Guid HealthRecordId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
