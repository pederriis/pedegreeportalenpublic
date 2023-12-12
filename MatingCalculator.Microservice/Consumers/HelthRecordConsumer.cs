using MassTransit;
using MatingCalculator.Application.ApplicationServices;
using PedigreePortalen.Shared.HealthRecordMicroservice.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatingCalculator.Microservice.Consumers
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

               PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.HealthRecordCommandsDto.V1.CreateHealthRecord healthRecord = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.HealthRecordCommandsDto.V1.CreateHealthRecord();
                healthRecord.HealthRecordId = data.HealthRecordId;
                healthRecord.DogId = data.AnimalId;
                healthRecord.IsDeleted = false;

                await _applicationService.Handle(healthRecord);
            }
        }
    }
}

