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
    [Route("/Kennel")]
    public class KennelController : Controller
    {
        private readonly KennelApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<KennelController>();

        public KennelController(KennelApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateKennel")]
        [HttpPost]
        public Task<IActionResult> Post(KennelCommandsDto.V1.CreateKennel request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateKennel")]
        [HttpPut]
        public Task<IActionResult> Put(KennelCommandsDto.V1.UpdateKennel request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteKennel")]
        [HttpPut]
        public Task<IActionResult> Put(KennelCommandsDto.V1.DeleteKennel request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
