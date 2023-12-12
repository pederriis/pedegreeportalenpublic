using Kennel.Application.ApplicationServices;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;

namespace Kennel.Microservice.Consumers
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

                DiseaseCommandsDto.V1.CreateDisease disease = new DiseaseCommandsDto.V1.CreateDisease();


                disease.DiseaseId = data.DiseaseId;
                disease.HealthRecordId = data.HealthRecordId;
                disease.DiseaseName = data.Name;
                disease.DiseaseNote = data.Note;
                disease.DiseaseDate = data.Date;
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

                DiseaseCommandsDto.V1.UpdateDisease disease = new DiseaseCommandsDto.V1.UpdateDisease();


                disease.DiseaseId = data.DiseaseId;
                disease.DiseaseName = data.Name;
                disease.DiseaseNote = data.Note;
                disease.DiseaseDate = data.Date;

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

                DiseaseCommandsDto.V1.DeleteDisease disease = new DiseaseCommandsDto.V1.DeleteDisease();


                disease.DiseaseId = data.DiseaseId;
                
                await _applicationService.Handle(disease);
            }
        }
    }
}
