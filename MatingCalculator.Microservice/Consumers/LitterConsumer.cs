using MassTransit;
using MatingCalculator.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatingCalculator.Microservice.Consumers
{
    public static class LitterConsumer
    {
        public class LitterCreateConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.CreateLitter>
        {
            private readonly LitterApplicationService _applicationService;

            public LitterCreateConsumer(LitterApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.CreateLitter> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.LitterCommandsDto.V1.CreateLitter litter = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.LitterCommandsDto.V1.CreateLitter();


                litter.LitterId = data.LitterId;
                litter.Name = data.LitterName;
                litter.Date = data.LitterBirthDate;
                litter.IsDeleted = data.IsDeleted;

                await _applicationService.Handle(litter);
            }
        }

        public class LitterUpdateConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.UpdateLitter>
        {
            private readonly UserinformationApplicationService _applicationService;

            public LitterUpdateConsumer(UserinformationApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.UpdateLitter> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.LitterCommandsDto.V1.UpdateLitter litter = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.LitterCommandsDto.V1.UpdateLitter();

                litter.LitterId = data.LitterId;
                litter.Name = data.LitterName;
                litter.Date = data.LitterBirthDate;
              

                await _applicationService.Handle(litter);
            }
        }


        public class LitterDeleteConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.DeleteLitter>
        {
            private readonly DiseaseApplicationService _applicationService;

            public LitterDeleteConsumer(DiseaseApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.DeleteLitter> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.LitterCommandsDto.V1.DeleteLitter litter = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.LitterCommandsDto.V1.DeleteLitter();


                litter.LitterId = data.LitterId;

                await _applicationService.Handle(litter);
            }
        }

    }
}
