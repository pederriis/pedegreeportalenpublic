using Kennel.Domain.Kennel;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kennel.Domain.Owner
{
    public class Owner : Entity<OwnerId>
    {
        // Properties to handle the persistence
        public Guid OwnerId { get; private set; }
        
        // Satisfy the serialization requirements
        public Owner() { }

        // Aggregate state properties
        public FirstName FirstName { get; private set; }

        public LastName LastName { get; private set; }

        public Email Email { get; private set; }

        public PhoneNo PhoneNo { get; private set; }

        public Street Street { get; private set; }

        public City City { get; private set; }

        public Zipcode Zipcode { get; private set; }

        public IsDeleted IsDeleted { get; private set; }

        // one to one conn
        public Kennel.Kennel Kennel { get; }

        // List
        
        public Owner(OwnerId ownerId
            , FirstName firstName
            , LastName lastName
            , Email email
            , PhoneNo phoneNo
            , Street street
            , City city
            , Zipcode zipcode
            , IsDeleted isDeleted
            )
        {
            //Kennel = new Kennel.Kennel();
            Apply(new Events.OwnerEvents.CreateOwner
            {
                OwnerId = ownerId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNo = phoneNo,
                Street = street,
                City = city,
                Zipcode = zipcode,
                IsDeleted = isDeleted
            });
        }

        public void UpdateOwner(
              FirstName firstName
            , LastName lastName
            , Email email
            , PhoneNo phoneNo
            , Street street
            , City city
            , Zipcode zipcode
            )
        {
            Apply(new Events.OwnerEvents.UpdateOwner
            {
                OwnerId = OwnerId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNo = phoneNo,
                Street = street,
                City = city,
                Zipcode = zipcode,
            });
        }

        public void DeleteOwner(IsDeleted isDeleted)
        {
            Apply(new Events.OwnerEvents.DeleteOwner
            {
                OwnerId = OwnerId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.OwnerEvents.CreateOwner e:
                    Id = new OwnerId(e.OwnerId);
                    FirstName = new FirstName(e.FirstName);
                    LastName = new LastName(e.LastName);
                    Email = new Email(e.Email);
                    PhoneNo = new PhoneNo(e.PhoneNo);
                    Street = new Street(e.Street);
                    City = new City(e.City);
                    Zipcode = new Zipcode(e.Zipcode);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    OwnerId = e.OwnerId;
                    break;

                case Events.OwnerEvents.UpdateOwner e:
                    FirstName = new FirstName(e.FirstName);
                    LastName = new LastName(e.LastName);
                    Email = new Email(e.Email);
                    PhoneNo = new PhoneNo(e.PhoneNo);
                    Street = new Street(e.Street);
                    City = new City(e.City);
                    Zipcode = new Zipcode(e.Zipcode);
                    break;

                case Events.OwnerEvents.DeleteOwner e:
                    Id = new OwnerId(e.OwnerId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    OwnerId = e.OwnerId;

                    break;
            }
        }
    }
}
