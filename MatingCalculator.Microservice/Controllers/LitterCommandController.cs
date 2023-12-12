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
    [Route("/Litter")]
    public class LitterCommandController : Controller

    {

        private readonly LitterApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<LitterCommandController>();

        public LitterCommandController(LitterApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateLitter")]
        [HttpPost]
        public Task<IActionResult> Post(LitterCommandsDto.V1.CreateLitter request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateLitter")]
        [HttpPut]
        public Task<IActionResult> Put(LitterCommandsDto.V1.UpdateLitter request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteLitter")]
        [HttpPut]
        public Task<IActionResult> Put(LitterCommandsDto.V1.DeleteLitter request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}