using Kennel.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Kennel.Microservice.Controllers.Querys
{
    [Route("/Animal")]
    public class AnimalController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<AnimalController>();
        private readonly AnimalQuerys _querys;

        public AnimalController(AnimalQuerys querys)
        {
            _querys = querys;
        }

        [Route("/GetAllAnimals")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _querys.GetAllAnimals();

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
