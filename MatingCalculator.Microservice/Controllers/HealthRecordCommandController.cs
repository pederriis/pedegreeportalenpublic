using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatingCalculator.Application.ApplicationServices;
using MatingCalculator.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using Serilog;

namespace MatingCalculator.Microservice.Controllers
{
   
    [Route("/HealthRecord")]
    public class HealthRecordCommandController : Controller
    {
        private readonly HealthRecordApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<HealthRecordCommandController>();

        public HealthRecordCommandController(HealthRecordApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateHealthRecord")]
        [HttpPost]
        public Task<IActionResult> Post(HealthRecordCommandsDto.V1.CreateHealthRecord request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        //[Route("UpdateHealthRecord")]
        //[HttpPut]
        //public Task<IActionResult> Put(HealthRecordCommandsDto.V1.UpdateHealthRecord request)
        //    => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteHealthRecord")]
        [HttpPut]
        public Task<IActionResult> Put(HealthRecordCommandsDto.V1.DeleteHealthRecord request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}