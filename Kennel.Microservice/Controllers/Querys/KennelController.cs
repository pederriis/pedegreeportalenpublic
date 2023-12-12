using Kennel.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Controllers.Querys
{
    [Route("/Kennel")]
    public class KennelController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<KennelController>();
        private readonly KennelQuerys _kennelQuerys;

        public KennelController(KennelQuerys kennelQuerys)
        {
            _kennelQuerys = kennelQuerys;
        }

        [Route("/GetAllKennels")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _kennelQuerys.GetAllKennels();

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
