using Kennel.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Controllers.Querys
{
    [Route("/Litter")]
    public class LitterController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<LitterController>();
        private readonly LitterQuerys _litterQuerys;

        public LitterController(LitterQuerys litterQuerys)
        {
            _litterQuerys = litterQuerys;
        }

        [Route("/GetAllLitters")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _litterQuerys.GetAllLitters();

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
