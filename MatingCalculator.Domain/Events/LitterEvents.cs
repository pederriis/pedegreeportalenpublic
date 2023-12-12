using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Events
{
    public class LitterEvents
    {
        public class CreateLitter
        {
            public Guid LitterId { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class UpdateLitter
        {
            public Guid LitterId { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }

        public class DeleteLitter
        {
            public Guid LitterId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
