using MassTransit;
using MatingCalculator.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatingCalculator.Microservice.Consumers
{
     public static class DiseaseConsumer
    {
        public class DiseaseCreateConsumer : IConsumer<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.DiseaseCommandsDTO.V1.CreateDisease>
        {
            private readonly DiseaseApplicationService _applicationService;

            public DiseaseCreateConsumer(DiseaseApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.DiseaseCommandsDTO.V1.CreateDisease> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DiseaseCommandsDto.V1.CreateDisease disease = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DiseaseCommandsDto.V1.CreateDisease();


                disease.DiseaseId=data.DiseaseId;
                disease.HealthRecordId = data.HealthRecordId;
                disease.Name = data.Name;
                disease.Date = data.Date;
                disease.Note = data.Note;
                disease.Probability = data.Probabilty;
                disease.IsHereditary = data.IsHereditary;
                disease.IsDeleted = data.IsDeleted;

                await _applicationService.Handle(disease);
            }
        }

        public class DiseaseUpdateConsumer : IConsumer<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.DiseaseCommandsDTO.V1.UpdateDisease>
        {
            private readonly DiseaseApplicationService _applicationService;

            public DiseaseUpdateConsumer(DiseaseApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.DiseaseCommandsDTO.V1.UpdateDisease> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DiseaseCommandsDto.V1.UpdateDisease disease = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DiseaseCommandsDto.V1.UpdateDisease();

                disease.DiseaseId = data.DiseaseId;
                disease.Name = data.Name;
                disease.Date = data.Date;
                disease.Note = data.Note;
                disease.Probability = data.Probabilty;
                disease.IsHereditary = data.IsHereditary;

                await _applicationService.Handle(disease);
            }
        }


        public class DiseaseDeleteConsumer : IConsumer<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.DiseaseCommandsDTO.V1.DeleteDisease>
        {
            private readonly DiseaseApplicationService _applicationService;

            public DiseaseDeleteConsumer(DiseaseApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.HealthRecordMicroservice.Commands.DiseaseCommandsDTO.V1.DeleteDisease> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DiseaseCommandsDto.V1.DeleteDisease disease = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.DiseaseCommandsDto.V1.DeleteDisease();


                disease.DiseaseId = data.DiseaseId;

                await _applicationService.Handle(disease);
            }
        }

    }
}
