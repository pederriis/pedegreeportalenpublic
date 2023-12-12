using PedigreePortalen.Shared.AnimalMicroserviceDto.Commands;
using PedigreePortalen.Shared.AnimalMicroserviceDto.Querys;
using PedigreePortalen.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.LitterMapper;
using static PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper.ParentingMapper;

namespace PedigreePortalen.UI.Mapper.AnimalMicroServiceMapper
{
    public static class AnimalMapper
    {
        public class AnimalCreateMapper
        {
            public static AnimalViewModel.CreateAnimal Map(AnimalCommandsDto.V1.CreateAnimal dto)
            {
                if (dto == null)
                { return null; }
                return new AnimalViewModel.CreateAnimal
                {
                    AnimalId = dto.AnimalId,
                    OwnerId = dto.OwnerId,
                    SubRaceId = dto.SubRaceId,
                    RegNo = dto.RegNo,
                    PedigreeName = dto.PedigreeName,
                    ShortName = dto.ShortName,
                    BirthDate = dto.BirthDate,
                    DeathDate = dto.DeathDate,
                    Gender = dto.Gender,
                    Color = dto.Color,
                    WeightInKg = dto.WeightInKg,
                    IsBreedable = dto.IsBreedable,
                    ProfileText = dto.ProfileText,
                };
            }

