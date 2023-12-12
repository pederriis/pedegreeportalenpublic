using Animal.Application.ApplicationServices;
using Animal.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Animal.Microservice.Controllers.Commands
{
    [Route("/Record")]
    public class HealthRecordController : Controller
    {
        private readonly HealthRecordApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<HealthRecordController>();

        public HealthRecordController(HealthRecordApplicationService applicationService)
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
