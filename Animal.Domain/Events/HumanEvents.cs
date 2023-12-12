using System;

namespace Animal.Domain.Events
{
    public class HumanEvents
    {
        public class CreateHuman 
        {
            public Guid HumanId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class DeleteHuman 
        {
            public Guid HumanId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
