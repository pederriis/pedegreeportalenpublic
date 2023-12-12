using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using Animal.Infrastructure.Query;
using Animal.Infrastructure.QueryModels;

namespace Animal.Microservice.Controllers.Querys
{
    [Route("/Race")]
    public class RaceController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<RaceController>();
        private readonly RaceQuerys _raceQuerys;

        public RaceController(RaceQuerys raceQuerys)
        {
            _raceQuerys = raceQuerys;
        }

        [Route("/GetAllRaces")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _raceQuerys.GetAllRaces();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("GetRaceById")]
        public async Task<IActionResult> GetRaceByRaceId(RaceQueryModel.GetRaceByRaceId request)
        {
            try
            {
                var model = await _raceQuerys.GetRaceById(request);
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
