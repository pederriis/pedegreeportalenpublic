using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthRecord.Application;
using HealthRecord.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.HealthRecordMicroservice.Commands;
using Serilog;


namespace HealthRecord.Microservice.Controllers
{
    [Route("/Animal")]
    public class AnimalCommandController : Controller


    {


        private readonly AnimalApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<AnimalCommandController>();

        public AnimalCommandController(AnimalApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateAnimal")]
        [HttpPost]
        public Task<IActionResult> Post(AnimalCommandsDTO.V1.CreateAnimal request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateAnimal")]
        [HttpPut]
        public Task<IActionResult> Put(AnimalCommandsDTO.V1.UpdateAnimal request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteAnimal")]
        [HttpPut]
        public Task<IActionResult> Put(AnimalCommandsDTO.V1.DeleteAnimal request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}