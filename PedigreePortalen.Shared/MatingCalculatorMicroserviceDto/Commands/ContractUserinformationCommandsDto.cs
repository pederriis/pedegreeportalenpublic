using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
   public class ContractUserinformationCommandsDto
    {
        public static class V1
        {
            public class CreateContractUserinformation
            {
                public Guid ContractUserinformationId { get; set; }

                public Guid ContractId { get; set; }
                public Guid UserinformationId { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

          

            public class DeleteContractUserinformation
            {
                public Guid ContractuserinformationId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }

        }
    }
}
