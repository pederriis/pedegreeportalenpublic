using Kennel.Domain.Disease;
using Kennel.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Commands.DiseaseCommandsDto;

namespace Kennel.Application.ApplicationServices
{
    public class DiseaseApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKennelRepository _repository;

        public DiseaseApplicationService(IUnitOfWork unitOfWork, IKennelRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateDisease cmd => HandleCreate(cmd),

                V1.UpdateDisease cmd => HandleUpdate(cmd.DiseaseId,
                    c => c.UpdateDisease(
                        DiseaseName.FromString(cmd.DiseaseName)
                        , DiseaseDate.FromDateTime(cmd.DiseaseDate)
                        , DiseaseNote.FromString(cmd.DiseaseNote)
                        , IsHereditary.FromBool(cmd.IsHereditary))),

                V1.DeleteDisease cmd => HandleUpdate(cmd.DiseaseId,
                    c => c.DeleteDisease(Domain.Disease.IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateDisease cmd)
        {
            if (await _repository.AnimalExists(cmd.DiseaseId))
                throw new InvalidOperationException($"Entity with id {cmd.DiseaseId} already exists");

            var disease = new Disease(

            new DiseaseId(cmd.DiseaseId),
            new HealthRecordId(cmd.HealthRecordId),
            new DiseaseName(cmd.DiseaseName),
            new DiseaseDate(cmd.DiseaseDate),
            new DiseaseNote(cmd.DiseaseNote),
            new IsHereditary(cmd.IsHereditary),
            new Domain.Disease.IsDeleted(cmd.IsDeleted));

            await _repository.AddDisease(disease);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid diseaseId, Action<Disease> operation)
        {
            var disease = await _repository.LoadDisease(diseaseId);

            if (disease == null)
                throw new InvalidOperationException($"Entity with id {diseaseId} cannot be found");

            operation(disease);

            await _unitOfWork.Commit();
        }
    }
}
