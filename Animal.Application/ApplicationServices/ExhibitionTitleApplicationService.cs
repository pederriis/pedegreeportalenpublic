using Animal.Domain.Animal;
using Animal.Domain.ExhibitionTitle;
using PedigreePortalen.Framework;
using System;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ExhibitionTitleCommandsDto;

namespace Animal.Application.ApplicationServices
{
    public class ExhibitionTitleApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnimalRepository _repository;

        public ExhibitionTitleApplicationService(IUnitOfWork unitOfWork, IAnimalRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateExhibitionTitle cmd => HandleCreate(cmd),

                V1.UpdateExhibitionTitle cmd => HandleUpdate(cmd.ExhibitionTitleId,
                    c => c.UpdateExhibitionTitle(
                        Name.FromString(cmd.Name)
                        , Date.FromDateTime(cmd.Date))),

                V1.DeleteExhibitionTitle cmd => HandleUpdate(cmd.ExhibitionTitleId,
                    c => c.DeleteExhibitionTitle(IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateExhibitionTitle cmd)
        {
            if (await _repository.ExhibitionTitleExists(cmd.ExhibitionTitleId))
                throw new InvalidOperationException($"Entity with id {cmd.ExhibitionTitleId} already exists");

            var exhibitionTitle = new ExhibitionTitle(

            new ExhibitionTitleId(cmd.ExhibitionTitleId),
            new AnimalId(cmd.AnimalId),
            new Name(cmd.Name),
            new Date(cmd.Date),
            new IsDeleted(cmd.IsDeleted));

            await _repository.AddExhibitionTitle(exhibitionTitle);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid exhibitionTitleId, Action<ExhibitionTitle> operation)
        {
            var exhibitionTitle = await _repository.LoadExhibitionTitle(exhibitionTitleId);

            if (exhibitionTitle == null)
                throw new InvalidOperationException($"Entity with id {exhibitionTitleId} cannot be found");

            operation(exhibitionTitle);

            await _unitOfWork.Commit();
        }
    }
}
