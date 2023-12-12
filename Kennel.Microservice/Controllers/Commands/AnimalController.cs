using Kennel.Application.ApplicationServices;
using Kennel.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System.Threading.Tasks;
using Serilog;

namespace Kennel.Microservice.Controllers.Commands
{
    [Route("/Animal")]
    public class AnimalController : Controller
    {
        private readonly AnimalApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<AnimalController>();
        
        public AnimalController(AnimalApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateAnimal")]
        [HttpPost]
        public Task<IActionResult> Post(AnimalCommandsDto.V1.CreateAnimal request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateAnimal")]
        [HttpPut]
        public Task<IActionResult> Put(AnimalCommandsDto.V1.UpdateAnimal request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteAnimal")]
        [HttpPut]
        public Task<IActionResult> Put(AnimalCommandsDto.V1.DeleteAnimal request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("AddAnimalToProtokol")]
        [HttpPut]
        public Task<IActionResult> Put(AnimalCommandsDto.V1.AddAnimalToProtokol request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
