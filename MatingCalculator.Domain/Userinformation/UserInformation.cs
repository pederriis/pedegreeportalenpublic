
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatingCalculator.Domain.Userinformation
{
    public class Userinformation: Entity<UserinformationId>
    {
        public Guid UserinformationId { get; private set; }

       // public Guid ContractId { get; private set; }

        public Userinformation() { }
        public Email Email { get; private set; }

        public Name Name { get; private set; }

        public PhoneNo PhoneNo { get; set; }

        public IsDeleted IsDeleted { get; set; }
        public List<ContractUserinformation.ContractUserinformation> ContractUserinformations { get; }

        public List<Dog.Dog> Dogs { get;}

        public Userinformation(

           UserinformationId userinformationId

           , Email email
           , Name name
           , PhoneNo phoneNo
           , IsDeleted isDeleted   
           )
        {
            ContractUserinformations = new List<ContractUserinformation.ContractUserinformation>();
            Apply(new Events.UserinformationEvents.CreateUserinformation
            {
                UserinformationId=userinformationId
                ,Email = email
                ,Name = name
                ,PhoneNo = phoneNo
                ,IsDeleted = isDeleted
            });
        }

        public void UpdateUserinformation(

          
            Email email
           , Name name
           , PhoneNo phoneNo
            )
        {
            Apply(new Events.UserinformationEvents.UpdateUserinformation
            {

                Email = email
                ,Name = name
                ,PhoneNo = phoneNo
            });
        }

        public void DeleteUserinformation(IsDeleted isDeleted)
        {
            Apply(new Events.UserinformationEvents.DeleteUserinformation
            {
                UserinformationId = UserinformationId,
                IsDeleted = isDeleted
            });
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.UserinformationEvents.CreateUserinformation e:
                    Id = new UserinformationId(e.UserinformationId);

                    Email = new Email(e.Email);
                    Name = new Name(e.Name);
                    PhoneNo = new PhoneNo(e.PhoneNo);
                    IsDeleted = new IsDeleted(e.IsDeleted);

                    UserinformationId = e.UserinformationId;
                    break;

                case Events.UserinformationEvents.UpdateUserinformation e:
                    Email = new Email(e.Email);
                    Name = new Name(e.Name);
                    PhoneNo = new PhoneNo(e.PhoneNo);

                    break;
                case Events.UserinformationEvents.DeleteUserinformation e:
                    Id = new UserinformationId(e.UserinformationId);

                    IsDeleted = new IsDeleted(e.IsDeleted);

                    UserinformationId = e.UserinformationId;
                    break;
            }
        }



    }
}
