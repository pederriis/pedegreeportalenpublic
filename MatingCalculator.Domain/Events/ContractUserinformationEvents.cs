using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Events
{
    class ContractUserinformationEvents
    { 
        public class CreateContractUserinformation
        {
            public Guid ContractUserinformationId { get; set; }
            public Guid ContractId { get; set; }
            public Guid UserinformationId { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class DeleteContractUserinformation
        {
            public Guid ContractUserinformationId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
