using Kennel.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Kennel.Microservice.Controllers.Querys
{
    [Route("/HealthRecord")]
    public class HealthRecordController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<HealthRecordController>();
        private readonly HealthRecordQuerys _querys;

        public HealthRecordController(HealthRecordQuerys querys)
        {
            _querys = querys;
        }

        [Route("/GetAllHealthRecords")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _querys.GetAllHealthRecords();

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
