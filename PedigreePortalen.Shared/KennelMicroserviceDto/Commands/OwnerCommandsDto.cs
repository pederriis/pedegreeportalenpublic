using System;
using System.Collections.Generic;
using System.Text;

namespace PedigreePortalen.Shared.KennelMicroserviceDto.Commands
{
    public class OwnerCommandsDto
    {
        public static class V1
        {
            public class CreateOwner
            {
                public Guid OwnerId { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string PhoneNo { get; set; }
                public string Street { get; set; }
                public string City { get; set; }
                public string Zipcode { get; set; }
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateOwner
            {
                public Guid OwnerId { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string PhoneNo { get; set; }
                public string Street { get; set; }
                public string City { get; set; }
                public string Zipcode { get; set; }
            }

            public class DeleteOwner
            {
                public Guid OwnerId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
