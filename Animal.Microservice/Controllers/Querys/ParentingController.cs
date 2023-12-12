using Animal.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Animal.Infrastructure.QueryModels;

namespace Animal.Microservice.Controllers.Querys
{
    [Route("/Parentings")]
    public class ParentingController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<ParentingController>();
        private readonly ParentingQuerys _querys;

        public ParentingController(ParentingQuerys querys)
        {
            _querys = querys;
        }

        [Route("/GetAllParentings")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _querys.GetAllParentings();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }


        [HttpGet]
        [Route("GetAllParentingsByAnimalId")]
        public async Task<IActionResult> Get(ParentingQueryModel.GetAnimalPedegreeByAnimalId request)
        {
            try
            {
                var model = await _querys.GetAllParentingsByAnimalId(request);
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
