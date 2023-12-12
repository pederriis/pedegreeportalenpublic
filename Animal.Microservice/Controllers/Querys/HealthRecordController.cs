using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using Animal.Infrastructure.Query;

namespace Animal.Microservice.Controllers.Querys
{
    [Route("/Animal")]
    public class HealthRecordController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<HealthRecordController>();
        private readonly HealthRecordQuerys _healthRecordQuerys;

        public HealthRecordController(HealthRecordQuerys healthRecordQuerys)
        {
            _healthRecordQuerys = healthRecordQuerys;
        }

        [Route("/GetAllHealthRecords")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _healthRecordQuerys.GetAllHealthRecords();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }


        //[HttpGet]
        //[Route("id")]
        //public async Task<IActionResult> Get(QueryModels.GetLeaseOrderById request)
        //{
        //    try
        //    {
        //        var model = await _leaseOrderQueries.GetLeaseById(request);
        //        return new OkObjectResult(model);
        //    }
        //    catch (Exception e)
        //    {
        //        return Errorhandling(e);
        //    }
        //}

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
