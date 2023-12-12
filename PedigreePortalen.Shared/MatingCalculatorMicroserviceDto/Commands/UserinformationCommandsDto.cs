using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands
{
   public class UserinformationCommandsDto
    {
        public static class V1
        {
            public class CreateUserinformation
            {
                public Guid UserinformationId { get; set; }

                public string Email { get; set; }
                public string Name { get; set; }
                public string PhoneNo { get; set; }
                
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateUserinformation
            {
                public Guid UserinformationId { get; set; }
                public string Email { get; set; }
                public string Name { get; set; }
                public string PhoneNo { get; set; }

            }

            public class DeleteUserinformation
            {
                public Guid UserinformationId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }

        }
    }
}
