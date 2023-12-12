using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Events
{
    public class MatingRulesEvents
    {
        public class CreateMatingRules
        {
            public Guid MatingRulesId { get; set; }
            
            public double InbreedingPercent { get; set; }
            public int LitterAmount { get; set; }
            
            public bool IsDeleted { get; set; }
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
            public bool IsDeleted { get; set; }
        }
    }
}
