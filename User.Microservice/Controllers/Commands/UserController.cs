using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.UserMicroserviceDto.Commands;
using Serilog;
using System;
using System.Threading.Tasks;
using User.Application.ApplicationServices;
using User.Infrastructure.Shared;

namespace User.Microservice.Controllers.Commands
{
    [Route("/User")]
    public class UserController : Controller
    {
        private readonly UserApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<UserController>();
        private readonly IBus _bus;

        private readonly string createUserEndpoint = "PedigreePortalen.Shared.UserMicroserviceDto.Commands:UserCommandsDto-V1-CreateUser";
        private readonly string updateUserEndpoint = "PedigreePortalen.Shared.UserMicroserviceDto.Commands:UserCommandsDto-V1-UpdateUser";
        private readonly string deleteUserEndpoint = "PedigreePortalen.Shared.UserMicroserviceDto.Commands:UserCommandsDto-V1-DeleteUser";

        public UserController(UserApplicationService applicationService, IBus bus)
        {
            _applicationService = applicationService;
            _bus = bus;
        }

        [Route("CreateUser")]
        [HttpPost]
        public async Task<ActionResult> Post(UserCommandsDto.V1.CreateUser request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{createUserEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }
        
        [Route("UpdateUser")]
        [HttpPut]
        public async Task<IActionResult> Put(UserCommandsDto.V1.UpdateUser request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{updateUserEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }
            

        [Route("DeleteUser")]
        [HttpPut]
        public async Task<ActionResult> Put(UserCommandsDto.V1.DeleteUser request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{deleteUserEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }
    }
}
