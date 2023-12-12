using Kennel.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Kennel.Microservice.Controllers.Querys
{
    [Route("/HealthCertificate")]
    public class HealthCertificateController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<HealthCertificateController>();
        private readonly HealthCertificateQuerys _querys;

        public HealthCertificateController(HealthCertificateQuerys querys)
        {
            _querys = querys;
        }

        [Route("/GetAllHealthCertificates")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _querys.GetAllHealthCertificates();

                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        private IActionResult Errorhandling(Exception e)
        {
            _log.Error(e, "Error handling the query");
            return new BadRequestObjectResult(new
            {
                error = e.Message,
                stackTrace = e.StackTrace
            });
        }
    }
}
