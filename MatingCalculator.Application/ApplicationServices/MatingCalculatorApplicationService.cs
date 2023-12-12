using MatingCalculator.Application.Interfaces;
using MatingCalculator.Domain.MatingCalculation;
using PedigreePortalen.Framework;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.ApplicationServices
{
    public class MatingCalculatorApplicationService
    {
        private readonly IMatingCalculationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MatingCalculatorApplicationService(IMatingCalculationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 MatingCalculationCommandDto.V1.CreateMatingCalculation cmd => HandleCreate(cmd),

                 MatingCalculationCommandDto.V1.UpdateMatingCalculation cmd => HandleUpdate(cmd.MatingCalculationId,
                     c => c.UpdateMatingCalculation(new Domain.MatingRules.MatingRulesId(cmd.MatingRulesId)
                         ,ExpectedChildren.FromInt(cmd.ExpectedChildren)
                         , InbreedingPercent.FromDouble(cmd.InbreedingPercent)
                         , IsLegal.FromBool(cmd.IsLegal)
                         , LitterAmount.FromInt(cmd.LitterAmount)
                         , IsDeleted.FromBool(cmd.IsLegal))),

                 MatingCalculationCommandDto.V1.DeleteMatingCalculation cmd => HandleUpdate(cmd.MatingCalculationId,
                     c => c.DeleteMatingCalculation(Domain.MatingCalculation.IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(MatingCalculationCommandDto.V1.CreateMatingCalculation cmd)
        {
            if (await _repository.MatingCalculationExists(cmd.MatingCalculationId))
                throw new InvalidOperationException($"Entity with id {cmd.MatingCalculationId} already exists");

            var matingCalculation = new Domain.MatingCalculation.MatingCalculation(

            new MatingCalculationId(cmd.MatingCalculationId),
            new Domain.MatingRules.MatingRulesId(cmd.MatingRulesId),
            new ExpectedChildren(cmd.ExpectedChildren),
            new InbreedingPercent(cmd.InbreedingPercent),
            new IsLegal(cmd.IsLegal),
            new LitterAmount(cmd.LitterAmount),

            new Domain.MatingCalculation.IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddMatingCalculation(matingCalculation);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid matingCalculationId, Action<Domain.MatingCalculation.MatingCalculation> operation)
        {
            var matingCalculation = await _repository.LoadMatingCalculation(matingCalculationId);

            if (matingCalculation == null)
                throw new InvalidOperationException($"Entity with id {matingCalculationId} cannot be found");

            operation(matingCalculation);

            await _unitOfWork.Commit();
        }
    }
}
