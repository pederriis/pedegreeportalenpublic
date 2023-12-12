using Kennel.Application.ApplicationServices;
using MassTransit;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Consumers
{
    public static class HealthCertificateConsumer
    {
        public class HealthCertificateCreateConsumer : IConsumer<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.HealthCertificateCommandsDTO.V1.HealthCertificate>
        {
            private readonly HealthCertificateApplicationService _applicationService;

            public HealthCertificateCreateConsumer(HealthCertificateApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.HealthCertificateCommandsDTO.V1.HealthCertificate> context)
            {
                var data = context.Message;

                HealthCertificateCommandsDto.V1.CreateHealthCertificate healthCertificate = new HealthCertificateCommandsDto.V1.CreateHealthCertificate();


                healthCertificate.HealthCertificateId = data.HealthCertificateId;
                healthCertificate.HealthRecordId = data.HealthRecordId;
                healthCertificate.HealthCertificateName = data.Name;
                healthCertificate.HealthCertificateNote = data.Note;
                healthCertificate.HealthCertificateDate = data.Date;
                healthCertificate.IsDeleted = data.IsDeleted;
                await _applicationService.Handle(healthCertificate);
            }
        }

        public class HealthCertificateUpdateConsumer : IConsumer<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.HealthCertificateCommandsDTO.V1.UpdateHealthCertificate>
        {
            private readonly HealthCertificateApplicationService _applicationService;

            public HealthCertificateUpdateConsumer(HealthCertificateApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.HealthCertificateCommandsDTO.V1.UpdateHealthCertificate> context)
            {
                var data = context.Message;

                HealthCertificateCommandsDto.V1.UpdateHealthCertificate healthCertificate = new HealthCertificateCommandsDto.V1.UpdateHealthCertificate();

                healthCertificate.HealthCertificateId = data.HealthCertificateId;
                healthCertificate.HealthCertificateName = data.Name;
                healthCertificate.HealthCertificateNote = data.Note;
                healthCertificate.HealthCertificateDate = data.Date;
                
                await _applicationService.Handle(healthCertificate);
            }
        }

        public class HealthCertificateDeleteConsumer : IConsumer<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.HealthCertificateCommandsDTO.V1.DeleteHealthCertificate>
        {
            private readonly HealthCertificateApplicationService _applicationService;

            public HealthCertificateDeleteConsumer(HealthCertificateApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.HealthCertificateCommandsDTO.V1.DeleteHealthCertificate> context)
            {
                var data = context.Message;

                HealthCertificateCommandsDto.V1.DeleteHealthCertificate healthCertificate = new HealthCertificateCommandsDto.V1.DeleteHealthCertificate();

                healthCertificate.HealthCertificateId=data.HealthCertificateId;
                healthCertificate.IsDeleted = data.IsDeleted;

                await _applicationService.Handle(healthCertificate);
            }
        }
    }
}
