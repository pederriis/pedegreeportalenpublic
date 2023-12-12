using HealthRecord.Domain.Animal;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Commands.AnimalCommandsDTO;

namespace HealthRecord.Application
{
    public class AnimalApplicationService
    {
        private readonly IAnimalRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public AnimalApplicationService(IAnimalRepository repository, IUnitOfWork unitOfWork)
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
                         , OwnerId.FromString(cmd.OwnerId)
                         , IsDeleted.FromBool(cmd.IsDeleted))),

                 V1.DeleteAnimal cmd => HandleUpdate(cmd.AnimalId,
                     c => c.DeleteAnimal(IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(V1.CreateAnimal cmd)
        {
            if (await _repository.AnimalExists(cmd.AnimalId))
                throw new InvalidOperationException($"Entity with id {cmd.AnimalId} already exists");

            var animal = new Domain.Animal.Animal(

            new AnimalId(cmd.AnimalId),
            new Name(cmd.Name),
            new OwnerId(cmd.OwnerId),
            new IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddAnimal(animal);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid animalId, Action<Domain.Animal.Animal> operation)
        {
            var animal = await _repository.LoadAnimal(animalId);

            if (animal == null)
                throw new InvalidOperationException($"Entity with id {animalId} cannot be found");

            operation(animal);

            await _unitOfWork.Commit();
        }
    }
}
