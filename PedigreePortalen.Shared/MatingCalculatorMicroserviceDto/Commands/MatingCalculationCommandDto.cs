using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
   public class MatingCalculationCommandDto
    {
        public static class V1
        {

            public class MateTwoDogs
            {
               // public Guid MatingCalculationId { get; set; }

                public Guid MotherDogId { get; set; }

                public Guid FatherDogId { get; set; }

                public Guid MatingCalculationId { get; set; }
            }

            public class CreateMatingCalculation
            {
                public Guid MatingCalculationId { get; set; }

                public Guid MatingRulesId { get; set; }
                public int ExpectedChildren { get; set; }

                public double InbreedingPercent { get; set; }
                public bool IsLegal { get; set; }
                public int LitterAmount { get; set; }

                public List<CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease> CalculatedDiseases { get; set; }
                public bool IsDeleted { get; set; } = false;

                
            }

            public class UpdateMatingCalculation
            {
                public Guid MatingCalculationId { get; set; }

                public Guid MatingRulesId { get; set; }

                public int ExpectedChildren { get; set; }
                public double InbreedingPercent { get; set; }
                public bool IsLegal { get; set; }
                public int LitterAmount { get; set; }
            }

            public class DeleteMatingCalculation
            {
                public Guid MatingCalculationId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }

        }
    }
}
