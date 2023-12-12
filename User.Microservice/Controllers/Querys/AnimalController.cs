using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Infrastructure.Query;


namespace User.Microservice.Controllers.Querys
{
    [Route("/User")]
    public class AnimalController : Controller
    {
        private static ILogger _log = Log.ForContext<AnimalController>();
        private readonly AnimalQueries _queries;

        public AnimalController(AnimalQueries queries)
        {
            _queries = queries;
        }

        [Route("/GetAllAnimals")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _queries.GetAllAnimals();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }
        [Route("/GetAllSingleAnimal")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid animalId)
        {
            try
            {
                var model = await _queries.GetSingleAnimal(animalId);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        //[HttpGet]
        //[Route("MemberId")]
        //public async Task<IActionResult> Get(UserQueryModels.GetOwnerByMemberId request)
        //{
        //    try
        //    {
        //        var model = await _queries.GetOwnerByMemberId(request);
        //        return new OkObjectResult(model);
        //    }
        //    catch (Exception e)
        //    {
        //        return Errorhandling(e);
        //    }
        //}

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
