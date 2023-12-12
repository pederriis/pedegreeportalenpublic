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
    [Route("/Parenting")]
    public class ParentingCommandController : Controller

    {

        private readonly ParentingApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ParentingCommandController>();

        public ParentingCommandController(ParentingApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateParenting")]
        [HttpPost]
        public Task<IActionResult> Post(ParentingCommandsDto.V1.CreateParenting request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        //[Route("UpdateDoglitter")]
        //[HttpPut]
        //public Task<IActionResult> Put(DogLitterCommandsDto.V1.do request)
        //    => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteParenting")]
        [HttpPut]
        public Task<IActionResult> Put(ParentingCommandsDto.V1.DeleteParenting request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}