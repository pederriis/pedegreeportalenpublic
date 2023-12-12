using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.UserMicroserviceDto.Commands;
using Serilog;
using User.Application.ApplicationServices;
using User.Infrastructure.Shared;

namespace User.Microservice.Controllers.Commands
{
    [Route("/User")]
    public class AnimalController : Controller
    {
        private readonly AnimalApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<UserController>();

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
    }
}
