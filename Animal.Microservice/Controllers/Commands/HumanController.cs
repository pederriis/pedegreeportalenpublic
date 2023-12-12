using Animal.Application.ApplicationServices;
using Animal.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using Serilog;
using System.Threading.Tasks;

namespace Animal.Microservice.Controllers.Commands
{
    [Route("/Human")]
    public class HumanController : Controller
    {
        private readonly HumanApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<HumanController>();

        public HumanController(HumanApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateHuman")]
        [HttpPost]
        public Task<IActionResult> Post(HumanCommandsDto.V1.CreateHuman request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        //[Route("UpdateHealthRecord")]
        //[HttpPut]
        //public Task<IActionResult> Put(HealthRecordCommandsDto.V1.UpdateHealthRecord request)
        //    => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteHuman")]
        [HttpPut]
        public Task<IActionResult> Put(HumanCommandsDto.V1.DeleteHuman request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
