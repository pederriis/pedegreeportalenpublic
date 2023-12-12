using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
  public  class ParentingQuriesDto
    {
        public class ParentingDetails
        {
            public Guid ParentingId { get; set; }
            public Guid? DogId { get; set; }
            public Guid? LitterId { get; set; }

            public bool IsDeleted { get; set; }

            public bool Gender { get; set; }

            public DogQuriesDto.DogDetails DogDetail { get; set; }

            public LitterQuriesDto.LitterDetails LitterDetails { get; set; }
        }
    }
}
