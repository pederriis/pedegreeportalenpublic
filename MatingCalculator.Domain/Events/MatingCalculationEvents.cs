using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Events
{
    public class MatingCalculationEvents
    {
        public class CreateMatingCalculation
        {
            public Guid MatingCalculationId { get; set; }

            public Guid MatingRulesId { get; set; }
            public int ExpectedChildren { get; set; }
            public double InbreedingPercent { get; set; }
            public int LitterAmount { get; set; }

            public  bool IsLegal { get; set; }

            public bool IsDeleted { get; set; }
        }

        public class UpdateMatingCalculation
        {
            public Guid MatingCalculationId { get; set; }
            public Guid MatingRulesId { get; set; }
            public int ExpectedChildren { get; set; }
            public double InbreedingPercent { get; set; }
            public int LitterAmount { get; set; }

            public bool IsLegal { get; set; }
        }

        public class DeleteMatingCalculation
        {
            public Guid MatingCalculationId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
