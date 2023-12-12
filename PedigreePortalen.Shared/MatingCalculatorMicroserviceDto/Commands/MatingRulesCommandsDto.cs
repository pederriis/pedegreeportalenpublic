using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
    public class MatingRulesCommandsDto
    {
        public static class V1
        {
            public class CreateMatingRules
            {
                public Guid MatingRulesId { get; set; }

                public double InbreedingPercent { get; set; }
                public int LitterAmount { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateMatingRules
            {
                public Guid MatingRulesId { get; set; }

                public double InbreedingPercent { get; set; }
                public int LitterAmount { get; set; }

            }

            public class DeleteMatingRules
            {
                public Guid MatingRulesId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }

        }
    }
}
