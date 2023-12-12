using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using User.Domain;
using User.Domain.Animal;
using User.Domain.User;
using static PedigreePortalen.Shared.UserMicroserviceDto.Commands.AnimalCommandsDto;

namespace User.Application.ApplicationServices
{
    public class AnimalApplicationService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AnimalApplicationService(IUserRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateAnimal cmd => HandleCreate(cmd),

                V1.UpdateAnimal cmd => HandleUpdate(cmd.AnimalId,
                    c => c.UpdateAnimal(Name.FromString(cmd.Name)
                        , cmd.UserId
                        , Domain.Animal.IsDeleted.FromBool(cmd.IsDeleted)
                        )),

                V1.DeleteAnimal cmd => HandleUpdate(cmd.AnimalId,
                    c => c.DeletedAnimal(Domain.Animal.IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateAnimal cmd)
        {
            if (await _repository.AnimalExists(cmd.AnimalId))
                throw new InvalidOperationException($"Entity with id {cmd.AnimalId} already exists");

            var animal = new Domain.Animal.Animal(

            new AnimalId(cmd.AnimalId),
            new UserId(cmd.UserId),
            new Name(cmd.Name),
            new Domain.Animal.IsDeleted(cmd.IsDeleted)
            );

            await _repository.AddAnimal(animal);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid animalId, Action<Domain.Animal.Animal> operation)
        {
            var animal = await _repository.LoadAnimal(animalId);

            if (animal == null)
                throw new InvalidOperationException($"Entity with id {animal} cannot be found");

            operation(animal);

            await _unitOfWork.Commit();
        }
    }
}

