using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthRecord.Infrastructure.AnimalQuery;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HealthRecord.Microservice.Controllers
{
    [Route("/Animal")]
    public class AnimalQueryController : Controller

    {

        private static ILogger _log = Log.ForContext<AnimalQueryController>();
        private readonly AnimalQueries _queries;

        public AnimalQueryController(AnimalQueries queries)
        {
            _queries = queries;
        }
        [Route("/GetAllAnimals")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _queries.GetAllAnimalDetails();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [Route("/GetSingleAnimal")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid animalID)
        {
            try
            {
                var model = await _queries.GetSingleAnimalDetails(animalID);
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