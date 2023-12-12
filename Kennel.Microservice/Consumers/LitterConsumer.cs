using Kennel.Application.ApplicationServices;
using MassTransit;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Consumers
{
    public static class LitterConsumer
    {
        public class CreateLitterConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.CreateLitter>
        {
            private readonly LitterApplicationService _applicationService;

            public CreateLitterConsumer(LitterApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.CreateLitter> context)
            {
                var data = context.Message;

                LitterCommandsDto.V1.CreateLitter litter = new LitterCommandsDto.V1.CreateLitter();

                litter.LitterId = data.LitterId;
                litter.LitterName = data.LitterName;
                litter.LitterBirthDate = data.LitterBirthDate;
                litter.IsDeleted = data.IsDeleted;

                await _applicationService.Handle(litter);
            }
        }

        public class UpdateLitterConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.UpdateLitter>
        {
            private readonly LitterApplicationService _applicationService;

            public UpdateLitterConsumer(LitterApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.UpdateLitter> context)
            {
                var data = context.Message;

                LitterCommandsDto.V1.UpdateLitter litter = new LitterCommandsDto.V1.UpdateLitter();

                litter.LitterId = data.LitterId;
                litter.LitterName = data.LitterName;
                litter.LitterBirthDate = data.LitterBirthDate;

                await _applicationService.Handle(litter);
            }
        }

        public class DeleteLitterConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.DeleteLitter>
        {
            private readonly LitterApplicationService _applicationService;

            public DeleteLitterConsumer(LitterApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.LitterCommandsDto.V1.DeleteLitter> context)
            {
                var data = context.Message;

                LitterCommandsDto.V1.DeleteLitter litter = new LitterCommandsDto.V1.DeleteLitter();

                litter.LitterId = data.LitterId;
                litter.IsDeleted = data.IsDeleted;

                await _applicationService.Handle(litter);
            }
        }
    }
}
