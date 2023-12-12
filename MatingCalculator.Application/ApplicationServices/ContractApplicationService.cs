using MatingCalculator.Application.Interfaces;
using MatingCalculator.Domain.Contract;
using PedigreePortalen.Framework;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MatingCalculator.Application.ApplicationServices
{
    public class ContractApplicationService
    {
        private readonly IContractRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ContractApplicationService(IContractRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 ContractCommandsDto.V1.CreateContract cmd => HandleCreate(cmd),

                 ContractCommandsDto.V1.UpdateContract cmd => HandleUpdate(cmd.ContractId,
                     c => c.UpdateContract(MaleDogName.FromString(cmd.MaleDogName)
                         , FemaleDogName.FromString(cmd.FemaleDogName)
                         , MaleDogOwnerName.FromString(cmd.MaleDogOwnerName)
                         ,FemaleDogOwnerName.FromString(cmd.FemaleDogOwnerName)
                         , CreationDate.FromDateTime(cmd.CreationDate)
                         ,MatingDate.FromDateTime(cmd.MatingDate)
                         )),

                 ContractCommandsDto.V1.DeleteContract cmd => HandleUpdate(cmd.ContracteId,
                     c => c.DeleteContract(Domain.Contract.IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(ContractCommandsDto.V1.CreateContract cmd)
        {
            if (await _repository.ContractExists(cmd.ContractId))
                throw new InvalidOperationException($"Entity with id {cmd.ContractId} already exists");

            var contract = new Domain.Contract.Contract(

            new ContractId(cmd.ContractId),
            new Domain.MatingCalculation.MatingCalculationId(cmd.MatingCalculationId),
            new MaleDogName(cmd.MaleDogName),
            new FemaleDogName(cmd.FemaleDogName),
            new MaleDogOwnerName(cmd.MaleDogOwnerName),
            new FemaleDogOwnerName(cmd.MaleDogOwnerName),
            new CreationDate(cmd.CreationDate),
            new MatingDate(cmd.MatingDate),
            
            new Domain.Contract.IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddContract(contract);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid contractId, Action<Domain.Contract.Contract> operation)
        {
            var contract = await _repository.LoadContract(contractId);

            if (contract == null)
                throw new InvalidOperationException($"Entity with id {contractId} cannot be found");

            operation(contract);

            await _unitOfWork.Commit();
        }
    }
}
