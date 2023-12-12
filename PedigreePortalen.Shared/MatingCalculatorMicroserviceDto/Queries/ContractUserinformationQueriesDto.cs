using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
   public class ContractUserinformationQueriesDto
    {
        public class ContractUserinformationDetails
        {
            public Guid ContractUserinformationId { get; set; }
            public Guid? ContractId { get; set; }
            public Guid? UserinformationId { get; set; }

            public bool IsDeleted { get; set; }
        }
    }
}
