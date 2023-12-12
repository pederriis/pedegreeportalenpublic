using Kennel.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Kennel.Microservice.Controllers.Querys
{
    [Route("/Vaccination")]
    public class VaccinationController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<VaccinationController>();
        private readonly VaccinationQuerys _querys;

        public VaccinationController(VaccinationQuerys querys)
        {
            _querys = querys;
        }

        [Route("/GetAllVaccinations")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _querys.GetAllVaccinations();

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
