using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
    public class LitterQuriesDto
    {
        public class LitterDetails
        {
            public Guid LitterId { get; set; }

            public DateTime Date { get; set; }

            public string Name { get; set; }

            public bool IsDeleted { get; set; }

            public List<DogQuriesDto.DogDetails> DogDetails { get; set; }
            public List<ParentingQuriesDto.ParentingDetails> ParentingDetails { get; set; }
        }
    }
}
