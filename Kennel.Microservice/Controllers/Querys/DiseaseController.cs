using Kennel.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Kennel.Microservice.Controllers.Querys
{
    [Route("/Disease")]
    public class DiseaseController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<DiseaseController>();
        private readonly DiseaseQuerys _querys;

        public DiseaseController(DiseaseQuerys querys)
        {
            _querys = querys;
        }

        [Route("/GetAllDiseases")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _querys.GetAllDiseases();

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
