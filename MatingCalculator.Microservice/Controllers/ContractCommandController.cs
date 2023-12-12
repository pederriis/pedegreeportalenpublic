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
    [Route("/Contract")]
    public class ContractCommandController : Controller

    {

        private readonly ContractApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ContractCommandController>();

        public ContractCommandController(ContractApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateContract")]
        [HttpPost]
        public Task<IActionResult> Post(ContractCommandsDto.V1.CreateContract request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateContract")]
        [HttpPut]
        public Task<IActionResult> Put(ContractCommandsDto.V1.UpdateContract request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteContract")]
        [HttpPut]
        public Task<IActionResult> Put(ContractCommandsDto.V1.DeleteContract request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}