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
    [Route("/MatingRules")]
    public class MatingRulesCommandController : Controller

    {

        private readonly MatingRulesApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<MatingRulesCommandController>();

        public MatingRulesCommandController(MatingRulesApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateMatingRules")]
        [HttpPost]
        public Task<IActionResult> Post(MatingRulesCommandsDto.V1.CreateMatingRules request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateMatingRules")]
        [HttpPut]
        public Task<IActionResult> Put(MatingRulesCommandsDto.V1.UpdateMatingRules request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteMatingRules")]
        [HttpPut]
        public Task<IActionResult> Put(MatingRulesCommandsDto.V1.DeleteMatingRules request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}