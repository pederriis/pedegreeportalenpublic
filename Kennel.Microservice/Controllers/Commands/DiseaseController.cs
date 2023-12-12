using Kennel.Application.ApplicationServices;
using Kennel.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System.Threading.Tasks;
using Serilog;

namespace Kennel.Microservice.Controllers.Commands
{
    [Route("/Disease")]
    public class DiseaseController : Controller
    {
        private readonly DiseaseApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<DiseaseController>();

        public DiseaseController(DiseaseApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateDisease")]
        [HttpPost]
        public Task<IActionResult> Post(DiseaseCommandsDto.V1.CreateDisease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateDisease")]
        [HttpPut]
        public Task<IActionResult> Put(DiseaseCommandsDto.V1.UpdateDisease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteDisease")]
        [HttpPut]
        public Task<IActionResult> Put(DiseaseCommandsDto.V1.DeleteDisease request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
