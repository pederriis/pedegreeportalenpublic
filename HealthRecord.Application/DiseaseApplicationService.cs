
using HealthRecord.Domain.Disease;
using HealthRecord.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Commands.DiseaseCommandsDTO;

namespace HealthRecord.Application
{
    public class DiseaseApplicationService
    {
        private readonly IDiseaseRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public DiseaseApplicationService(IDiseaseRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 V1.CreateDisease cmd => HandleCreate(cmd),

                 V1.UpdateDisease cmd => HandleUpdate(cmd.DiseaseId,
                     c => c.UpdateDisease(Name.FromString(cmd.Name)
                         , Date.FromDateTime(cmd.Date)
                         , Note.FromString(cmd.Note)
                         ,Probability.FromDouble(cmd.Probabilty)
                         , IsHereditary.FromBool(cmd.IsHereditary)
                         , IsDeleted.FromBool(cmd.IsDeleted))),

                 V1.DeleteDisease cmd => HandleUpdate(cmd.DiseaseId,
                     c => c.DeleteDisease(IsDeleted.FromBool(cmd.IsDeleted))),

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(V1.CreateDisease cmd)
        {
            if (await _repository.DiseaseExists(cmd.DiseaseId))
                throw new InvalidOperationException($"Entity with id {cmd.DiseaseId} already exists");

            var disesae = new Disease(

            new DiseaseId(cmd.DiseaseId),
            new HealthRecordId(cmd.HealthRecordId),
            new Name(cmd.Name),
            new Date(cmd.Date),
            new Note(cmd.Note),
            new Probability(cmd.Probabilty),
            new IsHereditary(cmd.IsHereditary),
            new IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddDisease(disesae);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid diseaseId, Action<Disease> operation)
        {
            var owner = await _repository.LoadDisease(diseaseId);

            if (owner == null)
                throw new InvalidOperationException($"Entity with id {diseaseId} cannot be found");

            operation(owner);

            await _unitOfWork.Commit();
        }
    }
}
