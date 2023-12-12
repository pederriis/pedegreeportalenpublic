using Kennel.Application.ApplicationServices;
using Kennel.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System.Threading.Tasks;
using Serilog;

namespace Kennel.Microservice.Controllers.Commands
{
    [Route("/Parrent")]
    public class ParrentController : Controller
    {
        private readonly ParrentApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<ParrentController>();

        public ParrentController(ParrentApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateParrent")]
        [HttpPost]
        public Task<IActionResult> Post(ParrentCommandsDto.V1.CreateParrent request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteParrent")]
        [HttpPut]
        public Task<IActionResult> Put(ParrentCommandsDto.V1.DeleteParrent request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("AddParrentToLitter")]
        [HttpPut]
        public Task<IActionResult> AddParrentToLitter(ParrentCommandsDto.V1.AddParrentToLitter request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
