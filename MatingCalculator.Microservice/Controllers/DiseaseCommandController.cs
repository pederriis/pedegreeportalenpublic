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
    [Route("/Disease")]
    public class DiseaseCommandController : Controller

    {

        private readonly DiseaseApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<DiseaseCommandController>();

        public DiseaseCommandController(DiseaseApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateDisease")]
        [HttpPost]
        public Task<IActionResult> Post(DiseaseCommandsDto.V1.CreateDisease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateDisease")]
        [HttpPut]
        public Task<IActionResult> Put(DiseaseCommandsDto.V1.UpdateDisease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteDisease")]
        [HttpPut]
        public Task<IActionResult> Put(DiseaseCommandsDto.V1.DeleteDisease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}