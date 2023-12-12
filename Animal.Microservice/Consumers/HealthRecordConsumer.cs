using Animal.Application.ApplicationServices;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedigreePortalen.Shared.HealthRecordMicroservice.Commands;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;

namespace Animal.Microservice.Consumers
{
    public static class HealthRecordConsumer
    { 
        public class HealthRecordCreateConsumer : IConsumer<HealthRecordCommandsDTO.V1.CreateHealthRecord>
        {
            private readonly HealthRecordApplicationService _applicationService;

            public HealthRecordCreateConsumer(HealthRecordApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<HealthRecordCommandsDTO.V1.CreateHealthRecord> context)
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
