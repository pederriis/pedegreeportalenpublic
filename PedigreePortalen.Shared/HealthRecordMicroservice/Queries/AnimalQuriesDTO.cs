using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.HealthRecordMicroservice.Queries
{
   public class AnimalQuriesDTO
    {
        public class AnimalDetails
        {
            public Guid AnimalId { get; set; }

            public string Name { get; set; }

            public string OwnerId { get; set; }

            public bool IsDeleted { get; set; }

            public HealthRecordQueriesDTO.HealthRecordDetails HealthRecordDetails { get; set; }

            

        }

        
    }
}
