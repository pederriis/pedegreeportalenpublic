using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Querys;
using PedigreePortalen.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.AnimalMapper;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.LitterMapper;

namespace PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper
{
    public static class ParentingMapper
    {
        public class AddParentingToLitterMapper
        {
            public static ParentingViewModel.AddParentingToLitter Map(ParentingCommandsDto.V1.CreateParenting dto)
            {
                if (dto == null)
                { return null; }
                return new ParentingViewModel.AddParentingToLitter
                {
                    ParentingId = dto.ParentingId,
                    AnimalId = dto.AnimalId,
                    LitterId = dto.LitterId
                };
            }

            public static IEnumerable<ParentingViewModel.AddParentingToLitter> Map(IEnumerable<ParentingCommandsDto.V1.CreateParenting> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<ParentingCommandsDto.V1.CreateParenting> Map(IEnumerable<ParentingViewModel.AddParentingToLitter> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static ParentingCommandsDto.V1.CreateParenting Map(ParentingViewModel.AddParentingToLitter model)
            {
                if (model == null)
                { return null; }
                return new ParentingCommandsDto.V1.CreateParenting
                {
                    ParentingId = model.ParentingId,
                    AnimalId = model.AnimalId,
                    LitterId = model.LitterId
                };
            }
        }

        public class CreateParentingMapper
        {
            public static ParentingViewModel.CreateParenting Map(ParentingCommandsDto.V1.CreateParenting dto)
            {
                if (dto == null)
                { return null; }
                return new ParentingViewModel.CreateParenting
                {
                    ParentingId = dto.ParentingId,
                    AnimalId = dto.AnimalId,
                    LitterId = dto.LitterId
                };
            }

            public static IEnumerable<ParentingViewModel.CreateParenting> Map(IEnumerable<ParentingCommandsDto.V1.CreateParenting> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<ParentingCommandsDto.V1.CreateParenting> Map(IEnumerable<ParentingViewModel.CreateParenting> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static ParentingCommandsDto.V1.CreateParenting Map(ParentingViewModel.CreateParenting model)
            {
                if (model == null)
                { return null; }
                return new ParentingCommandsDto.V1.CreateParenting
                {
                    ParentingId = model.ParentingId,
                    AnimalId = model.AnimalId,
                    LitterId = model.LitterId
                };
            }
        }

        public class ParentingDetailsMapper
        {
            public static ParentingViewModel.ParentingDetails Map(ParentingQuerysDto.ParentingDetails dto)
            {
                if (dto == null)
                { return null; }
                return new ParentingViewModel.ParentingDetails
                {
                    ParentingId = dto.ParentingId,
                    AnimalId = dto.AnimalId,
                    LitterId = dto.LitterId,
                    IsDeleted = dto.IsDeleted,
                    Litter = LitterDetailsMapper.Map(dto.Litter),
                    Animal = AnimalDetailsLitterMapper.Map(dto.Animal)
                };
            }

            public static IEnumerable<ParentingViewModel.ParentingDetails> Map(IEnumerable<ParentingQuerysDto.ParentingDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<ParentingQuerysDto.ParentingDetails> Map(IEnumerable<ParentingViewModel.ParentingDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static ParentingQuerysDto.ParentingDetails Map(ParentingViewModel.ParentingDetails model)
            {
                if (model == null)
                { return null; }
                return new ParentingQuerysDto.ParentingDetails
                {
                    ParentingId = model.ParentingId,
                    AnimalId = model.AnimalId,
                    LitterId = model.LitterId,
                    IsDeleted = model.IsDeleted,
                    Litter = LitterDetailsMapper.Map(model.Litter),
                    Animal = AnimalDetailsLitterMapper.Map(model.Animal)
                };
            }
        }

        public class ParentingLitterDetailsMapper
        {
            public static ParentingViewModel.ParentingDetails Map(ParentingQuerysDto.ParentingDetails dto)
            {
                if (dto == null)
                { return null; }
                return new ParentingViewModel.ParentingDetails
                {
                    ParentingId = dto.ParentingId,
                    AnimalId = dto.AnimalId,
                    LitterId = dto.LitterId,
                    IsDeleted = dto.IsDeleted,
                    Litter = LitterDetailsMapper.Map(dto.Litter)
                    
                };
            }

            public static IEnumerable<ParentingViewModel.ParentingDetails> Map(IEnumerable<ParentingQuerysDto.ParentingDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<ParentingQuerysDto.ParentingDetails> Map(IEnumerable<ParentingViewModel.ParentingDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static ParentingQuerysDto.ParentingDetails Map(ParentingViewModel.ParentingDetails model)
            {
                if (model == null)
                { return null; }
                return new ParentingQuerysDto.ParentingDetails
                {
                    ParentingId = model.ParentingId,
                    AnimalId = model.AnimalId,
                    LitterId = model.LitterId,
                    IsDeleted = model.IsDeleted,
                    Litter = LitterDetailsMapper.Map(model.Litter)
                   
                };
            }
        }

        public class ParentingAnimalDetailsMapper
        {
            public static ParentingViewModel.ParentingDetails Map(ParentingQuerysDto.ParentingDetails dto)
            {
                if (dto == null)
                { return null; }
                return new ParentingViewModel.ParentingDetails
                {
                    ParentingId = dto.ParentingId,
                    AnimalId = dto.AnimalId,
                    LitterId = dto.LitterId,
                    IsDeleted = dto.IsDeleted,
                    Animal = AnimalDetailsMapper.Map(dto.Animal)

                };
            }

            public static IEnumerable<ParentingViewModel.ParentingDetails> Map(IEnumerable<ParentingQuerysDto.ParentingDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<ParentingQuerysDto.ParentingDetails> Map(IEnumerable<ParentingViewModel.ParentingDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static ParentingQuerysDto.ParentingDetails Map(ParentingViewModel.ParentingDetails model)
            {
                if (model == null)
                { return null; }
                return new ParentingQuerysDto.ParentingDetails
                {
                    ParentingId = model.ParentingId,
                    AnimalId = model.AnimalId,
                    LitterId = model.LitterId,
                    IsDeleted = model.IsDeleted,
                    Animal = AnimalDetailsMapper.Map(model.Animal)

                };
            }
        }
    }
}
