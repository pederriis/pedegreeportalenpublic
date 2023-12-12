using MatingCalculator.Application.Interfaces;
using PedigreePortalen.Framework;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.ApplicationServices
{
   public class ContractUserinformationApplicationService
    {
        private readonly IContractUserinformationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ContractUserinformationApplicationService(IContractUserinformationRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 ContractUserinformationCommandsDto.V1.CreateContractUserinformation cmd => HandleCreate(cmd),


                 ContractUserinformationCommandsDto.V1.DeleteContractUserinformation cmd => HandleUpdate(cmd.ContractuserinformationId,
                     c => c.DeleteContractUserinformation(Domain.ContractUserinformation.IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(ContractUserinformationCommandsDto.V1.CreateContractUserinformation cmd)
        {
            if (await _repository.ContractUserinformationExists(cmd.ContractUserinformationId))
                throw new InvalidOperationException($"Entity with id {cmd.ContractUserinformationId} already exists");

            var contractUserinformation = new Domain.ContractUserinformation.ContractUserinformation(

            new Domain.ContractUserinformation.ContractUserinformationId(cmd.ContractUserinformationId),
            new Domain.Contract.ContractId(cmd.ContractId),
            new Domain.Userinformation.UserinformationId(cmd.UserinformationId),

            new Domain.ContractUserinformation.IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddContractUserinformation(contractUserinformation);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid ContractUserinformationId, Action<Domain.ContractUserinformation.ContractUserinformation> operation)
        {
            var contractUserinformation = await _repository.LoadContractUserinformation(ContractUserinformationId);

            if (contractUserinformation == null)
                throw new InvalidOperationException($"Entity with id {ContractUserinformationId} cannot be found");

            operation(contractUserinformation);

            await _unitOfWork.Commit();
        }
    }
}
