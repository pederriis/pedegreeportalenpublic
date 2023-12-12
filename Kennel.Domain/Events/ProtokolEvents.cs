using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Events
{
    public class ProtokolEvents
    {
        public class CreateProtokol
        {
            public Guid ProtokolId { get; set; }
            public Guid KennelId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class DeleteProtokol
        {
            public Guid ProtokolId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
