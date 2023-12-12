using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatingCalculator.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MatingCalculator.Microservice.Controllers
{

        [Route("/ContractUserinformation")]
        public class ContractUserinformationQueryController : Controller

        {

            private static ILogger _log = Log.ForContext<ContractUserinformationQueryController>();
            private readonly ContractUserinformationQueries _queries;

            public ContractUserinformationQueryController(ContractUserinformationQueries queries)
            {
                _queries = queries;
            }
            [Route("/GetAllContractUserinformation")]
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                try
                {
                    var model = await _queries.GetAllContractUserinformationDetails();
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
