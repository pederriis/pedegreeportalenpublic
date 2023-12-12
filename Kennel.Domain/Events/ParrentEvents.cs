using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Events
{
    public class ParrentEvents
    {
        public class CreateParrent
        {
            public Guid ParrentId { get; set; }
            public Guid AnimalId { get; set; }
            public Guid LitterId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class DeleteParrent
        {
            public Guid ParrentId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class AddParrentToLitter 
        {
            public Guid ParrentId { get; set; }
            public Guid LitterId { get; set; }
        }
    }
}
