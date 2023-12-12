using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
    public class ChildQuriesDto
    {
        public class ChildDetails
        {
            public Guid ChildId { get; set; }
            public Guid? DogId { get; set; }
            public Guid? LitterId { get; set; }

            public bool IsDeleted { get; set; }

            public DogQuriesDto.DogDetails DogDetail {get;set;}
        }
    }
}