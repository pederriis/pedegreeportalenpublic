using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.Events
{
    public static class UserEvents
    {
        public class CreateUser
        {
            public Guid UserId { get; set; }
            public string LoginUserId { get; set; }
            public string FirstName { get;  set; }
            public string LastName { get; set; }
            public string Email { get;  set; }
            public string PhoneNo { get;  set; }
            public string Street { get;  set; }
            public string City { get;  set; }
            public string Zipcode { get;  set; }
            public string ProfileText { get;  set; }
            public bool IsDeleted { get; set; }
        }

        public class UpdateUser
        {
            public Guid UserId { get; set; }
            public Guid LoginUserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNo { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Zipcode { get; set; }
            public string ProfileText { get; set; }
            public bool IsDeleted { get; set; }
        }

        public class DeletedUser
        {
            public Guid UserId { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
