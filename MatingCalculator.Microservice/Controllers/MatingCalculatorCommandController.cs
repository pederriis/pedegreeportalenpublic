using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatingCalculator.Application.ApplicationServices;
using MatingCalculator.Infrastructure.Query;
using MatingCalculator.Infrastructure.Shared;
using Microsoft.AspNetCore.Mvc;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using Serilog;

namespace MatingCalculator.Microservice.Controllers
{
    [Route("/MatingCalculator")]
    public class MatingCalculatorCommandController : Controller

    {

        private readonly MatingCalculatorApplicationService _applicationService;
        private CalculatedDiseaseApplicationService _calculatedDiseaseApplicationService;

        private static readonly ILogger Log = Serilog.Log.ForContext<MatingCalculatorCommandController>();
        MatingCalculator.Microservice.Calculations.MatingCalculator matingCalculator;
        private DogQueries _dogQueries;

        public MatingCalculatorCommandController(MatingCalculatorApplicationService applicationService, DogQueries dogQueries, CalculatedDiseaseApplicationService calculatedDiseaseApplicationService)
        {
            _applicationService = applicationService;
            _dogQueries = dogQueries;
            _calculatedDiseaseApplicationService = calculatedDiseaseApplicationService;
            matingCalculator = new Calculations.MatingCalculator(_dogQueries);
        }

        [Route("MateTwoDogs")]
        [HttpPost]
        public async Task<IActionResult> Post(MatingCalculationCommandDto.V1.MateTwoDogs request)
        {

            MatingCalculationCommandDto.V1.CreateMatingCalculation matingCalculation = await matingCalculator.CalculateMating(request);

            var response=await RequestHandler.HandleCommand(matingCalculation, _applicationService.Handle, Log);
            

            if (matingCalculation.CalculatedDiseases.Count != 0)
            {
                foreach (var calculatedDisease in matingCalculation.CalculatedDiseases)
                {
                    await RequestHandler.HandleCommand(calculatedDisease, _calculatedDiseaseApplicationService.Handle, Log);
                }
            }
         

            return (ActionResult)response;

        }

        [Route("CreateMatingCalculation")]
        [HttpPost]
        public Task<IActionResult> Post(MatingCalculationCommandDto.V1.CreateMatingCalculation request)
              => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("UpdateMatingCalculation")]
        [HttpPut]
        public Task<IActionResult> Put(MatingCalculationCommandDto.V1.UpdateMatingCalculation request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);

        [Route("DeleteMatingCalculation")]
        [HttpPut]
        public Task<IActionResult> Put(MatingCalculationCommandDto.V1.DeleteMatingCalculation request)
            => RequestHandler.HandleCommand(request, _applicationService.Handle, Log);
    }
}