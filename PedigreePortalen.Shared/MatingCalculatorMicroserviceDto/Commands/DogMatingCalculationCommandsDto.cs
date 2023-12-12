using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
  public  class DogMatingCalculationCommandsDto
    {
        public static class V1
        {
            public class CreateDogMatingCalculation
            {
                public Guid DogMatingCalculatorId { get; set; }
                public Guid DogId { get; set; }
                public Guid MatingCalculationId { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class DeleteDogMatingCalculation
            {
                public Guid DogMatingCalculationId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
