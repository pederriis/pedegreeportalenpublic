using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatingCalculator.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MatingCalculator.Microservice.Controllers
{
    
        [Route("/Userinformation")]
        public class UserinformationQueryController : Controller

        {

            private static ILogger _log = Log.ForContext<UserinformationQueryController>();
            private readonly UserinformationQueries _queries;

            public UserinformationQueryController(UserinformationQueries queries)
            {
                _queries = queries;
            }
            [Route("/GetAllUserinformations")]
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                try
                {
                    var model = await _queries.GetAllUserinformationDetails();
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