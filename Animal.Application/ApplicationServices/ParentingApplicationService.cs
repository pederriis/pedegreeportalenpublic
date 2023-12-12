using Animal.Domain.Animal;
using Animal.Domain.Litter;
using PedigreePortalen.Framework;
using System;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ParentingCommandsDto;
using Animal.Domain.Parenting;

namespace Animal.Application.ApplicationServices
{
    public class ParentingApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnimalRepository _repository;

        public ParentingApplicationService(IUnitOfWork unitOfWork, IAnimalRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateParenting cmd => HandleCreate(cmd),

                V1.DeleteParenting cmd => HandleUpdate(cmd.ParentingId,
                    c => c.DeleteParenting(Domain.Parenting.IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateParenting cmd)
        {
            if (await _repository.ParentingExists(cmd.ParentingId))
                throw new InvalidOperationException($"Entity with id {cmd.ParentingId} already exists");

            var parenting = new Parenting(

            new ParentingId(cmd.ParentingId),
            new AnimalId(cmd.AnimalId),
            new LitterId(cmd.LitterId),
            new Domain.Parenting.IsDeleted(cmd.IsDeleted));

            await _repository.AddParenting(parenting);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid parentingId, Action<Parenting> operation)
        {
            var parrent = await _repository.LoadParenting(parentingId);

            if (parrent == null)
                throw new InvalidOperationException($"Entity with id {parentingId} cannot be found");

            operation(parrent);

            await _unitOfWork.Commit();
        }
    }
}