            public static IEnumerable<AnimalViewModel.CreateAnimal> Map(IEnumerable<AnimalCommandsDto.V1.CreateAnimal> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<AnimalCommandsDto.V1.CreateAnimal> Map(IEnumerable<AnimalViewModel.CreateAnimal> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static AnimalCommandsDto.V1.CreateAnimal Map(AnimalViewModel.CreateAnimal model)
            {
                if (model == null)
                { return null; }
                return new AnimalCommandsDto.V1.CreateAnimal
                {
                    AnimalId = model.AnimalId,
                    OwnerId = model.OwnerId,
                    SubRaceId = model.SubRaceId,
                    RegNo = model.RegNo,
                    PedigreeName = model.PedigreeName,
                    ShortName = model.ShortName,
                    BirthDate = model.BirthDate,
                    DeathDate = model.DeathDate,
                    Gender = model.Gender,
                    Color = model.Color,
                    WeightInKg = model.WeightInKg,
                    IsBreedable = model.IsBreedable,
                    ProfileText = model.ProfileText,
                };
            }
        }

        public class AnimalDetailsMapper
        {
            public static AnimalViewModel.DetailsAnimal Map(AnimalQuerysDto.AnimalDetails dto)
            {
                if (dto == null)
                { return null; }
                return new AnimalViewModel.DetailsAnimal
                {
                    AnimalId = dto.AnimalId,
                    OwnerId = dto.OwnerId,
                    SubRaceId = dto.SubRaceId,
                    RegNo = dto.RegNo,
                    PedigreeName = dto.PedigreeName,
                    ShortName = dto.ShortName,
                    BirthDate = dto.BirthDate,
                    DeathDate = dto.DeathDate,
                    Gender = dto.Gender,
                    Color = dto.Color,
                    WeightInKg = dto.WeightInKg,
                    IsBreedable = dto.IsBreedable,
                    ProfileText = dto.ProfileText,
                    IsDeleted = dto.IsDeleted
                };
            }

            public static IEnumerable<AnimalViewModel.DetailsAnimal> Map(IEnumerable<AnimalQuerysDto.AnimalDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<AnimalQuerysDto.AnimalDetails> Map(IEnumerable<AnimalViewModel.DetailsAnimal> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static AnimalQuerysDto.AnimalDetails Map(AnimalViewModel.DetailsAnimal model)
            {
                if (model == null)
                { return null; }
                return new AnimalQuerysDto.AnimalDetails
                {
                    AnimalId = model.AnimalId,
                    OwnerId = model.OwnerId,
                    SubRaceId = model.SubRaceId,
                    RegNo = model.RegNo,
                    PedigreeName = model.PedigreeName,
                    ShortName = model.ShortName,
                    BirthDate = model.BirthDate,
                    DeathDate = model.DeathDate,
                    Gender = model.Gender,
                    Color = model.Color,
                    WeightInKg = model.WeightInKg,
                    IsBreedable = model.IsBreedable,
                    ProfileText = model.ProfileText,
                    IsDeleted = model.IsDeleted
                };
            }
        }

        public class AnimalDetailsLitterMapper
        {
            public static AnimalViewModel.DetailsAnimal Map(AnimalQuerysDto.AnimalDetails dto)
            {
                if (dto == null)
                { return null; }
                return new AnimalViewModel.DetailsAnimal
                {
                    AnimalId = dto.AnimalId,
                    OwnerId = dto.OwnerId,
                    SubRaceId = dto.SubRaceId,
                    RegNo = dto.RegNo,
                    PedigreeName = dto.PedigreeName,
                    ShortName = dto.ShortName,
                    BirthDate = dto.BirthDate,
                    DeathDate = dto.DeathDate,
                    Gender = dto.Gender,
                    Color = dto.Color,
                    WeightInKg = dto.WeightInKg,
                    IsBreedable = dto.IsBreedable,
                    ProfileText = dto.ProfileText,
                    IsDeleted = dto.IsDeleted,
                    Litter = LitterParentingDetailsMapper.Map(dto.Litter)
                };
            }

            public static IEnumerable<AnimalViewModel.DetailsAnimal> Map(IEnumerable<AnimalQuerysDto.AnimalDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<AnimalQuerysDto.AnimalDetails> Map(IEnumerable<AnimalViewModel.DetailsAnimal> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static AnimalQuerysDto.AnimalDetails Map(AnimalViewModel.DetailsAnimal model)
            {
                if (model == null)
                { return null; }
                return new AnimalQuerysDto.AnimalDetails
                {
                    AnimalId = model.AnimalId,
                    OwnerId = model.OwnerId,
                    SubRaceId = model.SubRaceId,
                    RegNo = model.RegNo,
                    PedigreeName = model.PedigreeName,
                    ShortName = model.ShortName,
                    BirthDate = model.BirthDate,
                    DeathDate = model.DeathDate,
                    Gender = model.Gender,
                    Color = model.Color,
                    WeightInKg = model.WeightInKg,
                    IsBreedable = model.IsBreedable,
                    ProfileText = model.ProfileText,
                    IsDeleted = model.IsDeleted,
                    Litter = LitterParentingDetailsMapper.Map(model.Litter)
                };
            }
        }

        public class AnimalDetailsParentingsMapper
        {
            public static AnimalViewModel.DetailsAnimal Map(AnimalQuerysDto.AnimalDetails dto)
            {
                if (dto == null)
                { return null; }
                return new AnimalViewModel.DetailsAnimal
                {
                    AnimalId = dto.AnimalId,
                    OwnerId = dto.OwnerId,
                    SubRaceId = dto.SubRaceId,
                    RegNo = dto.RegNo,
                    PedigreeName = dto.PedigreeName,
                    ShortName = dto.ShortName,
                    BirthDate = dto.BirthDate,
                    DeathDate = dto.DeathDate,
                    Gender = dto.Gender,
                    Color = dto.Color,
                    WeightInKg = dto.WeightInKg,
                    IsBreedable = dto.IsBreedable,
                    ProfileText = dto.ProfileText,
                    IsDeleted = dto.IsDeleted,
                    Parentings = ParentingDetailsMapper.Map(dto.Parentings).ToList()
                };
            }

            public static IEnumerable<AnimalViewModel.DetailsAnimal> Map(IEnumerable<AnimalQuerysDto.AnimalDetails> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static IEnumerable<AnimalQuerysDto.AnimalDetails> Map(IEnumerable<AnimalViewModel.DetailsAnimal> model)
            {
                return model.Select(x => Map(x)).AsEnumerable();
            }

            public static AnimalQuerysDto.AnimalDetails Map(AnimalViewModel.DetailsAnimal model)
            {
                if (model == null)
                { return null; }
                return new AnimalQuerysDto.AnimalDetails
                {
                    AnimalId = model.AnimalId,
                    OwnerId = model.OwnerId,
                    SubRaceId = model.SubRaceId,
                    RegNo = model.RegNo,
                    PedigreeName = model.PedigreeName,
                    ShortName = model.ShortName,
                    BirthDate = model.BirthDate,
                    DeathDate = model.DeathDate,
                    Gender = model.Gender,
                    Color = model.Color,
                    WeightInKg = model.WeightInKg,
                    IsBreedable = model.IsBreedable,
                    ProfileText = model.ProfileText,
                    IsDeleted = model.IsDeleted,
                    Parentings = ParentingDetailsMapper.Map(model.Parentings).ToList()
                };
            }
        }
    }
}
