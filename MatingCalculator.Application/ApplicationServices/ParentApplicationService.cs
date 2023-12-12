using MatingCalculator.Application.Interfaces;
using MatingCalculator.Domain.Parenting;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.ParentingCommandsDto;

namespace MatingCalculator.Application.ApplicationServices
{
    public class ParentingApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IParentingRepository _repository;

        public ParentingApplicationService(IUnitOfWork unitOfWork, IParentingRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateParenting cmd => HandleCreate(cmd),

                V1.DeleteParenting cmd => HandleUpdate(cmd.ParentingId,
                    c => c.DeleteParent(Domain.Parenting.IsDeleted.FromBool(cmd.IsDeleted))),

                //V1.AddChildToLitter cmd => HandleUpdate(cmd.ChildId,
                //    c => c.AddChildToLitter(new LitterId(cmd.LitterId))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateParenting cmd)
        {
            if (await _repository.ParentingExists(cmd.ParentingId))
                throw new InvalidOperationException($"Entity with id {cmd.ParentingId} already exists");

            var parenting = new Parenting(

            new ParentingId(cmd.ParentingId),
            new Domain.Dog.DogId(cmd.DogId),
            new Domain.Litter.LitterId(cmd.LitterId),
            new Domain.Parenting.IsDeleted(cmd.IsDeleted));

            await _repository.AddParenting(parenting);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid parentingId, Action<Parenting> operation)
        {
            var parenting = await _repository.LoadParenting(parentingId);

            if (parenting == null)
                throw new InvalidOperationException($"Entity with id {parentingId} cannot be found");

            operation(parenting);

            await _unitOfWork.Commit();
        }
    }
}
