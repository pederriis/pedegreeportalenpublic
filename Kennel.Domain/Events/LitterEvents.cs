using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Events
{
    public class LitterEvents
    {
        public class CreateLitter
        {
            public Guid LitterId { get; set; }
            public string LitterName { get; set; }
            public DateTime LitterBirthDate { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class UpdateLitter
        {
            public Guid LitterId { get; set; }
            public string LitterName { get; set; }
            public DateTime LitterBirthDate { get; set; }
        }

        public class DeleteLitter
        {
            public Guid LitterId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
