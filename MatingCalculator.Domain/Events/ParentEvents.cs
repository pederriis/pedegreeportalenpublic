using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Events
{
    public class ParentingEvents
    {
        public class CreateParenting
        {
            public Guid ParentingId { get; set; }
            public Guid DogId { get; set; }
            public Guid LitterId { get; set; }

            public bool Gender { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class DeleteParenting
        {
            public Guid ParentingId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
