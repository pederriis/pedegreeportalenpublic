using Kennel.Domain.HealthCertificate;
using Kennel.Domain.HealthRecord;
using PedigreePortalen.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.KennelMicroserviceDto.Commands.HealthCertificateCommandsDto;

namespace Kennel.Application.ApplicationServices
{
    public class HealthCertificateApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKennelRepository _repository;

        public HealthCertificateApplicationService(IUnitOfWork unitOfWork, IKennelRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public Task Handle(object command) =>
            command switch
            {
                V1.CreateHealthCertificate cmd => HandleCreate(cmd),

                V1.UpdateHealthCertificate cmd => HandleUpdate(cmd.HealthCertificateId,
                    c => c.UpdateHealthCertificate(
                        HealthCertificateName.FromString(cmd.HealthCertificateName)
                        , HealthCertificateDate.FromDateTime(cmd.HealthCertificateDate)
                        , HealthCertificateNote.FromString(cmd.HealthCertificateNote))),

                V1.DeleteHealthCertificate cmd => HandleUpdate(cmd.HealthCertificateId,
                    c => c.DeleteHealthCertificate(Domain.HealthCertificate.IsDeleted.FromBool(cmd.IsDeleted))),

                _ => Task.CompletedTask
            };

        private async Task HandleCreate(V1.CreateHealthCertificate cmd)
        {
            if (await _repository.HealthRecordExists(cmd.HealthCertificateId))
                throw new InvalidOperationException($"Entity with id {cmd.HealthCertificateId} already exists");

            var healthCertificate = new HealthCertificate(

            new HealthCertificateId(cmd.HealthCertificateId),
            new HealthRecordId(cmd.HealthRecordId),
            new HealthCertificateName(cmd.HealthCertificateName),
            new HealthCertificateDate(cmd.HealthCertificateDate),
            new HealthCertificateNote(cmd.HealthCertificateNote),
            new Domain.HealthCertificate.IsDeleted(cmd.IsDeleted));

            await _repository.AddHealthCertificate(healthCertificate);
            await _unitOfWork.Commit();
        }

        private async Task HandleUpdate(Guid healthCertificateId, Action<HealthCertificate> operation)
        {
            var healthCertificate = await _repository.LoadHealthCertificate(healthCertificateId);

            if (healthCertificate == null)
                throw new InvalidOperationException($"Entity with id {healthCertificateId} cannot be found");

            operation(healthCertificate);

            await _unitOfWork.Commit();
        }
    }
}
