using Animal.Application.ApplicationServices;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;

namespace Animal.Microservice.Consumers
{
    public static class UserConsumer
    {
        public class CreateUserConsumer : IConsumer<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.CreateUser>
        {
            private readonly HumanApplicationService _applicationService;

            public CreateUserConsumer(HumanApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.CreateUser> context)
            {
                var data = context.Message;

                HumanCommandsDto.V1.CreateHuman human = new HumanCommandsDto.V1.CreateHuman();

                human.HumanId = data.UserId;
                human.IsDeleted = data.IsDeleted;

                await _applicationService.Handle(human);
            }
        }

        public class DeleteUserConsumer : IConsumer<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.DeleteUser>
        {
            private readonly HumanApplicationService _applicationService;

            public DeleteUserConsumer(HumanApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.DeleteUser> context)
            {
                var data = context.Message;

                HumanCommandsDto.V1.DeleteHuman human = new HumanCommandsDto.V1.DeleteHuman();

                human.HumanId = data.UserId;
                human.IsDeleted = data.IsDeleted;

                await _applicationService.Handle(human);
            }
        }
    }
}
