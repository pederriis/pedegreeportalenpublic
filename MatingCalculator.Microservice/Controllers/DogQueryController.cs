using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using MatingCalculator.Infrastructure.Query;

namespace MatingCalculator.Microservice.Controllers
{
    
        [Route("/Dog")]
        public class DogQueryController : Controller

        {

            private static ILogger _log = Log.ForContext<DogQueryController>();
            private readonly DogQueries _queries;

            public DogQueryController(DogQueries queries)
            {
                _queries = queries;
            }

            [Route("/GetAllDogDetailsForMatingCalculation")]
            [HttpGet]
            public async Task<IActionResult> Get()
            {
                try
                {
                    var model = await _queries.GetAllDogDetailsForMatingCalculation();
                    return new OkObjectResult(model);
                }
                catch (Exception e)
                {
                    return Errorhandling(e);
                }
            }

        [Route("/GetSingleDog")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid dogID)
        {
            try
            {
                var model = await _queries.GetSingleDogDetails(dogID);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [Route("/GetDogDetailsFromOwnerId")]
        [HttpGet]
        public async Task<IActionResult> GetDogDetailsFromOwnerId(Guid ownerid)
        {
            try
            {
                var model = await _queries.GetDogDetailsFromOwnerId(ownerid);
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
