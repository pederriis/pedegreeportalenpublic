using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatingCalculator.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MatingCalculator.Microservice.Controllers
{
   
        [Route("/HealthRecord")]
        public class HealthRecordQueryController : Controller

        {

            private static ILogger _log = Log.ForContext<ContractQueryController>();
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
                    var model = await _queries.GetAllHealthRecords();
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
