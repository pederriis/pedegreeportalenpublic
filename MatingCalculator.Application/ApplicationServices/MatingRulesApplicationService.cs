using MatingCalculator.Application.Interfaces;
using MatingCalculator.Domain.MatingRules;
using PedigreePortalen.Framework;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.ApplicationServices
{
    public class MatingRulesApplicationService
    {
        private readonly IMatingRulesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public MatingRulesApplicationService(IMatingRulesRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 MatingRulesCommandsDto.V1.CreateMatingRules cmd => HandleCreate(cmd),

                 MatingRulesCommandsDto.V1.UpdateMatingRules cmd => HandleUpdate(cmd.MatingRulesId,
                    c => c.UpdateMatingRules(InbreedingPercent.FromDouble(cmd.InbreedingPercent)
                        , LitterAmount.FromInt(cmd.LitterAmount))),

                 MatingRulesCommandsDto.V1.DeleteMatingRules cmd => HandleUpdate(cmd.MatingRulesId,
                     c => c.DeleteDisease(IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(MatingRulesCommandsDto.V1.CreateMatingRules cmd)
        {
            if (await _repository.MatingRulesExists(cmd.MatingRulesId))
                throw new InvalidOperationException($"Entity with id {cmd.MatingRulesId} already exists");

            var matingRules = new Domain.MatingRules.MatingRules(

            new MatingRulesId(cmd.MatingRulesId),
            new InbreedingPercent(cmd.InbreedingPercent),
            new LitterAmount(cmd.LitterAmount),
         
            new IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddMatingRules(matingRules);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid matingRulesId, Action<Domain.MatingRules.MatingRules> operation)
        {
            var matingRules = await _repository.LoadMatingRules(matingRulesId);

            if (matingRules == null)
                throw new InvalidOperationException($"Entity with id {matingRulesId} cannot be found");

            operation(matingRules);

            await _unitOfWork.Commit();
        }
    }
}
