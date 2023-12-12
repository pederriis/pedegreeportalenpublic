using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace User.Domain.User
{
    public class User : AggregateRoot<UserId>
    {
        public Guid UserId { get; private set; }

        // Satisfy the serialization requirements
        protected User() { }

        // Aggregate state properties
        public LoginUserId LoginUserId { get; private set; }
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }
        public PhoneNo PhoneNo { get; private set; }
        public Street Street { get; private set; }
        public City City { get; private set; }
        public Zipcode Zipcode { get; private set; }
        public ProfileText ProfileText { get; private set; }
        public IsDeleted IsDeleted { get; private set; }

        //List
        public List<Animal.Animal> Animals { get; private set; }

        public User(UserId userId
            , LoginUserId loginUserId
            , FirstName firstName
            , LastName lastName
            , Email email
            , PhoneNo phoneNo
            , Street street
            , City city
            , Zipcode zipcode
            , ProfileText profileText
            , IsDeleted isDeleted
            )
        {
            Animals = new List<Animal.Animal>();
            Apply(new Events.UserEvents.CreateUser
            {
                UserId = userId,
                LoginUserId = loginUserId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNo = phoneNo,
                Street = street,
                City = city,
                Zipcode = zipcode,
                ProfileText = profileText,
                IsDeleted = isDeleted
            });
        }

        public void UpdateUser(  
            FirstName firstName
            , LastName lastName
            , Email email
            , PhoneNo phoneNo
            , Street street
            , City city
            , Zipcode zipcode
            , ProfileText profileText
            ,IsDeleted isDeleted
            )
        {
            Apply(new Events.UserEvents.UpdateUser
            {
                UserId = UserId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNo = phoneNo,
                Street = street,
                City = city,
                Zipcode = zipcode,
                ProfileText = profileText,
                IsDeleted=isDeleted
            });
        }

        public void DeletedUser(IsDeleted isDeleted)
        {
            Apply(new Events.UserEvents.DeletedUser
            {
                UserId = UserId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.UserEvents.CreateUser e:
                    Id = new UserId(e.UserId);
                    LoginUserId = new LoginUserId(e.LoginUserId);
                    FirstName = new FirstName(e.FirstName);
                    LastName = new LastName(e.LastName);
                    Email = new Email(e.Email);
                    PhoneNo = new PhoneNo(e.PhoneNo);
                    Street = new Street(e.Street);
                    City = new City(e.City);
                    Zipcode = new Zipcode(e.Zipcode);
                    ProfileText = new ProfileText(e.ProfileText);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    UserId = e.UserId;
                    break;

                case Events.UserEvents.UpdateUser e:
                    Id = new UserId(e.UserId);
                    FirstName = new FirstName(e.FirstName);
                    LastName = new LastName(e.LastName);
                    Email = new Email(e.Email);
                    PhoneNo = new PhoneNo(e.PhoneNo);
                    Street = new Street(e.Street);
                    City = new City(e.City);
                    Zipcode = new Zipcode(e.Zipcode);
                    ProfileText = new ProfileText(e.ProfileText);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    UserId = e.UserId;
                    break;

                case Events.UserEvents.DeletedUser e:
                    Id = new UserId(e.UserId);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    UserId = e.UserId;
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            var valid = Id != null;

            if (!valid)
                throw new DomainExceptions.InvalidEntityState(this,$"Post-checks failed.");
        }
    }
}
