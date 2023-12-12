using Animal.Application.ApplicationServices;
using Animal.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using Serilog;
using System.Threading.Tasks;

namespace Animal.Microservice.Controllers.Commands
{
    [Route("/SubRace")]
    public class SubRaceController : Controller
    {
        private readonly SubRaceApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<SubRaceController>();

        public SubRaceController(SubRaceApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateSubRace")]
        [HttpPost]
        public Task<IActionResult> Post(SubRaceCommandsDto.V1.CreateSubRace request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateSubRace")]
        [HttpPut]
        public Task<IActionResult> Put(SubRaceCommandsDto.V1.UpdateSubRace request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteSubRace")]
        [HttpPut]
        public Task<IActionResult> Put(SubRaceCommandsDto.V1.DeleteSubRace request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
