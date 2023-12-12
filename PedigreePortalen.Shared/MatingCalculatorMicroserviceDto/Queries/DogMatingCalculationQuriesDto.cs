using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
    public class DogMatingCalculationQuriesDto
    {
        public class DogMatingCalculationDetails
        {
            public Guid DogMatingCalculationId { get; set; }
            public Guid? DogId { get; set; }
            public Guid? MatingCalculationId { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}
