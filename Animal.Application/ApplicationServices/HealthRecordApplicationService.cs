using Animal.Domain.Animal;
using Animal.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.HealthRecordCommandsDto;

namespace Animal.Application.ApplicationServices
{
    public class HealthRecordApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnimalRepository _repository;

        public HealthRecordApplicationService(IUnitOfWork unitOfWork, IAnimalRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateHealthRecord cmd => HandleCreate(cmd),

                V1.DeleteHealthRecord cmd => HandleUpdate(cmd.HealthRecordId,
                    c => c.DeleteHealthRecord(IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateHealthRecord cmd)
        {
            if (await _repository.HealthRecordExists(cmd.HealthRecordId))
                throw new InvalidOperationException($"Entity with id {cmd.HealthRecordId} already exists");

            var healthRecord = new HealthRecord(

            new HealthRecordId(cmd.HealthRecordId),
            new AnimalId(cmd.AnimalId),
            new IsDeleted(cmd.IsDeleted));

            await _repository.AddHealthRecord(healthRecord);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid healthRecordId, Action<HealthRecord> operation)
        {
            var healthRecord = await _repository.LoadHealthRecord(healthRecordId);

            if (healthRecord == null)
                throw new InvalidOperationException($"Entity with id {healthRecordId} cannot be found");

            operation(healthRecord);

            await _unitOfWork.Commit();
        }
    }
}
