using MatingCalculator.Application.Interfaces;
using PedigreePortalen.Framework;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.ApplicationServices
{
    public class DogMatingCalculationApplicationService
    {
        private readonly IDogMatingCalculationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DogMatingCalculationApplicationService(IDogMatingCalculationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 DogMatingCalculationCommandsDto.V1.CreateDogMatingCalculation cmd => HandleCreate(cmd),


                 DogMatingCalculationCommandsDto.V1.DeleteDogMatingCalculation cmd => HandleUpdate(cmd.DogMatingCalculationId,
                     c => c.DeleteDogMatingCalculation(Domain.DogMatingCalculation.IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(DogMatingCalculationCommandsDto.V1.CreateDogMatingCalculation cmd)
        {
            if (await _repository.DogMatingCalculationExists(cmd.DogMatingCalculatorId))
                throw new InvalidOperationException($"Entity with id {cmd.DogMatingCalculatorId} already exists");

            var DogMatingCalculation = new Domain.DogMatingCalculation.DogMatingCalculation(

            new Domain.DogMatingCalculation.DogMatingCalculationId(cmd.DogMatingCalculatorId),
            new Domain.Dog.DogId(cmd.DogId),
            new Domain.MatingCalculation.MatingCalculationId(cmd.MatingCalculationId),


            new Domain.DogMatingCalculation.IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddDogMatingCalculation(DogMatingCalculation);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid dogMatingCalculationId, Action<Domain.DogMatingCalculation.DogMatingCalculation> operation)
        {
            var dogLitter = await _repository.LoadDogMatingCalculation(dogMatingCalculationId);

            if (dogLitter == null)
                throw new InvalidOperationException($"Entity with id {dogMatingCalculationId} cannot be found");

            operation(dogLitter);

            await _unitOfWork.Commit();
        }
    }
}
