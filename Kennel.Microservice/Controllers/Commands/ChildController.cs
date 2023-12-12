using Kennel.Application.ApplicationServices;
using Kennel.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Controllers.Commands
{
    [Route("/Child")]
    public class ChildController : Controller
    {
        private readonly ChildApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ChildController>();

        public ChildController(ChildApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateChild")]
        [HttpPost]
        public Task<IActionResult> Post(ChildCommandsDto.V1.CreateChild request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteChild")]
        [HttpPut]
        public Task<IActionResult> Put(ChildCommandsDto.V1.DeleteChild request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("AddChildToLitter")]
        [HttpPut]
        public Task<IActionResult> AddParrentToLitter(ChildCommandsDto.V1.AddChildToLitter request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
