using MatingCalculator.Application.Intefaces;
using MatingCalculator.Domain.Dog;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;

namespace MatingCalculator.Application.ApplicationServices
{
    public class DogApplicationService
    {
        private readonly IDogRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DogApplicationService(IDogRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 DogCommandsDto.V1.CreateDog cmd => HandleCreate(cmd),

                 DogCommandsDto.V1.UpdateDog cmd => HandleUpdate(cmd.DogId,
                     c => c.UpdateDog( SubRaceId.FromString(cmd.SubRaceId)
                         //,RaceId.FromString(cmd.RaceId)
                         ,new Domain.Userinformation.UserinformationId(cmd.UserinformationId)
                        // ,new Domain.Litter.LitterId(cmd.HomeLitterId)
                         , ChildAmount.FromInt(cmd.ChildAmount)
                         , Gender.FromBool(cmd.Gender)
                         , Name.FromString(cmd.Name)
                         , IsDeleted.FromBool(cmd.IsDeleted))),

                 DogCommandsDto.V1.DeleteDog cmd => HandleUpdate(cmd.DogId,
                     c => c.DeleteDog(IsDeleted.FromBool(cmd.IsDeleted))),

                 DogCommandsDto.V1.AddDogToLitter cmd => HandleUpdate(cmd.DogId,
                   c => c.AddDogToLitter(new Domain.Litter.LitterId(cmd.LitterId))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(DogCommandsDto.V1.CreateDog cmd)
        {
            if (await _repository.DogExists(cmd.DogId))
                throw new InvalidOperationException($"Entity with id {cmd.DogId} already exists");

            var dog = new Domain.Dog.Dog(

            new DogId(cmd.DogId),
            //new RaceId(cmd.RaceId),
            new SubRaceId(cmd.SubRaceId),
            new Domain.Userinformation.UserinformationId(cmd.UserinformationId),
            //new Domain.Litter.LitterId(cmd.HomeLitterId),
            new ChildAmount(cmd.ChildAmount),
            new Name(cmd.Name),
            new Gender(cmd.Gender),
            
            new IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddDog(dog);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid dogId, Action<Domain.Dog.Dog> operation)
        {
            var dog = await _repository.LoadDog(dogId);

            if (dog == null)
                throw new InvalidOperationException($"Entity with id {dogId} cannot be found");

            operation(dog);

            await _unitOfWork.Commit();
        }
    }
}
