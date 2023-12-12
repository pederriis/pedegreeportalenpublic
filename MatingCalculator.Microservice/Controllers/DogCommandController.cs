using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatingCalculator.Application.ApplicationServices;
using MatingCalculator.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;

namespace MatingCalculator.Microservice.Controllers
{
    [Route("/Dog")]
    public class DogCommandController : Controller

    {

        private readonly DogApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<DogCommandController>();

        public DogCommandController(DogApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateDog")]
        [HttpPost]
        public Task<IActionResult> Post(DogCommandsDto.V1.CreateDog request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateDog")]
        [HttpPut]
        public Task<IActionResult> Put(DogCommandsDto.V1.UpdateDog request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteDog")]
        [HttpPut]
        public Task<IActionResult> Put(DogCommandsDto.V1.DeleteDog request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}