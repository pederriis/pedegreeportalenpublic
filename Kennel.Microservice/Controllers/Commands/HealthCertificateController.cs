using Kennel.Application.ApplicationServices;
using Kennel.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.KennelMicroserviceDto.Commands;
using System.Threading.Tasks;
using Serilog;

namespace Kennel.Microservice.Controllers.Commands
{
    [Route("/HealthCertificate")]
    public class HealthCertificateController : Controller
    {
        private readonly HealthCertificateApplicationService _applicationService;
        private static readonly ILogger Log = Serilog.Log.ForContext<HealthCertificateController>();

        public HealthCertificateController(HealthCertificateApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [Route("CreateHealthCertificate")]
        [HttpPost]
        public Task<IActionResult> Post(HealthCertificateCommandsDto.V1.CreateHealthCertificate request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateHealthCertificate")]
        [HttpPut]
        public Task<IActionResult> Put(HealthCertificateCommandsDto.V1.UpdateHealthCertificate request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteHealthCertificate")]
        [HttpPut]
        public Task<IActionResult> Put(HealthCertificateCommandsDto.V1.DeleteHealthCertificate request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}
