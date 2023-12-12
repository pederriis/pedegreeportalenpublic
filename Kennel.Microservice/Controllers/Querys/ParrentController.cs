using Kennel.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Kennel.Microservice.Controllers.Querys
{
    [Route("/Parrent")]
    public class ParrentController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<ParrentController>();
        private readonly ParrentQuerys _querys;

        public ParrentController(ParrentQuerys querys)
        {
            _querys = querys;
        }

        [Route("/GetAllParrents")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _querys.GetAllParrents();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }


        //[HttpGet]
        //[Route("id")]
        //public async Task<IActionResult> Get(QueryModels.GetLeaseOrderById request)
        //{
        //    try
        //    {
        //        var model = await _leaseOrderQueries.GetLeaseById(request);
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
