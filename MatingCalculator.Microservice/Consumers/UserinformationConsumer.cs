using MassTransit;
using MatingCalculator.Application.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MatingCalculator.Microservice.Consumers
{
    public static class UserinformationConsumer
    {
        public class UserinformationCreateConsumer : IConsumer<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.CreateUser>
        {
            private readonly UserinformationApplicationService _applicationService;

            public UserinformationCreateConsumer(UserinformationApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.CreateUser> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.UserinformationCommandsDto.V1.CreateUserinformation userinformation = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.UserinformationCommandsDto.V1.CreateUserinformation();


                userinformation.UserinformationId = data.UserId;
                userinformation.Name = data.FirstName+" "+data.LastName;
                userinformation.Email = data.Email;
                userinformation.PhoneNo = data.PhoneNo;

                await _applicationService.Handle(userinformation);
            }
        }

        public class UserinformationUpdateConsumer : IConsumer<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.UpdateUser>
        {
            private readonly UserinformationApplicationService _applicationService;

            public UserinformationUpdateConsumer(UserinformationApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.UpdateUser> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.UserinformationCommandsDto.V1.UpdateUserinformation userinformation = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.UserinformationCommandsDto.V1.UpdateUserinformation();


                userinformation.UserinformationId = data.UserId;
                userinformation.Name = data.FirstName + " " + data.LastName;
                userinformation.Email = data.Email;
                userinformation.PhoneNo = data.PhoneNo;


                await _applicationService.Handle(userinformation);
            }
        }


        public class UserinformationDeleteConsumer : IConsumer<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.DeleteUser>
        {
            private readonly UserinformationApplicationService _applicationService;

            public UserinformationDeleteConsumer(UserinformationApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.DeleteUser> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.UserinformationCommandsDto.V1.DeleteUserinformation userinformation = new PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands.UserinformationCommandsDto.V1.DeleteUserinformation();


                userinformation.UserinformationId = data.UserId;

                await _applicationService.Handle(userinformation);
            }
        }

    }


}