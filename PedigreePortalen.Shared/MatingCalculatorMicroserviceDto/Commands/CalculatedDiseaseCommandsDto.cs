using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
    public class CalculatedDiseaseCommandsDto
    {
        public static class V1
        {
            public class CreatedCalculatedDisease
            {
                public Guid CalculatedDiseaseId { get; set; }

                public Guid MatingCalculationId { get; set; }
                public string Name { get; set; }
               
                public double Probability { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateCalculatedDisease
            {
                public Guid CalculatedDiseaseId { get; set; }

                public Guid MatingCalculationId { get; set; }
                public string Name { get; set; }

                public double Probability { get; set; }

            }

            public class DeleteCalculatedDisease
            {
                public Guid CalculatedDiseaseId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }

        }
    }
}
