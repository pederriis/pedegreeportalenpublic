using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthRecord.Application;
using HealthRecord.Infrastructure.Shared;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.HealthRecordMicroservice.Commands;
using Serilog;



namespace HealthRecord.Microservice.Controllers
{
    [Route("/Disease")]
    public class DiseaseCommandController : Controller

    
    {
        private readonly IBus _bus;
        private readonly string createDiseaseEndpoint = "PedigreePortalen.Shared.HealthRecordMicroservice.Commands:DiseaseCommandsDTO-V1-CreateDisease";
        private readonly string updateDiseaseEndpoint = "PedigreePortalen.Shared.HealthRecordMicroservice.Commands:DiseaseCommandsDTO-V1-UpdateDisease";
        private readonly string deleteDiseaseEndpoint = "PedigreePortalen.Shared.HealthRecordMicroservice.Commands:DiseaseCommandsDTO-V1-DeleteDisease";

        private readonly DiseaseApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<DiseaseCommandController>();

        public DiseaseCommandController(DiseaseApplicationService applicationService, IBus bus)
        {
            _applicationService = applicationService;
            _bus = bus;
        }

        [Route("CreateDisease")]
        [HttpPost]
        public async Task<IActionResult> Post(DiseaseCommandsDTO.V1.CreateDisease request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{createDiseaseEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);


            }
            return (ActionResult)await response;
        }

        [Route("UpdateDisease")]
        [HttpPut]
        public async Task<IActionResult> Put(DiseaseCommandsDTO.V1.UpdateDisease request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{updateDiseaseEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);


            }
            return (ActionResult)await response;
        }
        [Route("DeleteDisease")]
        [HttpPut]
        public async Task<IActionResult> Put(DiseaseCommandsDTO.V1.DeleteDisease request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{deleteDiseaseEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);


            }
            return (ActionResult)await response;
        }
    }
}