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
    [Route("/ContractUserinformation")]
    public class ContractUserinformationCommandController : Controller

    {

        private readonly ContractUserinformationApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ContractUserinformationCommandController>();

        public ContractUserinformationCommandController(ContractUserinformationApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateContractUserinformation")]
        [HttpPost]
        public Task<IActionResult> Post(ContractUserinformationCommandsDto.V1.CreateContractUserinformation request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteDog")]
        [HttpPut]
        public Task<IActionResult> Put(ContractUserinformationCommandsDto.V1.DeleteContractUserinformation request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}