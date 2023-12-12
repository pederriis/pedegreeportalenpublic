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
    [Route("/Owner")]
    public class OwnerController : Controller
    {
        private readonly OwnerApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<OwnerController>();

        public OwnerController(OwnerApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateOwner")]
        [HttpPost]
        public Task<IActionResult> Post(OwnerCommandsDto.V1.CreateOwner request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateOwner")]
        [HttpPut]
        public Task<IActionResult> Put(OwnerCommandsDto.V1.UpdateOwner request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteOwner")]
        [HttpPut]
        public Task<IActionResult> Put(OwnerCommandsDto.V1.DeleteOwner request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
