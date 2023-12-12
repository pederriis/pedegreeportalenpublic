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
    [Route("/Protokol")]
    public class ProtokolController : Controller
    {
        private readonly ProtokolApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ProtokolController>();

        public ProtokolController(ProtokolApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateProtokol")]
        [HttpPost]
        public Task<IActionResult> Post(ProtokolCommandsDto.V1.CreateProtokol request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        //[Route("UpdateProtokol")]
        //[HttpPut]
        //public Task<IActionResult> Put(ProtokolCommandsDto.V1.UpdateProtokol request)
        //    => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteProtokol")]
        [HttpPut]
        public Task<IActionResult> Put(ProtokolCommandsDto.V1.DeleteProtokol request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
