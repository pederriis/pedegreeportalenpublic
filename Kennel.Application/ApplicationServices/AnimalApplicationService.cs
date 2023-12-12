using Kennel.Domain.Animal;
using Kennel.Domain.Protokol;
using PedigreePortalen.Framework;
using System;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Commands.AnimalCommandsDto;

namespace Kennel.Application.ApplicationServices
{
    public class AnimalApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKennelRepository _repository;

        public AnimalApplicationService(IUnitOfWork unitOfWork, IKennelRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateAnimal cmd => HandleCreate(cmd),

                V1.UpdateAnimal cmd => HandleUpdate(cmd.AnimalId,
                    c => c.UpdateAnimal(
                        //SubRaceId.FromString(cmd.SubRaceId)
                        RegNo.FromInt(cmd.RegNo)
                        , PedigreeName.FromString(cmd.PedigreeName)
                        , BirthDate.FromDateTime(cmd.BirthDate)
                        , DeathDate.FromDateTime(cmd.DeathDate)
                        , Gender.FromBool(cmd.Gender)
                        , Color.FromString(cmd.Color)
                        , IsBreedable.FromBool(cmd.IsBreedable))),
                        
                V1.DeleteAnimal cmd => HandleUpdate(cmd.AnimalId,
                    c => c.DeleteAnimal(Domain.Animal.IsDeleted.FromBool(cmd.IsDeleted))),

                V1.AddAnimalToProtokol cmd => HandleUpdate(cmd.AnimalId,
                    c => c.AddAnimalToProtokol(
                        new ProtokolId(cmd.ProtokolId))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateAnimal cmd)
        {
            if (await _repository.AnimalExists(cmd.AnimalId))
                throw new InvalidOperationException($"Entity with id {cmd.AnimalId} already exists");

            var animal = new Domain.Animal.Animal(

            new AnimalId(cmd.AnimalId),
            //new ProtokolId(cmd.ProtokolId),
            new SubRaceId(cmd.SubRaceId),
            new RegNo(cmd.RegNo),
            new PedigreeName(cmd.PedigreeName),
            new BirthDate(cmd.BirthDate),
            new DeathDate(cmd.DeathDate),
            new Gender(cmd.Gender),
            new Color(cmd.Color),
            new IsBreedable(cmd.IsBreedable),
            new Domain.Animal.IsDeleted(cmd.IsDeleted));

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
