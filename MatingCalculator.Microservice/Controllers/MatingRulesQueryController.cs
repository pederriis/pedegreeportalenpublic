using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatingCalculator.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MatingCalculator.Microservice.Controllers
{
    [Route("/MatingRules")]
    public class MatingRulesQueryController : Controller

    {

        private static ILogger _log = Log.ForContext<DiseaseQueryController>();
        private readonly MatingRulesQueries _queries;

        public MatingRulesQueryController(MatingRulesQueries queries)
        {
            _queries = queries;
        }
        [Route("/GetAllMatingRules")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _queries.GetAllMatingRulesDetails();
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