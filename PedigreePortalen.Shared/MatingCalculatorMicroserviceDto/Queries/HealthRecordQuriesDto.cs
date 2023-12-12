using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
  public static  class HealthRecordQuriesDto
    {
        public class HealthRecordDetails
        {
            public Guid? HealthRecordId { get; set; }
            public Guid? DogId { get; set; }
            public bool IsDeleted { get; set; }

        }
    }
    
}
