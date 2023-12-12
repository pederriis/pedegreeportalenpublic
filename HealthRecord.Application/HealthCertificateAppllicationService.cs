using HealthRecord.Domain.HealthCertificate;
using HealthRecord.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.HealthRecordMicroservice.Commands.HealthCertificateCommandsDTO;

namespace HealthRecord.Application
{
    public class HealthCertificateAppllicationService
    {
        private readonly IHealthCertificateRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public HealthCertificateAppllicationService(IHealthCertificateRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.HealthCertificate cmd => HandleCreate(cmd),

                V1.UpdateHealthCertificate cmd => HandleUpdate(cmd.HealthCertificateId,
                    c => c.UpdatehealthCertificate(Name.FromString(cmd.Name)
                        ,Date.FromDateTime(cmd.Date)
                        ,Note.FromString(cmd.Note)
                        , IsDeleted.FromBool(cmd.IsDeleted)
                       )),

                V1.DeleteHealthCertificate cmd => HandleUpdate(cmd.HealthCertificateId,
                    c => c.DeleteHealthCertificate(IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.HealthCertificate cmd)
        {
            if (await _repository.HealthCertificateExists(cmd.HealthCertificateId))
                throw new InvalidOperationException($"Entity with id {cmd.HealthCertificateId} already exists");

            var healthCertificate = new HealthCertificate(

            new HealthCertificateId(cmd.HealthCertificateId),
            new HealthRecordId(cmd.HealthRecordId),
            new Name(cmd.Name),
            new Date(cmd.Date),
            new Note(cmd.Note),
            new IsDeleted(cmd.IsDeleted)

                );

            await _repository.AddHealthCertificate(healthCertificate);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid healthCertificateID, Action<HealthCertificate> operation)
        {
            var healthCertificate = await _repository.LoadHealthCertificate(healthCertificateID);

            if (healthCertificate == null)
                throw new InvalidOperationException($"Entity with id {healthCertificateID} cannot be found");

            operation(healthCertificate);

            await _unitOfWork.Commit();
        }
    }
}
