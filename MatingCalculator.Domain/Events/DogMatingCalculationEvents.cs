using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Events
{
    public class DogMatingCalculationEvents
    {
        public class CreateDogMatingCalculation
        {
            public Guid DogMatingCalculationId { get; set; }
            public Guid DogId { get; set; }
            public Guid MatingCalculationId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class DeleteDogMatingCalculation
        {
            public Guid DogMatingCalculationId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
