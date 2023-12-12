using Animal.Application.ApplicationServices;
using Animal.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using Serilog;
using System.Threading.Tasks;

namespace Animal.Microservice.Controllers.Commands
{
    [Route("/ExhibitionTitle")]
    public class ExhibitionTitleController : Controller
    {
        private readonly ExhibitionTitleApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ExhibitionTitleController>();

        public ExhibitionTitleController(ExhibitionTitleApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateExhibitionTitle")]
        [HttpPost]
        public Task<IActionResult> Post(ExhibitionTitleCommandsDto.V1.CreateExhibitionTitle request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateExhibitionTitle")]
        [HttpPut]
        public Task<IActionResult> Put(ExhibitionTitleCommandsDto.V1.UpdateExhibitionTitle request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteExhibitionTitle")]
        [HttpPut]
        public Task<IActionResult> Put(ExhibitionTitleCommandsDto.V1.DeleteExhibitionTitle request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
