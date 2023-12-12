using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthRecord.Application;
using HealthRecord.Infrastructure.Shared;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PedigreePortalen.Shared.HealthRecordMicroservice.Commands;
using Serilog;

namespace HealthRecord.Microservice.Controllers
{
     [Route("/HealthRecord")]
    public class HealthRecordCommandController : Controller
    {       
        private readonly HealthRecordApplicationService _applicationService;
        private static readonly Serilog.ILogger Log = Serilog.Log.ForContext<DiseaseCommandController>();

        private readonly IBus _bus;
        private readonly string createHealthRecordEndpoint = "PedigreePortalen.Shared.HealthRecordMicroservice.Commands:HealthRecordCommandsDTO-V1-CreateHealthRecord";
        public HealthRecordCommandController(HealthRecordApplicationService applicationService, IBus bus)
        {
            _applicationService = applicationService;
            _bus = bus;
        }

        [Route("CreateHealthRecord")]
        [HttpPost]
        public async Task<IActionResult> Post(HealthRecordCommandsDTO.V1.CreateHealthRecord request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{createHealthRecordEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }

        //[Route("UpdateHealthRecord")]
        //[HttpPut]
        //public Task<IActionResult> Put(HealthRecordCommandsDTO.V1.UpdateHealthRecord request)
        //    => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        //[Route("DeleteHealthRecord")]
        //[HttpPut]
        //public Task<IActionResult> Put(HealthRecordCommandsDTO.V1.DeleteHealthRecord request)
        //    => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}