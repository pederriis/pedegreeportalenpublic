using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using Animal.Infrastructure.Query;
using Animal.Infrastructure.QueryModels;

namespace Animal.Microservice.Controllers.Querys
{
    [Route("/SubRace")]
    public class SubRaceController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<SubRaceController>();
        private readonly SubRaceQuerys _subRaceQuerys;

        public SubRaceController(SubRaceQuerys subRaceQuerys)
        {
            _subRaceQuerys = subRaceQuerys;
        }

        [Route("/GetAllSubRaces")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _subRaceQuerys.GetAllSubRaces();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }


        [HttpGet]
        [Route("GetAllSubRaceById")]
        public async Task<IActionResult> Get(SubRaceQueryModel.GetAllSubRaceByRaceId request)
        {
            try
            {
                var model = await _subRaceQuerys.GetAllSubRacesByRaceId(request);
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
