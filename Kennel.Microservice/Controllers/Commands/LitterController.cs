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
    [Route("/Litter")]
    public class LitterController : Controller
    {
        private readonly LitterApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<LitterController>();

        public LitterController(LitterApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateLitter")]
        [HttpPost]
        public Task<IActionResult> Post(LitterCommandsDto.V1.CreateLitter request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateLitter")]
        [HttpPut]
        public Task<IActionResult> Put(LitterCommandsDto.V1.UpdateLitter request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteLitter")]
        [HttpPut]
        public Task<IActionResult> Put(LitterCommandsDto.V1.DeleteLitter request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
