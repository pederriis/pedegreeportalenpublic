using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatingCalculator.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MatingCalculator.Microservice.Controllers
{

    [Route("/CalculatedDisease")]
    public class CalculatedDiseaseQueryController : Controller

    {

        private static ILogger _log = Log.ForContext<CalculatedDiseaseQueryController>();
        private readonly CalculatedDiseaseQueries _queries;

        public CalculatedDiseaseQueryController(CalculatedDiseaseQueries queries)
        {
            _queries = queries;
        }
        [Route("/GetAllCalculatedDiseases")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _queries.GetAllCalculatedDiseaseDetails();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [Route("/GetAllCalculatedDiseaseDetailsFromMatingCalculationId")]
        [HttpGet]
        public async Task<IActionResult> GetAllCalculatedDiseaseDetailsFromMatingCalculationId(Guid matingCalculationId)
        {
            try
            {
                var model = await _queries.GetAllCalculatedDiseaseDetailsFromMatingCalculationId(matingCalculationId);
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
