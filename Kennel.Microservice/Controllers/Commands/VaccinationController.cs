using Kennel.Application.ApplicationServices;
using Kennel.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System.Threading.Tasks;
using Serilog;

namespace Kennel.Microservice.Controllers.Commands
{
    [Route("/Vaccination")]
    public class VaccinationController : Controller
    {
        private readonly VaccinationApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<VaccinationController>();

        public VaccinationController(VaccinationApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateVaccination")]
        [HttpPost]
        public Task<IActionResult> Post(VaccinationCommandsDto.V1.CreateVaccination request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateVaccination")]
        [HttpPut]
        public Task<IActionResult> Put(VaccinationCommandsDto.V1.UpdateVaccination request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteVaccination")]
        [HttpPut]
        public Task<IActionResult> Put(VaccinationCommandsDto.V1.DeleteVaccination request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
