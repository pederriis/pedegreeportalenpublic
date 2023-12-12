using Kennel.Application.ApplicationServices;
using Kennel.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System.Threading.Tasks;
using Serilog;

namespace Kennel.Microservice.Controllers.Commands
{
    [Route("/HealthRecord")]
    public class HealthRecordController : Controller
    {
        private readonly HealthRecordApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<HealthRecordController>();

        public HealthRecordController(HealthRecordApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateHealthRecord")]
        [HttpPost]
        public Task<IActionResult> Post(HealthRecordCommandsDto.V1.CreateHealthRecord request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        //[Route("UpdateHealthRecord")]
        //[HttpPut]
        //public Task<IActionResult> Put(HealthRecordCommandsDto.V1.upda request)
        //    => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteHealthRecord")]
        [HttpPut]
        public Task<IActionResult> Put(HealthRecordCommandsDto.V1.DeleteHealthRecord request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
