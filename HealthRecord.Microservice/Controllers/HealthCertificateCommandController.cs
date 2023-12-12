using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HealthRecord.Application;
using Serilog;
using PedigreePortalen.Shared.HealthRecordMicroservice.Commands;
using HealthRecord.Infrastructure.Shared;
using MassTransit;

namespace HealthRecord.Microservice.Controllers
{
    [Route("/HealthCertificate")]
    public class HealthCertificateCommandController : Controller


    {


        private readonly HealthCertificateAppllicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<AnimalCommandController>();
        private readonly IBus _bus;
        private readonly string createHealthCertificateEndpoint = "PedigreePortalen.Shared.HealthRecordMicroservice.Commands:HealthCertificateCommandsDTO-V1-HealthCertificate";
        private readonly string updateHealthCertificateEndpoint = "PedigreePortalen.Shared.HealthRecordMicroservice.Commands:HealthCertificateCommandsDTO-V1-UpdateHealthCertificate";
        private readonly string deleteHealthCertificateEndpoint = "PedigreePortalen.Shared.HealthRecordMicroservice.Commands:HealthCertificateCommandsDTO-V1-DeleteHealthCertificate";


        public HealthCertificateCommandController(HealthCertificateAppllicationService applicationService, IBus bus)
        {
            _applicationService = applicationService;
            _bus = bus;
        }

        [Route("CreateHealthCertificate")]
        [HttpPost]
        public async Task<IActionResult> Post(HealthCertificateCommandsDTO.V1.HealthCertificate request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{createHealthCertificateEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);


            }
            return (ActionResult)await response;
        }


        [Route("UpdateHealthCertificate")]
        [HttpPut]
        public async Task<IActionResult> Put(HealthCertificateCommandsDTO.V1.UpdateHealthCertificate request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{updateHealthCertificateEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);


            }
            return (ActionResult)await response;
        }

        [Route("DeleteHealthCertificate")]
        [HttpPut]
        public async Task<IActionResult> Put(HealthCertificateCommandsDTO.V1.DeleteHealthCertificate request)
        {
            var response = RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
            if (!response.IsFaulted)
            {
                Uri uri = new Uri($"rabbitmq://localhost:5672/{deleteHealthCertificateEndpoint}");
                var endPoint = await _bus.GetSendEndpoint(uri);
                await endPoint.Send(request);


            }
            return (ActionResult)await response;
        }
    }
}