using Kennel.Application.ApplicationServices;
using MassTransit;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Consumers
{
    public static class HealthRecordConsumer
    {
        public class CreateHealthRecordConsumer : IConsumer<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.HealthRecordCommandsDTO.V1.CreateHealthRecord>
        {
            private readonly HealthRecordApplicationService _applicationService;

            public CreateHealthRecordConsumer(HealthRecordApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.HealthRecordCommandsDTO.V1.CreateHealthRecord> context)
            {
                var data = context.Message;

                HealthRecordCommandsDto.V1.CreateHealthRecord healthRecord = new HealthRecordCommandsDto.V1.CreateHealthRecord();

                healthRecord.HealthRecordId = data.HealthRecordId;
                healthRecord.AnimalId = data.AnimalId;
                healthRecord.IsDeleted = false;

                await _applicationService.Handle(healthRecord);
            }
        }
    }
}
