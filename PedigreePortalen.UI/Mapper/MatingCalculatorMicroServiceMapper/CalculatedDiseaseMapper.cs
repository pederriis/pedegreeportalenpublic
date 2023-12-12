using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries;
using PedigreePortalen.UI.Models;

namespace PedigreePortalen.UI.Mapper.MatingCalculatorMicroServiceMapper
{
    public class CalculatedDiseaseMapper
    {

        public class CalculatedDiseaseDetialsMapper
        {
            public static CalculatedDiseaseViewModel.CalculatedDiseaseDetails Map(CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails dto)
            {
                if (dto == null)
                { return null; }
                return new CalculatedDiseaseViewModel.CalculatedDiseaseDetails
                {
                    CalculatedDiseaseId = dto.CalculatedDiseaseId,
                    MatingCalculationId=dto.MatingCalculationId,
                    Name = dto.Name,
                    Probabilaty = dto.Probability,
                    IsDeleted=dto.IsDeleted

                };
            }

            public static IEnumerable<CalculatedDiseaseViewModel.CalculatedDiseaseDetails> Map(IEnumerable<CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails> Map(IEnumerable<CalculatedDiseaseViewModel.CalculatedDiseaseDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails Map(CalculatedDiseaseViewModel.CalculatedDiseaseDetails model)
            {
                if (model == null)
                { return null; }
                return new CalculatedDiseaseQueriesDto.CalculatedDiseaseDetails
                {
                    CalculatedDiseaseId = model.CalculatedDiseaseId,
                    MatingCalculationId=model.MatingCalculationId,
                    Name = model.Name,
                    Probability=model.Probabilaty,
                    IsDeleted=model.IsDeleted
                    

                };
            }
        }
    }
}
