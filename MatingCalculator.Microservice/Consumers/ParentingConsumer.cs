using MassTransit;
using MatingCalculator.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatingCalculator.Microservice.Consumers
{
    public static class ParentingConsumer
    {
        public class ParentingCreateConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ParentingCommandsDto.V1.CreateParenting>
        {
            private readonly ParentingApplicationService _applicationService;

            public ParentingCreateConsumer(ParentingApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ParentingCommandsDto.V1.CreateParenting> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.ParentingCommandsDto.V1.CreateParenting parenting = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.ParentingCommandsDto.V1.CreateParenting();


                parenting.ParentingId = data.ParentingId;
                parenting.DogId = data.AnimalId;
                parenting.LitterId = data.LitterId;
             
               parenting.IsDeleted = data.IsDeleted;

                await _applicationService.Handle(parenting);
            }
        }

       


        public class ParentingDeleteConsumer : IConsumer<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ParentingCommandsDto.V1.DeleteParenting>
        {
            private readonly ParentingApplicationService _applicationService;

            public ParentingDeleteConsumer(ParentingApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.AnimalMicroserviceDto.Commands.ParentingCommandsDto.V1.DeleteParenting> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.ParentingCommandsDto.V1.DeleteParenting parenting = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.ParentingCommandsDto.V1.DeleteParenting();


                parenting.ParentingId = data.ParentingId;

                await _applicationService.Handle(parenting);
            }
        }

    }
}
