using MatingCalculator.Application.ApplicationServices;
using MatingCalculator.Infrastructure.Query;
using MatingCalculator.Infrastructure.Shared;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Commands;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatingCalculator.Microservice.Calculations
{
    public class MatingCalculator
    {
        private readonly DogQueries _Dogqueries;
       
        public List<CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease> CalculatedDiseases = new List<CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease>();

        public MatingCalculator(DogQueries Dogqueries)
        {
            _Dogqueries = Dogqueries;
        }

        public async Task<MatingCalculationCommandDto.V1.CreateMatingCalculation> CalculateMating (MatingCalculationCommandDto.V1.MateTwoDogs twoDogs)
        {
            MatingCalculationCommandDto.V1.CreateMatingCalculation matingCalculation = new MatingCalculationCommandDto.V1.CreateMatingCalculation();

            await GetFamilyTreeDiseases(twoDogs.FatherDogId, twoDogs.MatingCalculationId);
            await GetFamilyTreeDiseases(twoDogs.MotherDogId, twoDogs.MatingCalculationId);

            matingCalculation.MatingCalculationId = twoDogs.MatingCalculationId;
            matingCalculation.MatingRulesId = Guid.Parse("72acfacc-7d88-4a1a-b525-48b17ef7db87");
            matingCalculation.ExpectedChildren = 5;
            matingCalculation.InbreedingPercent = 4;
            matingCalculation.IsLegal = true;
            matingCalculation.LitterAmount = 3;
            matingCalculation.IsDeleted = false;
            matingCalculation.CalculatedDiseases = CalculatedDiseases;
            
            return matingCalculation; 
        }

        private async Task GetFamilyTreeDiseases(Guid dogId, Guid matingCalculationId)
        {
            var parentDog = await _Dogqueries.GetSingleDogDetails(dogId);

            if (parentDog.DiseaseDetails != null)
            {
                foreach (var disease in parentDog.DiseaseDetails)
                {
                    CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease calculatedDisease = new CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease
                    {
                        CalculatedDiseaseId = Guid.NewGuid(),
                        MatingCalculationId = matingCalculationId,
                        Name = disease.Name,
                        Probability = disease.Probability / 2
                    };
                    CalculatedDiseases.Add(calculatedDisease);
                }
            }

            if (parentDog.HomeLitter != null)
            {
                foreach (var p in parentDog.HomeLitter.ParentingDetails)
                {
                    if (parentDog.HomeLitter != null)
                    {
                        foreach (var d in p.DogDetail.DiseaseDetails.Where(x => x.IsHereditary == true))
                        {
                            CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease calculatedDisease = new CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease
                            {
                                CalculatedDiseaseId = Guid.NewGuid(),
                                MatingCalculationId = matingCalculationId,
                                Name = d.Name,
                                Probability = d.Probability / 4

                            };
                            CalculatedDiseases.Add(calculatedDisease);
                        }

                        var GrandParentDog = await _Dogqueries.GetSingleDogDetails(p.DogDetail.DogId);

                        if (GrandParentDog.HomeLitter != null)
                        {
                            foreach (var g in GrandParentDog.HomeLitter.ParentingDetails)
                            {
                                foreach (var d in g.DogDetail.DiseaseDetails.Where(x => x.IsHereditary == true))
                                {
                                    CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease calculatedDisease = new CalculatedDiseaseCommandsDto.V1.CreatedCalculatedDisease
                                    {
                                        CalculatedDiseaseId = Guid.NewGuid(),
                                        MatingCalculationId = matingCalculationId,
                                        Name = d.Name,
                                        Probability = d.Probability / 8
                                    };
                                    CalculatedDiseases.Add(calculatedDisease);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}