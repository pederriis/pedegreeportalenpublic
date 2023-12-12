using Animal.Application.ApplicationServices;
using Animal.Infrastructure.Shared;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Animal.Microservice.Controllers.Commands
{
    [Route("/Parenting")]
    public class ParentingController : Controller
    {
        private readonly string createParentingEndpoint = "PedigreePortalen.Shared.AnimalMicroserviceDto.Commands:ParentingCommandsDto-V1-CreateParenting";
        private readonly string deleteParentingEndpoint = "PedigreePortalen.Shared.AnimalMicroserviceDto.Commands:ParentingCommandsDto-V1-CreateParenting";
        
        private readonly ParentingApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ParentingController>();
        private readonly IBus _bus;

        public ParentingController(ParentingApplicationService applicationService, IBus bus)
        {
            _applicationService = applicationService;
            _bus = bus;
        }

        [Route("CreateParenting")]
        [HttpPost]
        public async Task<ActionResult> Post(ParentingCommandsDto.V1.CreateParenting request) 
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{createParentingEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }

        [Route("DeleteParenting")]
        [HttpPut]
        public async Task<ActionResult> Put(ParentingCommandsDto.V1.DeleteParenting request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{deleteParentingEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }
    }
}
