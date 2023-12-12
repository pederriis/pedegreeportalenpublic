using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Models
{
    public class UserViewModel
    {
        public class UserCreate 
        {
            public Guid UserId { get; set; }
            public string LoginUserId { get; set; }
            [Required(ErrorMessage = "Navn mangler.")]
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string PhoneNo { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string Zipcode { get; set; }
            public string ProfileText { get; set; }
        }

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

            public List<AnimalViewModel.DetailsAnimal> Animals { get; set; }
            public List<LitterViewModel.LitterDetails> Litters { get; set; }
        }
    }
}
