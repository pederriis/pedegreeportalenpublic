using PedigreePortalen.Shared.AnimalMicroserviceDto.Querys;
using System;
using System.Collections.Generic;

namespace PedigreePortalen.Shared.UserMicroserviceDto.Querys
{
    public static class  UserQuerysDto
    {
        public class UserDetails
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
            public string ProfileText { get; set; }
            public bool IsDeleted { get; set; }

            public List<AnimalQuriesDto.AnimalDetails> AnimalDetails { get; set; }
            public List<LitterQuerysDto.LitterDetails> Litters { get; set; }
        }
    }
}
