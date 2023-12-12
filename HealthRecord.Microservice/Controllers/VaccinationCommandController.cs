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
    [Route("/Vaccination")]
    public class VaccinationCommandController : Controller
    {
        private readonly string createVaccinationEndpoint = "PedigreePortalen.Shared.HealthRecordMicroservice.Commands:VaccinationCommandsDTO-V1-CreateVaccination";
        private readonly string updateVaccinationEndpoint = "PedigreePortalen.Shared.HealthRecordMicroservice.Commands:VaccinationCommandsDTO-V1-UpdateVaccination";
        private readonly string deleteVaccinationEndpoint = "PedigreePortalen.Shared.HealthRecordMicroservice.Commands:VaccinationCommandsDTO-V1-DeleteVaccination";

        private readonly VaccinationApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<AnimalCommandController>();
        private readonly IBus _bus;

        public VaccinationCommandController(VaccinationApplicationService applicationService, IBus bus)
        {
            _applicationService = applicationService;
            _bus = bus;
        }

        [Route("CreateVaccination")]
        [HttpPost]
        public async Task<ActionResult> Post(VaccinationCommandsDTO.V1.CreateVaccination request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{createVaccinationEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;

        }

        [Route("UpdateVaccination")]
        [HttpPut]
        public async Task<ActionResult> Put(VaccinationCommandsDTO.V1.UpdateVaccination request) 
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{updateVaccinationEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }

        [Route("DeleteVaccination")]
        [HttpPut]
        public async Task<ActionResult> Put(VaccinationCommandsDTO.V1.DeleteVaccination request) 
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{deleteVaccinationEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);
            }
            return (ActionResult)await response;
        }
    }
}