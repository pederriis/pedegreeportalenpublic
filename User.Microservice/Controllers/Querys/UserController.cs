using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using User.Infrastructure.Query;
using User.Infrastructure.QueryModels;

namespace User.Microservice.Controllers.Querys
{
    [Route("/User")]
    public class UserController : Controller
    {
        private static ILogger _log = Log.ForContext<UserController>();
        private readonly UserQueries _queries;

        public UserController(UserQueries queries)
        {
            _queries = queries;
        }

        [Route("/GetAllUsers")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var model = await _queries.GetAllUsers();
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("GetUserByUserId")]
        public async Task<IActionResult> GetUserByUserId(UserQueryModels.GetUserByUserId request)
        {
            try
            {
                var model = await _queries.GetUserByUserId(request);
                return new OkObjectResult(model);
            }
            catch (Exception e)
            {
                return Errorhandling(e);
            }
        }

        [HttpGet]
        [Route("GetUserByLoginUserId")]
        public async Task<IActionResult> GetUserByLoginUserId(UserQueryModels.GetUserByLoginUserId request)
        {
            try
            {
                var model = await _queries.GetUserByLoginUserId(request);
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
