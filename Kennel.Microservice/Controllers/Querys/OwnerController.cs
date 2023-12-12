using Kennel.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kennel.Microservice.Controllers.Querys
{
    [Route("/Owner")]
    public class OwnerController : Controller
    {
        private readonly static ILogger _log = Log.ForContext<OwnerController>();
        private readonly OwnerQuerys _ownerQuerys;

        public OwnerController(OwnerQuerys ownerQuerys)
        {
            _ownerQuerys = ownerQuerys;
        }

        [Route("/GetAllOwners")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _ownerQuerys.GetAllOwners();

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
