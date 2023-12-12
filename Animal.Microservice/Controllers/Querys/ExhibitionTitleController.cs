using Animal.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Animal.Microservice.Controllers.Querys
{
    [Route("/Animal")]
    public class ExhibitionTitleController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<ExhibitionTitleController>();
        private readonly ExhibitionTitleQuerys _exhibitionTitleQuerys;

        public ExhibitionTitleController(ExhibitionTitleQuerys exhibitionTitleQuerys)
        {
            _exhibitionTitleQuerys = exhibitionTitleQuerys;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _exhibitionTitleQuerys.GetAllExhibitionTitles();
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
