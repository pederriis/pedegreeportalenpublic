using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using HealthRecord.Infrastructure.HealthCertificateQuery;

namespace HealthRecord.Microservice.Controllers
{
    [Route("/HealthCertificate")]
    public class HealthCertificateQueryController : Controller

    {

        private static ILogger _log = Log.ForContext<DiseaseQueryController>();
        private readonly HealthCertificateQueries _queries;

        public HealthCertificateQueryController(HealthCertificateQueries queries)
        {
            _queries = queries;
        }
        [Route("/GetAlHealthCertificates")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _queries.GetAllHealRecordDetails();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [Route("/GetSingleHealthCertificate")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid HealthCertificateID)
        {
            try
            {
                var model = await _queries.GetSingleHealRecordDetails(HealthCertificateID);
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