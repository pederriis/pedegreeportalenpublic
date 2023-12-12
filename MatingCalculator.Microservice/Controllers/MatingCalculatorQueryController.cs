using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatingCalculator.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MatingCalculator.Microservice.Controllers
{
    [Route("/MatingCalculator")]
    public class MatingCalculatorQueryController : Controller

    {

        private static ILogger _log = Log.ForContext<ContractQueryController>();
        private readonly MatingCalculationQueries _queries;

        public MatingCalculatorQueryController(MatingCalculationQueries queries)
        {
            _queries = queries;
        }
        [Route("/GetAllMatingCalculator")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _queries.GetAllMatingCalculationDetails();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [Route("/GetSingleMatingCalculator")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid matingcalculatorId)
        {
            try
            {
                var model = await _queries.GetSingleMatingCalculationDetails(matingcalculatorId);
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