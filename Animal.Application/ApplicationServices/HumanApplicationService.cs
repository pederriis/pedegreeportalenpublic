using Animal.Domain.Human;
using PedigreePortalen.Framework;
using System;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.HumanCommandsDto;

namespace Animal.Application.ApplicationServices
{
    public class HumanApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnimalRepository _repository;

        public HumanApplicationService(IUnitOfWork unitOfWork, IAnimalRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateHuman cmd => HandleCreate(cmd),

                V1.DeleteHuman cmd => HandleUpdate(cmd.HumanId,
                    c => c.DeleteHuman(IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateHuman cmd)
        {
            if (await _repository.ExhibitionTitleExists(cmd.HumanId))
                throw new InvalidOperationException($"Entity with id {cmd.HumanId} already exists");

            var human = new Human(

            new HumanId(cmd.HumanId),
            new IsDeleted(cmd.IsDeleted));

            await _repository.AddHuman(human);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid humanId, Action<Human> operation)
        {
            var human = await _repository.LoadHuman(humanId);

            if (human == null)
                throw new InvalidOperationException($"Entity with id {humanId} cannot be found");

            operation(human);

            await _unitOfWork.Commit();
        }
    }
}
