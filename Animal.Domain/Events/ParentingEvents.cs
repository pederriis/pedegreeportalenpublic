using System;
using System.Collections.Generic;
using System.Text;

namespace Animal.Domain.Events
{
    public class ParentingEvents
    {
        public class CreateParenting
        {
            public Guid ParentingId { get; set; }
            public Guid AnimalId { get; set; }
            public Guid LitterId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class DeleteParenting
        {
            public Guid ParentingId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class AddParrentToLitter 
        {
            public Guid ParentingId { get; set; }
            public Guid LitterId { get; set; }
        }
    }
}
