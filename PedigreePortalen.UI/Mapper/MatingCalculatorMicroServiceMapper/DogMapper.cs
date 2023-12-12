using PedigreePortalen.Shared.MatingCalculatorMicroserviceDto.Queries;
using PedigreePortalen.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedigreePortalen.UI.Mapper.MatingCalculatorMicroServiceMapper
{
    public class DogMapper
    {

        public class DogDetailsMapper
        {
            public static MatingCalculatorDogViewModel.DetailsMatingCalculatorDog Map(DogQuriesDto.DogDetails dto)
            {
                if (dto == null)
                { return null; }
                return new MatingCalculatorDogViewModel.DetailsMatingCalculatorDog
                {
                    DogId = dto.DogId,
                    Name = dto.Name,
                    Gender = dto.Gender,

                };
            }

            public static IEnumerable<MatingCalculatorDogViewModel.DetailsMatingCalculatorDog> Map(IEnumerable<DogQuriesDto.DogDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<DogQuriesDto.DogDetails> Map(IEnumerable<MatingCalculatorDogViewModel.DetailsMatingCalculatorDog> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static DogQuriesDto.DogDetails Map(MatingCalculatorDogViewModel.DetailsMatingCalculatorDog model)
            {
                if (model == null)
                { return null; }
                return new DogQuriesDto.DogDetails
                {
                    DogId = model.DogId,
                    Name = model.Name,
                    Gender = model.Gender,
                };
            }
        }
    }
}
