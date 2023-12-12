using Kennel.Domain.Kennel;
using Kennel.Domain.Owner;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Commands.OwnerCommandsDto;

namespace Kennel.Application.ApplicationServices
{
    public class OwnerApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKennelRepository _repository;

        public OwnerApplicationService(IUnitOfWork unitOfWork, IKennelRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateOwner cmd => HandleCreate(cmd),

                V1.UpdateOwner cmd => HandleUpdate(cmd.OwnerId,
                    c => c.UpdateOwner(
                        FirstName.FromString(cmd.FirstName)
                        , LastName.FromString(cmd.LastName)
                        , Email.FromString(cmd.Email)
                        , PhoneNo.FromString(cmd.PhoneNo)
                        , Street.FromString(cmd.Street)
                        , City.FromString(cmd.City)
                        , Zipcode.FromString(cmd.Zipcode))),

                V1.DeleteOwner cmd => HandleUpdate(cmd.OwnerId,
                    c => c.DeleteOwner(Domain.Owner.IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateOwner cmd)
        {
            if (await _repository.OwnerExists(cmd.OwnerId))
                throw new InvalidOperationException($"Entity with id {cmd.OwnerId} already exists");

            var owner = new Owner(

            new OwnerId(cmd.OwnerId),
            new FirstName(cmd.FirstName),
            new LastName(cmd.LastName),
            new Email(cmd.Email),
            new PhoneNo(cmd.PhoneNo),
            new Street(cmd.Street),
            new City(cmd.City),
            new Zipcode(cmd.Zipcode),
            
            new Domain.Owner.IsDeleted(cmd.IsDeleted));

            await _repository.AddOwner(owner);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid ownerId, Action<Owner> operation)
        {
            var owner = await _repository.LoadOwner(ownerId);

            if (owner == null)
                throw new InvalidOperationException($"Entity with id {ownerId} cannot be found");

            operation(owner);

            await _unitOfWork.Commit();
        }
    }
}
