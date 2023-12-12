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
    [Route("/Userinformation")]
    public class UserinformationCommandController : Controller

    {

        private readonly UserinformationApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<DiseaseCommandController>();

        public UserinformationCommandController(UserinformationApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateUserinformation")]
        [HttpPost]
        public Task<IActionResult> Post(UserinformationCommandsDto.V1.CreateUserinformation request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateUserinformation")]
        [HttpPut]
        public Task<IActionResult> Put(UserinformationCommandsDto.V1.UpdateUserinformation request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteUserinformation")]
        [HttpPut]
        public Task<IActionResult> Put(UserinformationCommandsDto.V1.DeleteUserinformation request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}