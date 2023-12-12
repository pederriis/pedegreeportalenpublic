using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries
{
   public class UserinformationCommandsDto
    {
        public class Userinformationdetails
        {
            public Guid UserinformationId { get; set; }

           public string Email { get; set; }
            
            public string Name { get; set; }

            public string PhoneNo { get; set; }
           
            public bool IsDeleted { get; set; }

            public List<DogQuriesDto.DogDetails> DogDetails { get; set; }

        }
    }
}
