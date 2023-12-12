using System;
using System.Collections.Generic;
using System.Linq;
using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries;
using PedigreePortalen.UI.Models;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Mapper.MatingCalculatorMicroServiceMapper
{
    public class MatingCalculationMapper
    {
        public class MatingCalculationDetailsMapper
        {
            public static MatingCalculatorViewModel.MatingCalculatorDetails Map(MatingCalculationQueriesDto.MatingCalculationDetails dto)
            {
                if (dto == null)
                { return null; }
                return new MatingCalculatorViewModel.MatingCalculatorDetails
                {
                    MatingCalculationid = dto.MatingCalculationId,
                    InbreedingPercent = dto.InbreedingPercent,
                    IsLegal = dto.IsLegal,
                    ExpectedChildren = dto.ExpectedChildren,
                    LitterAmount = dto.LitterAmount,
                    IsDeleted = dto.IsDeleted

                };
            }

            public static IEnumerable<MatingCalculatorViewModel.MatingCalculatorDetails> Map(IEnumerable<MatingCalculationQueriesDto.MatingCalculationDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<MatingCalculationQueriesDto.MatingCalculationDetails> Map(IEnumerable<MatingCalculatorViewModel.MatingCalculatorDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static MatingCalculationQueriesDto.MatingCalculationDetails Map(MatingCalculatorViewModel.MatingCalculatorDetails model)
            {
                if (model == null)
                { return null; }
                return new MatingCalculationQueriesDto.MatingCalculationDetails
                {
                    MatingCalculationId = model.MatingCalculationid,
                    InbreedingPercent = model.InbreedingPercent,
                    IsLegal = model.IsLegal,
                    ExpectedChildren = model.ExpectedChildren,
                    LitterAmount = model.LitterAmount,
                    IsDeleted = model.IsDeleted
                };
            }
        }

        public class MatingCalculationCreateMapper
        {
            public static MatingCalculatorViewModel.MatingCalculatorDetails Map(MatingCalculationQueriesDto.MatingCalculationDetails dto)
            {
                if (dto == null)
                { return null; }
                return new MatingCalculatorViewModel.MatingCalculatorDetails
                {
                    MatingCalculationid = dto.MatingCalculationId,
                    InbreedingPercent = dto.InbreedingPercent,
                    IsLegal = dto.IsLegal,
                    ExpectedChildren = dto.ExpectedChildren,
                    LitterAmount = dto.LitterAmount,
                    IsDeleted = dto.IsDeleted

                };
            }

            public static IEnumerable<MatingCalculatorViewModel.MatingCalculatorDetails> Map(IEnumerable<MatingCalculationQueriesDto.MatingCalculationDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<MatingCalculationQueriesDto.MatingCalculationDetails> Map(IEnumerable<MatingCalculatorViewModel.MatingCalculatorDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static MatingCalculationQueriesDto.MatingCalculationDetails Map(MatingCalculatorViewModel.MatingCalculatorDetails model)
            {
                if (model == null)
                { return null; }
                return new MatingCalculationQueriesDto.MatingCalculationDetails
                {
                    MatingCalculationId = model.MatingCalculationid,
                    InbreedingPercent = model.InbreedingPercent,
                    IsLegal = model.IsLegal,
                    ExpectedChildren = model.ExpectedChildren,
                    LitterAmount = model.LitterAmount,
                    IsDeleted = model.IsDeleted
                };
            }
        }
    }
}
