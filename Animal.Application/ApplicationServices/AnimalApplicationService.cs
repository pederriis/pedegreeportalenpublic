using Animal.Domain.Animal;
using Animal.Domain.Human;
using Animal.Domain.Litter;
using Animal.Domain.SubRace;
using PedigreePortalen.Framework;
using System;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.AnimalCommandsDto;

namespace Animal.Application.ApplicationServices
{
    public class AnimalApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnimalRepository _repository;

        public AnimalApplicationService(IUnitOfWork unitOfWork, IAnimalRepository repository)
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
                        new HumanId(cmd.HumanId)
                        , RegNo.FromInt(cmd.RegNo)
                        , PedigreeName.FromString(cmd.PedigreeName)
                        , ShortName.FromString(cmd.ShortName)
                        , BirthDate.FromDateTime(cmd.BirthDate)
                        , DeathDate.FromDateTime(cmd.DeathDate)
                        , Gender.FromBool(cmd.Gender)
                        , Color.FromString(cmd.Color)
                        , WeightInKg.FromDouble(cmd.WeightInKg)
                        , IsBreedable.FromBool(cmd.IsBreedable)
                        , ProfileText.FromString(cmd.ProfileText))),

                V1.DeleteAnimal cmd => HandleUpdate(cmd.AnimalId,
                    c => c.DeleteAnimal(Domain.IsDeleted.FromBool(cmd.IsDeleted))),

                V1.AddAnimalToLitter cmd => HandleUpdate(cmd.AnimalId,
                    c => c.AddAnimalToLitter(new LitterId(cmd.LitterId))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateAnimal cmd)
        {
            if (await _repository.AnimalExists(cmd.AnimalId))
                throw new InvalidOperationException($"Entity with id {cmd.AnimalId} already exists");

            var animal = new Domain.Animal.Animal(

            new AnimalId(cmd.AnimalId),
            new HumanId(cmd.OwnerId),
            new SubRaceId(cmd.SubRaceId),
            new RegNo(cmd.RegNo),
            new PedigreeName(cmd.PedigreeName),
            new ShortName(cmd.ShortName),
            new BirthDate(cmd.BirthDate),
            new DeathDate(cmd.DeathDate),
            new Gender(cmd.Gender),
            new Color(cmd.Color),
            new WeightInKg(cmd.WeightInKg),
            new IsBreedable(cmd.IsBreedable),
            new ProfileText(cmd.ProfileText),
            new Domain.IsDeleted(cmd.IsDeleted));

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
