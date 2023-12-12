using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using Animal.Infrastructure.Query;
using MassTransit;
using Animal.Infrastructure.QueryModels;

namespace Animal.Microservice.Controllers.Querys
{
    [Route("/Animal")]
    public class AnimalController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<AnimalController>();
        private readonly AnimalQuerys _animalQuerys;
      
        public AnimalController(AnimalQuerys animalQuerys)
        {
            _animalQuerys = animalQuerys;
        }

        [Route("/GetAllAnimals")]
        [HttpGet]
        public async Task<IActionResult> GetAllAnimals()
        {
            try
            {
                var model = await _animalQuerys.GetAllAnimals();

                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [Route("/GetAnimalsBySearchstring")]
        [HttpGet]
        public async Task<IActionResult> GetAnimalsbySearchstring(string searchstring)
        {
            try
            {
                var model = await _animalQuerys.GetAnimalsBySearchString(searchstring);

                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("id")]
        public async Task<IActionResult> GetAnimalByAnimalId(AnimalQueryModel.GetAnimalByAnimalId request)
        {
            try
            {
                var model = await _animalQuerys.GetAnimalById(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("GetSingleAnimalByAnimalId")]
        public async Task<IActionResult> GetSingleAnimalByAnimalId(AnimalQueryModel.GetAnimalByAnimalId request)
        {
            try
            {
                var model = await _animalQuerys.GetSingleAnimalByAnimalId(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("GetAnimalByOwnerId")]
        public async Task<IActionResult> GetAnimalByOwnerId(AnimalQueryModel.GetAllAnimalByOwnerId request)
        {
            try
            {
                var model = await _animalQuerys.GetAnimalByOwnerId(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("GetAllAnimalByOwnerId")]
        public async Task<IActionResult> GetAllAnimalByOwnerId(AnimalQueryModel.GetAllAnimalByOwnerId request)
        {
            try
            {
                var model = await _animalQuerys.GetAllAnimalByOwnerId(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("GetAllAnimalByLitterId")]
        public async Task<IActionResult> GetAllAnimalByLitterId(AnimalQueryModel.GetAllAnimalByLitterId request)
        {
            try
            {
                var model = await _animalQuerys.GetAllAnimalByLitterId(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("GetPedigreeTreeByAnimalId")]
        public async Task<IActionResult> GetPedigreeTreeByAnimalId(AnimalQueryModel.GetAnimalByAnimalId request)
        {
            try
            {
                var model = await _animalQuerys.GetPedigreeTreeByAnimalId(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("GetFullPedegreeTreeByAnimalId")]
        public async Task<IActionResult> GetFullPedegreeTreeByAnimalId(AnimalQueryModel.GetAnimalByAnimalId request)
        {
            try
            {
                var model = await _animalQuerys.GetFullPedegreeTreeByAnimalId(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [Route("/GetAllParentingAnimals")]
        [HttpGet]
        public async Task<IActionResult> GetAllParentingAnimals()
        {
            try
            {
                var model = await _animalQuerys.GetAllParentingAnimals();

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
