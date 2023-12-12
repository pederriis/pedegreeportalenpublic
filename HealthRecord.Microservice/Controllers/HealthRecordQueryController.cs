using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthRecord.Infrastructure.HealthRecordQuery;
using Microsoft.AspNetCore.Mvc;

using Serilog;

namespace HealthRecord.Microservice.Controllers
{[Route("/HealthRecord")]
    public class HealthRecordQueryController : Controller

    {

        private static ILogger _log = Log.ForContext<HealthRecordQueryController>();
        private readonly HealthRecordQueries _queries;

        public HealthRecordQueryController(HealthRecordQueries queries)
        {
            _queries = queries;
        }
        [Route("/GetAllHealthRecords")]
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

        [Route("/GetSingleHealthRecord")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid healthRecordId)
        {
            try
            {
                var model = await _queries.GetSingleHealRecordDetails(healthRecordId);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }


        [Route("/GetSingleHealRecordDetailsFromAnimalId")]
        [HttpGet]
        public async Task<IActionResult> GetSingleHealRecordDetailsFromAnimalId(Guid animalId)
        {
            try
            {
                var model = await _queries.GetSingleHealRecordDetailsFromAnimalId(animalId);
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