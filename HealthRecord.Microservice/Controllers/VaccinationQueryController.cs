using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthRecord.Infrastructure.VaccinationQuery;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace HealthRecord.Microservice.Controllers
{
    [Route("/Vaccination")]
    
    public class VaccinationQueryController : Controller

    {

        private static ILogger _log = Log.ForContext<VaccinationQueryController>();
        private readonly VaccinationQueries _queries;

        public VaccinationQueryController(VaccinationQueries queries)
        {
            _queries = queries;
        }
        [Route("/GetAllVaccinations")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _queries.GetAllVaccinationDetails();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [Route("/GetSingleVaccination")]
        [HttpGet]
        public async Task<IActionResult> Get(Guid vaccinationId)
        {
            try
            {
                var model = await _queries.GetSingleVaccinationDetails(vaccinationId);
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