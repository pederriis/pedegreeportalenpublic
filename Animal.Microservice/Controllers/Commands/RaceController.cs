using Animal.Application.ApplicationServices;
using Animal.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using Serilog;
using System.Threading.Tasks;

namespace Animal.Microservice.Controllers.Commands
{
    [Route("/Race")]
    public class RaceController : Controller
    {
        private readonly RaceApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<RaceController>();

        public RaceController(RaceApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateRace")]
        [HttpPost]
        public Task<IActionResult> Post(RaceCommandsDto.V1.CreateRace request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateRace")]
        [HttpPut]
        public Task<IActionResult> Put(RaceCommandsDto.V1.UpdateRace request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteRace")]
        [HttpPut]
        public Task<IActionResult> Put(RaceCommandsDto.V1.DeleteRace request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
