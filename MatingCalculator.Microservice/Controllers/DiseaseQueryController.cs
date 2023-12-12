using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatingCalculator.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MatingCalculator.Microservice.Controllers
{

    [Route("/Disease")]
    public class DiseaseQueryController : Controller

    {

        private static ILogger _log = Log.ForContext<DiseaseQueryController>();
        private readonly DiseaseQueries _queries;

        public DiseaseQueryController(DiseaseQueries queries)
        {
            _queries = queries;
        }
        [Route("/GetAllDiseases")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _queries.GetAllDiseaseDetails();
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
