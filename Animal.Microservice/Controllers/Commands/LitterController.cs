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
    [Route("/Litter")]
    public class LitterController : Controller
    {
        private readonly string createLitterEndpoint = "PedigreePortalen.Shared.AnimalMicroserviceDto.Commands:LitterCommandsDto-V1-CreateLitter";
        private readonly string updateLitterEndpoint = "PedigreePortalen.Shared.AnimalMicroserviceDto.Commands:LitterCommandsDto-V1-UpdateLitter";
        private readonly string deleteLitterEndpoint = "PedigreePortalen.Shared.AnimalMicroserviceDto.Commands:LitterCommandsDto-V1-DeleteLitter";

        private readonly LitterApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<LitterController>();
        private readonly IBus _bus;

        public LitterController(LitterApplicationService applicationService, IBus bus)
        {
            _applicationService = applicationService;
            _bus = bus;
        }

        [Route("CreateLitter")]
        [HttpPost]
        public async Task<IActionResult> Post(LitterCommandsDto.V1.CreateLitter request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{createLitterEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }

        [Route("UpdateLitter")]
        [HttpPut]
        public async Task<IActionResult> Put(LitterCommandsDto.V1.UpdateLitter request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{updateLitterEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }

        [Route("DeleteLitter")]
        [HttpPut]
        public async Task<IActionResult> Put(LitterCommandsDto.V1.DeleteLitter request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{deleteLitterEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }
    }
}
