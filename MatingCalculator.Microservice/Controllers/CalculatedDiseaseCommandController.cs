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
    [Route("/CalculatedDisease")]
    public class CalculatedDiseaseCommandController : Controller

    {

        private readonly CalculatedDiseaseApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<CalculatedDiseaseCommandController>();

        public CalculatedDiseaseCommandController(CalculatedDiseaseApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateCalculatedDisease")]
        [HttpPost]
        public Task<IActionResult> Post(CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateCalculatedDisease")]
        [HttpPut]
        public Task<IActionResult> Put(CalculatedDiseaseCommandsDto.V1.UpdateCalculatedDisease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteCalculatedDisease")]
        [HttpPut]
        public Task<IActionResult> Put(CalculatedDiseaseCommandsDto.V1.DeleteCalculatedDisease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}