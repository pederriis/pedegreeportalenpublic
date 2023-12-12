using Kennel.Domain.Animal;
using Kennel.Domain.Child;
using Kennel.Domain.Litter;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Commands.ChildCommandsDto;

namespace Kennel.Application.ApplicationServices
{
    public class ChildApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKennelRepository _repository;

        public ChildApplicationService(IUnitOfWork unitOfWork, IKennelRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateChild cmd => HandleCreate(cmd),

                V1.DeleteChild cmd => HandleUpdate(cmd.ChildId,
                    c => c.DeleteChild(Domain.Child.IsDeleted.FromBool(cmd.IsDeleted))),

                V1.AddChildToLitter cmd => HandleUpdate(cmd.ChildId,
                    c => c.AddChildToLitter(new LitterId(cmd.LitterId))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateChild cmd)
        {
            if (await _repository.ChildExists(cmd.ChildId))
                throw new InvalidOperationException($"Entity with id {cmd.ChildId} already exists");

            var child = new Child(

            new ChildId(cmd.ChildId),
            new AnimalId(cmd.AnimalId),
            new Domain.Child.IsDeleted(cmd.IsDeleted));

            await _repository.AddChild(child);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid childId, Action<Child> operation)
        {
            var child = await _repository.LoadChild(childId);

            if (child == null)
                throw new InvalidOperationException($"Entity with id {childId} cannot be found");

            operation(child);

            await _unitOfWork.Commit();
        }
    }
}
