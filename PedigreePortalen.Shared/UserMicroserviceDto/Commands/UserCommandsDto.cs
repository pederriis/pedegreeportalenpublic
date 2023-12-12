using System;

namespace PedigreePortalen.Shared.UserMicroserviceDto.Commands
{
    public class UserCommandsDto
    {
        public static class V1
        {
            public class CreateUser
            {
                public Guid UserId { get; set; }
                public string LoginUserId { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string PhoneNo { get; set; }
                public string Street { get; set; }
                public string City { get; set; }
                public string Zipcode { get; set; }
                public string ProfileText { get; set; } = "";
                public bool IsDeleted { get; set; } = false;
            }

            public class UpdateUser
            {
                public Guid UserId { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
                public string PhoneNo { get; set; }
                public string Street { get; set; }
                public string City { get; set; }
                public string Zipcode { get; set; }
                public string ProfileText { get; set; } = "";
                public bool IsDeleted { get; set; } = false;
            }

            public class DeleteUser
            {
                public Guid UserId { get; set; }
                public bool IsDeleted { get; set; } = true;
            }
        }
    }
}
