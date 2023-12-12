using System;
using System.Collections.Generic;
using System.Text;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Querys.KennelQuerysDto;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Querys
{
    public class OwnerQuerysDto
    {
        public class OwnerDetails
        {
            public Guid OwnerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNo { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Zipcode { get; set; }
            public bool IsDeleted { get; set; }

            public KennelDetails Kennel { get; set; }
        }
    }
}
