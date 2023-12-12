using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
    public class MatingRulesQueries
    {
        public class MatingRulesDetails
        {
            public Guid MatingRulesId { get; set; }

            public double InbreedingPercent { get; set; }

            public int LitterAmount { get; set; }
        }
    }
}
