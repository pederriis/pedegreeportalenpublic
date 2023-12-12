using Kennel.Application.ApplicationServices;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Consumers
{
    public static class OwnerConsumer
    {
        public class OwnerCreateConsumer : IConsumer<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.CreateUser>
        {
            private readonly OwnerApplicationService _applicationService;

            public OwnerCreateConsumer(OwnerApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.CreateUser> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.KennelMicroserviceDto.Commands.OwnerCommandsDto.V1.CreateOwner owner= new PedigreePortalen.Shared.KennelMicroserviceDto.Commands.OwnerCommandsDto.V1.CreateOwner();


                owner.OwnerId = data.UserId;
                owner.FirstName = data.FirstName;
                owner.LastName = data.LastName;
                owner.Street = data.Street;
                owner.PhoneNo = data.PhoneNo;
                owner.Zipcode = data.Zipcode;
                owner.City = data.City;
                owner.Email = data.Email;

                await _applicationService.Handle(owner);
            }
        }

        public class OwnerUpdateConsumer : IConsumer<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.UpdateUser>
        {
            private readonly OwnerApplicationService _applicationService;

            public OwnerUpdateConsumer(OwnerApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.UpdateUser> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.KennelMicroserviceDto.Commands.OwnerCommandsDto.V1.UpdateOwner owner = new PedigreePortalen.Shared.KennelMicroserviceDto.Commands.OwnerCommandsDto.V1.UpdateOwner();


                owner.OwnerId = data.UserId;
                owner.FirstName = data.FirstName;
                owner.LastName = data.LastName;
                owner.Street = data.Street;
                owner.PhoneNo = data.PhoneNo;
                owner.Zipcode = data.Zipcode;
                owner.City = data.City;
                owner.Email = data.Email;

                await _applicationService.Handle(owner);
            }
        }


        public class OwnerDeleteConsumer : IConsumer<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.DeleteUser>
        {
            private readonly OwnerApplicationService _applicationService;

            public OwnerDeleteConsumer(OwnerApplicationService applicationService)
            {
                _applicationService = applicationService;
            }

            public async Task Consume(ConsumeContext<PedigreePortalen.Shared.UserMicroserviceDto.Commands.UserCommandsDto.V1.DeleteUser> context)
            {
                var data = context.Message;

                PedigreePortalen.Shared.KennelMicroserviceDto.Commands.OwnerCommandsDto.V1.DeleteOwner owner = new PedigreePortalen.Shared.KennelMicroserviceDto.Commands.OwnerCommandsDto.V1.DeleteOwner();


                owner.OwnerId = data.UserId;

                await _applicationService.Handle(owner);
            }
        }

    }

       
    }


