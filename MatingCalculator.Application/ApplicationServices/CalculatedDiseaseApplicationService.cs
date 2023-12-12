using MatingCalculator.Application.Interfaces;
using MatingCalculator.Domain.CalculatedDisease;
using PedigreePortalen.Framework;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.ApplicationServices
{
    public class CalculatedDiseaseApplicationService
    {
        private readonly ICalculatedDiseaseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CalculatedDiseaseApplicationService(ICalculatedDiseaseRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease cmd => HandleCreate(cmd),

                 CalculatedDiseaseCommandsDto.V1.UpdateCalculatedDisease cmd => HandleUpdate(cmd.CalculatedDiseaseId,
                     
                     c => c.UpdateCalculatedDisease(Domain.CalculatedDisease.Name.FromString(cmd.Name)
                         , Probability.FromDouble(cmd.Probability) )),

                 CalculatedDiseaseCommandsDto.V1.DeleteCalculatedDisease cmd => HandleUpdate(cmd.CalculatedDiseaseId,
                     c => c.DeleteCalculatedDisease(Domain.CalculatedDisease.IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease cmd)
        {
            if (await _repository.CalculatedDiseaseExists(cmd.CalculatedDiseaseId))
                throw new InvalidOperationException($"Entity with id {cmd.CalculatedDiseaseId} already exists");

            var calculatedisease = new Domain.CalculatedDisease.CalculatedDisease(

            new CalculatedDiseaseId(cmd.CalculatedDiseaseId),
            new Domain.MatingCalculation.MatingCalculationId(cmd.MatingCalculationId),
            new Domain.CalculatedDisease.Name(cmd.Name),
            new Probability(cmd.Probability),
            new Domain.CalculatedDisease.IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddCalculatedDisease(calculatedisease);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid calculateddiseaseId, Action<Domain.CalculatedDisease.CalculatedDisease> operation)
        {
            var calculateddisease = await _repository.LoadCalculatedDisease(calculateddiseaseId);

            if (calculateddisease == null)
                throw new InvalidOperationException($"Entity with id {calculateddiseaseId} cannot be found");

            operation(calculateddisease);

            await _unitOfWork.Commit();
        }
    }
}
