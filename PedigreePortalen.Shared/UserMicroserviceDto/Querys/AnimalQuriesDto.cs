using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.UserMicroserviceDto.Querys
{
    public class AnimalQuriesDto
    {

        public class AnimalDetails
        {
            public Guid AnimalId { get; set; }
            public Guid UserId { get; set; }

           public string Name { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
