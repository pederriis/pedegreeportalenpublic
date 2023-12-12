using Animal.Application.ApplicationServices;
using Animal.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using Serilog;
using System;
using System.Threading.Tasks;
using MassTransit;

namespace Animal.Microservice.Controllers.Commands
{
    [Route("/Animal")]
    public class AnimalController : Controller
    {
        private readonly AnimalApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<AnimalController>();
        private readonly IBus _bus;

        private readonly string createAnimalEndpoint = "PedigreePortalen.Shared.AnimalMicroserviceDto.Commands:AnimalCommandsDto-V1-CreateAnimal";
        private readonly string updateAnimalEndpoint = "PedigreePortalen.Shared.AnimalMicroserviceDto.Commands:AnimalCommandsDto-V1-UpdateAnimal";
        private readonly string deleteAnimalEndpoint = "PedigreePortalen.Shared.AnimalMicroserviceDto.Commands:AnimalCommandsDto-V1-DeleteAnimal";
        private readonly string addAnimalToLitter = "PedigreePortalen.Shared.AnimalMicroserviceDto.Commands:AnimalCommandsDto-V1-AddAnimalToLitter";

        public AnimalController(AnimalApplicationService applicationService, IBus bus)
        {
            _applicationService = applicationService;
            _bus = bus;
        }

        [Route("CreateAnimal")]
        [HttpPost]
        public async Task<ActionResult> Post(AnimalCommandsDto.V1.CreateAnimal request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{createAnimalEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }

        [Route("UpdateAnimal")]
        [HttpPut]
        public async Task<ActionResult> Put(AnimalCommandsDto.V1.UpdateAnimal request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{updateAnimalEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }
        
        [Route("DeleteAnimal")]
        [HttpPut]
        public async Task<ActionResult> Put(AnimalCommandsDto.V1.DeleteAnimal request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{deleteAnimalEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }

        [Route("AddAnimalToLitter")]
        [HttpPut]
        public async Task<ActionResult> Put(AnimalCommandsDto.V1.AddAnimalToLitter request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{addAnimalToLitter}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }
    }
}
