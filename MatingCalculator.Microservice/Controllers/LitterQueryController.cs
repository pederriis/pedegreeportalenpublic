using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatingCalculator.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace MatingCalculator.Microservice.Controllers
{
    [Route("/Litter")]
    public class LitterQueryController : Controller

    {

        private static ILogger _log = Log.ForContext<LitterQueryController>();
        private readonly LitterQueries _queries;

        public LitterQueryController(LitterQueries queries)
        {
            _queries = queries;
        }

        [Route("/GetAllLitters")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _queries.GetAllLitterDetails();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }


        [Route("/GetSingleLitter")]
        [HttpGet]
        public async Task<IActionResult> GetSingleLitterDetails(Guid litterId)
        {
            try
            {
                var model = await _queries.GetSingleLitterDetails(litterId);
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