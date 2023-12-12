using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Events
{
    public class ChildEvents
    {
        public class CreateChild
        {
            public Guid ChildId { get; set; }
            public Guid AnimalId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class DeleteChild
        {
            public Guid ChildId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class AddChildToLitter
        {
            public Guid ChildId { get; set; }
            public Guid LitterId { get; set; }
        }
    }
}
