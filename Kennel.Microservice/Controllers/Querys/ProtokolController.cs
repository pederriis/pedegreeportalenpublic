using Kennel.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Controllers.Querys
{
    [Route("/Protokol")]
    public class ProtokolController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<ProtokolController>();
        private readonly ProtokolQuerys _protokolQuerys;

        public ProtokolController(ProtokolQuerys protokolQuerys)
        {
            _protokolQuerys = protokolQuerys;
        }

        [Route("/GetAllProtokols")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _protokolQuerys.GetAllProtokols();

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
