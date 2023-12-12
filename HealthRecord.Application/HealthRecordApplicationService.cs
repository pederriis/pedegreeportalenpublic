using HealthRecord.Domain.Animal;
using HealthRecord.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Commands.HealthRecordCommandsDTO;

namespace HealthRecord.Application
{
    public class HealthRecordApplicationService
    {
        private readonly IHealthRecordRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public HealthRecordApplicationService(IHealthRecordRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
             command switch
             {
                 V1.CreateHealthRecord cmd => HandleCreate(cmd),

                

                 _ => Task.CompletedTask
             };

        private async Task HandleCreate(V1.CreateHealthRecord cmd)
        {
            if (await _repository.HealthRecordExists(cmd.HealthRecordId))
                throw new InvalidOperationException($"Entity with id {cmd.HealthRecordId} already exists");

            var healthRecord = new Domain.HealthRecord.HealthRecord(

            new HealthRecordId(cmd.HealthRecordId),
            new AnimalId(cmd.AnimalId));
            

            await _repository.AddHealthRecord(healthRecord);
            await _unitOfWork.Commit();
        }

      
    }
}
