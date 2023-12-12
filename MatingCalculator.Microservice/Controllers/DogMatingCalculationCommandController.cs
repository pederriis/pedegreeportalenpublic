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
    [Route("/DogMatingCalculation")]
    public class DogMatingCalculationCommandController : Controller

    {

        private readonly DogMatingCalculationApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<DogMatingCalculationCommandController>();

        public DogMatingCalculationCommandController(DogMatingCalculationApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateDogMatingCalculation")]
        [HttpPost]
        public Task<IActionResult> Post(DogMatingCalculationCommandsDto.V1.CreateDogMatingCalculation request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        //[Route("UpdateDoglitter")]
        //[HttpPut]
        //public Task<IActionResult> Put(DogLitterCommandsDto.V1.do request)
        //    => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteDogMatingCalculation")]
        [HttpPut]
        public Task<IActionResult> Put(DogMatingCalculationCommandsDto.V1.DeleteDogMatingCalculation request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}