using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Events
{
    public class KennelEvents
    {
        public class CreateKennel
        {
            public Guid KennelId { get; set; }
            public Guid OwnerId { get; set; }
            public string KennelName { get; set; }
            public string KennelSmiley { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class UpdateKennel
        {
            public Guid KennelId { get; set; }
            public string KennelName { get; set; }
            public string KennelSmiley { get; set; }
        }

        public class DeleteKennel
        {
            public Guid KennelId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
