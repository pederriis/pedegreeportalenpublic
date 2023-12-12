using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Querys;
using PedigreePortalen.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.AnimalMapper;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.ParentingMapper;

namespace PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper
{
    public static class LitterMapper
    {
        public class LitterCreateMapper
        {
            public static LitterViewModel.CreateLitter Map(LitterCommandsDto.V1.CreateLitter dto)
            {
                if (dto == null)
                { return null; }
                return new LitterViewModel.CreateLitter
                {
                    LitterId = dto.LitterId,
                    BreedById = dto.BreedById,
                    LitterName = dto.LitterName,
                    LitterBirthDate = dto.LitterBirthDate,
                    MatingDate = dto.MatingDate
                };
            }

            public static IEnumerable<LitterViewModel.CreateLitter> Map(IEnumerable<LitterCommandsDto.V1.CreateLitter> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<LitterCommandsDto.V1.CreateLitter> Map(IEnumerable<LitterViewModel.CreateLitter> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static LitterCommandsDto.V1.CreateLitter Map(LitterViewModel.CreateLitter model)
            {
                if (model == null)
                { return null; }
                return new LitterCommandsDto.V1.CreateLitter
                {
                    LitterId = model.LitterId,
                    BreedById = model.BreedById,
                    LitterName = model.LitterName,
                    LitterBirthDate = model.LitterBirthDate,
                    MatingDate = model.MatingDate
                };
            }
        }

        public class LitterDetailsMapper
        {
            public static LitterViewModel.LitterDetails Map(LitterQuerysDto.LitterDetails dto)
            {
                if (dto == null)
                { return null; }
                return new LitterViewModel.LitterDetails
                {
                    LitterId = dto.LitterId,
                    BreedById = dto.BreedById,
                    LitterName = dto.LitterName,
                    LitterBirthDate = dto.LitterBirthDate,
                    MatingDate = dto.MatingDate,
                    IsDeleted = dto.IsDeleted,
                    //Parentings = ParentingDetailsMapper.Map(dto.Parentings).ToList()
                };
            }

            public static IEnumerable<LitterViewModel.LitterDetails> Map(IEnumerable<LitterQuerysDto.LitterDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<LitterQuerysDto.LitterDetails> Map(IEnumerable<LitterViewModel.LitterDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static LitterQuerysDto.LitterDetails Map(LitterViewModel.LitterDetails model)
            {
                if (model == null)
                { return null; }
                return new LitterQuerysDto.LitterDetails
                {
                    LitterId = model.LitterId,
                    BreedById = model.BreedById,
                    LitterName = model.LitterName,
                    LitterBirthDate = model.LitterBirthDate,
                    MatingDate = model.MatingDate,
                    IsDeleted = model.IsDeleted,
                    //Parentings = ParentingDetailsMapper.Map(model.Parentings).ToList()
                };
            }
        }

        public class LitterAnimalDetailsMapper
        {
            public static LitterViewModel.LitterDetails Map(LitterQuerysDto.LitterDetails dto)
            {
                if (dto == null)
                { return null; }
                return new LitterViewModel.LitterDetails
                {
                    LitterId = dto.LitterId,
                    BreedById = dto.BreedById,
                    LitterName = dto.LitterName,
                    LitterBirthDate = dto.LitterBirthDate,
                    MatingDate = dto.MatingDate,
                    IsDeleted = dto.IsDeleted,
                    Animals = AnimalDetailsMapper.Map(dto.Animals).ToList()
                };
            }

            public static IEnumerable<LitterViewModel.LitterDetails> Map(IEnumerable<LitterQuerysDto.LitterDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<LitterQuerysDto.LitterDetails> Map(IEnumerable<LitterViewModel.LitterDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static LitterQuerysDto.LitterDetails Map(LitterViewModel.LitterDetails model)
            {
                if (model == null)
                { return null; }
                return new LitterQuerysDto.LitterDetails
                {
                    LitterId = model.LitterId,
                    BreedById = model.BreedById,
                    LitterName = model.LitterName,
                    LitterBirthDate = model.LitterBirthDate,
                    MatingDate = model.MatingDate,
                    IsDeleted = model.IsDeleted,
                    Animals = AnimalDetailsMapper.Map(model.Animals).ToList()
                };
            }
        }

        public class LitterParentingDetailsMapper
        {
            public static LitterViewModel.LitterDetails Map(LitterQuerysDto.LitterDetails dto)
            {
                if (dto == null)
                { return null; }
                return new LitterViewModel.LitterDetails
                {
                    LitterId = dto.LitterId,
                    BreedById = dto.BreedById,
                    LitterName = dto.LitterName,
                    LitterBirthDate = dto.LitterBirthDate,
                    MatingDate = dto.MatingDate,
                    IsDeleted = dto.IsDeleted,
                    Parentings = ParentingDetailsMapper.Map(dto.Parentings).ToList()
                };
            }

            public static IEnumerable<LitterViewModel.LitterDetails> Map(IEnumerable<LitterQuerysDto.LitterDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<LitterQuerysDto.LitterDetails> Map(IEnumerable<LitterViewModel.LitterDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static LitterQuerysDto.LitterDetails Map(LitterViewModel.LitterDetails model)
            {
                if (model == null)
                { return null; }
                return new LitterQuerysDto.LitterDetails
                {
                    LitterId = model.LitterId,
                    BreedById = model.BreedById,
                    LitterName = model.LitterName,
                    LitterBirthDate = model.LitterBirthDate,
                    MatingDate = model.MatingDate,
                    IsDeleted = model.IsDeleted,
                    Parentings = ParentingDetailsMapper.Map(model.Parentings).ToList()
                };
            }
        }

        public class LitterAnimalParentingDetailsMapper
        {
            public static LitterViewModel.LitterDetails Map(LitterQuerysDto.LitterDetails dto)
            {
                if (dto == null)
                { return null; }
                return new LitterViewModel.LitterDetails
                {
                    LitterId = dto.LitterId,
                    BreedById = dto.BreedById,
                    LitterName = dto.LitterName,
                    LitterBirthDate = dto.LitterBirthDate,
                    MatingDate = dto.MatingDate,
                    IsDeleted = dto.IsDeleted,
                    Parentings = ParentingDetailsMapper.Map(dto.Parentings).ToList(),
                    Animals = AnimalDetailsMapper.Map(dto.Animals).ToList()
                };
            }

            public static IEnumerable<LitterViewModel.LitterDetails> Map(IEnumerable<LitterQuerysDto.LitterDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<LitterQuerysDto.LitterDetails> Map(IEnumerable<LitterViewModel.LitterDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static LitterQuerysDto.LitterDetails Map(LitterViewModel.LitterDetails model)
            {
                if (model == null)
                { return null; }
                return new LitterQuerysDto.LitterDetails
                {
                    LitterId = model.LitterId,
                    BreedById = model.BreedById,
                    LitterName = model.LitterName,
                    LitterBirthDate = model.LitterBirthDate,
                    MatingDate = model.MatingDate,
                    IsDeleted = model.IsDeleted,
                    Parentings = ParentingDetailsMapper.Map(model.Parentings).ToList(),
                    Animals = AnimalDetailsMapper.Map(model.Animals).ToList()
                };
            }
        }
    }
}
