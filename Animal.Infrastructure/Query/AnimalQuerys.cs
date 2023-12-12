using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.ParentingQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.AnimalQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.ExhibitionTitleQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.HealthRecordQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.LitterQuerysDto;

namespace Animal.Infrastructure.Query
{
    public class AnimalQuerys
    {
        private readonly AnimalDbContext _context;

        public AnimalQuerys(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnimalDetails>> GetAllAnimals()
        {
           
            return await _context.Animals.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new AnimalDetails
                {
                    AnimalId = x.Id.Value,
                    OwnerId = x.OwnerId,
                    SubRaceId = x.SubRaceId,
                    LitterId = x.LitterId,
                    RegNo = x.RegNo.Value,
                    PedigreeName = x.PedigreeName.Value,
                    ShortName = x.ShortName.Value,
                    BirthDate = x.BirthDate.Value,
                    DeathDate = x.DeathDate.Value,
                    Gender = x.Gender.Value,
                    Color = x.Color.Value,
                    WeightInKg = x.WeightInKg.Value,
                    IsBreedable = x.IsBreedable.Value,
                    ProfileText = x.ProfileText.Value,
                    IsDeleted = x.IsDeleted.Value
                })
                 .ToListAsync();

            //return await _context.Animals.AsNoTracking()
            //    .Where(x => x.IsDeleted.Value == false)
            //    .Select(x => new AnimalDetails
            //    {
            //        AnimalId = x.Id.Value,
            //        OwnerId = x.OwnerId,
            //        SubRaceId = x.SubRaceId,
            //        LitterId = x.LitterId,
            //        RegNo = x.RegNo.Value,
            //        PedigreeName = x.PedigreeName.Value,
            //        ShortName = x.ShortName.Value,
            //        BirthDate = x.BirthDate.Value,
            //        DeathDate = x.DeathDate.Value,
            //        Gender = x.Gender.Value,
            //        Color = x.Color.Value,
            //        WeightInKg = x.WeightInKg.Value,
            //        IsBreedable = x.IsBreedable.Value,
            //        ProfileText = x.ProfileText.Value,
            //        IsDeleted = x.IsDeleted.Value,

            //        ExhibitionTitles = x.ExhibitionTitles.Select(x => new ExhibitionTitleDetails
            //        {
            //            ExhibitionTitleId = x.Id.Value,
            //            AnimalId = x.AnimalId,
            //            Name = x.Name.Value,
            //            Date = x.Date.Value,
            //            IsDeleted = x.IsDeleted.Value,
            //        }).Where(x => x.IsDeleted == false)
            //        .ToList(),

            //        Parentings = x.Parentings.Select(x => new ParentingDetails
            //        {
            //            ParentingId = x.Id.Value,
            //            AnimalId = x.AnimalId,
            //            LitterId = x.LitterId,
            //            IsDeleted = x.IsDeleted.Value
            //        }).Where(x => x.IsDeleted == false)
            //        .ToList(),

            //        HealthRecord = new HealthRecordDetails 
            //        {
            //            HealthRecordId = x.HealthRecord.Id.Value,
            //            AnimalId = x.HealthRecord.AnimalId,
            //            IsDeleted = x.HealthRecord.IsDeleted.Value
            //        },

            //        //    Litter = new LitterDetails
            //        //    {
            //        //        LitterId = x.Litter.LitterId,
            //        //        BreedById = x.Litter.BreedById,
            //        //        LitterName = x.Litter.LitterName.Value,
            //        //        LitterBirthDate = x.Litter.LitterBirthDate.Value,
            //        //        MatingDate = x.Litter.MatingDate.Value,
            //        //        IsDeleted = x.Litter.IsDeleted.Value
            //        //    }
            //    })
            //     .ToListAsync();
        }
        
        public async Task<AnimalDetails> GetAnimalById(QueryModels.AnimalQueryModel.GetAnimalByAnimalId query)
        {
            return await _context.Animals.AsNoTracking()
                .Where(x => x.AnimalId == query.AnimalId && x.IsDeleted.Value == false)
                .Select(x => new AnimalDetails
                {
                    AnimalId = x.Id.Value,
                    OwnerId = x.OwnerId,
                    SubRaceId = x.SubRaceId,
                    LitterId = x.LitterId,
                    RegNo = x.RegNo.Value,
                    PedigreeName = x.PedigreeName.Value,
                    ShortName = x.ShortName.Value,
                    BirthDate = x.BirthDate.Value,
                    DeathDate = x.DeathDate.Value,
                    Gender = x.Gender.Value,
                    Color = x.Color.Value,
                    WeightInKg = x.WeightInKg.Value,
                    IsBreedable = x.IsBreedable.Value,
                    ProfileText = x.ProfileText.Value,
                    IsDeleted = x.IsDeleted.Value,

                    ExhibitionTitles = x.ExhibitionTitles.Select(x => new ExhibitionTitleDetails
                    {
                        ExhibitionTitleId = x.Id.Value,
                        AnimalId = x.AnimalId,
                        Name = x.Name.Value,
                        Date = x.Date.Value,
                        IsDeleted = x.IsDeleted.Value,
                    }).Where(x => x.IsDeleted == false)
                    .ToList(),

                    Parentings = x.Parentings.Select(x => new ParentingDetails
                    {
                        ParentingId = x.Id.Value,
                        AnimalId = x.AnimalId,
                        LitterId = x.LitterId,
                        IsDeleted = x.IsDeleted.Value
                    }).Where(x => x.IsDeleted == false)
                    .ToList(),

                    HealthRecord = new HealthRecordDetails
                    {
                        HealthRecordId = x.HealthRecord.Id.Value,
                        AnimalId = x.HealthRecord.AnimalId,
                        IsDeleted = x.HealthRecord.IsDeleted.Value
                    },

                    Litter = new LitterDetails
                    {
                        LitterId = x.Litter.LitterId,
                        BreedById = x.Litter.BreedById,
                        LitterName = x.Litter.LitterName.Value,
                        LitterBirthDate = x.Litter.LitterBirthDate.Value,
                        MatingDate = x.Litter.MatingDate.Value,
                        IsDeleted = x.Litter.IsDeleted.Value
                    }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<AnimalDetails> GetSingleAnimalByAnimalId(QueryModels.AnimalQueryModel.GetAnimalByAnimalId query)
        {
            return await _context.Animals.AsNoTracking()
                .Where(x => x.AnimalId == query.AnimalId && x.IsDeleted.Value == false)
                .Select(x => new AnimalDetails
                {
                    AnimalId = x.Id.Value,
                    OwnerId = x.OwnerId,
                    SubRaceId = x.SubRaceId,
                    LitterId = x.LitterId,
                    RegNo = x.RegNo.Value,
                    PedigreeName = x.PedigreeName.Value,
                    ShortName = x.ShortName.Value,
                    BirthDate = x.BirthDate.Value,
                    DeathDate = x.DeathDate.Value,
                    Gender = x.Gender.Value,
                    Color = x.Color.Value,
                    WeightInKg = x.WeightInKg.Value,
                    IsBreedable = x.IsBreedable.Value,
                    ProfileText = x.ProfileText.Value,
                    IsDeleted = x.IsDeleted.Value
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<AnimalDetails>> GetAnimalsBySearchString(string searchstring)
        {
            return await _context.Animals.AsNoTracking()
              .Where(x => x.IsDeleted.Value == false)
              .Where(x => x.ShortName.Value.ToLower().Contains(searchstring.ToLower()) || x.PedigreeName.Value.Contains(searchstring))
              .Select(x => new AnimalDetails
              {
                  AnimalId = x.Id.Value,
                  OwnerId = x.OwnerId,
                  SubRaceId = x.SubRaceId,
                  LitterId = x.LitterId,
                  RegNo = x.RegNo.Value,
                  PedigreeName = x.PedigreeName.Value,
                  ShortName = x.ShortName.Value,
                  BirthDate = x.BirthDate.Value,
                  DeathDate = x.DeathDate.Value,
                  Gender = x.Gender.Value,
                  Color = x.Color.Value,
                  WeightInKg = x.WeightInKg.Value,
                  IsBreedable = x.IsBreedable.Value,
                  ProfileText = x.ProfileText.Value,
                  IsDeleted = x.IsDeleted.Value
              })
               .ToListAsync();
            //return await _context.Animals.AsNoTracking()
            //    .Where(x => x.IsDeleted.Value == false)
            //    .Where(x=>x.ShortName.Value.ToLower().Contains(searchstring.ToLower())|| x.PedigreeName.Value.Contains(searchstring))
            //    .Select(x => new AnimalDetails
            //    {
            //        AnimalId = x.Id.Value,
            //        OwnerId = x.OwnerId,
            //        SubRaceId = x.SubRaceId,
            //        RegNo = x.RegNo.Value,
            //        PedigreeName = x.PedigreeName.Value,
            //        ShortName = x.ShortName.Value,
            //        BirthDate = x.BirthDate.Value,
            //        DeathDate = x.DeathDate.Value,
            //        Gender = x.Gender.Value,
            //        Color = x.Color.Value,
            //        WeightInKg = x.WeightInKg.Value,
            //        IsBreedable = x.IsBreedable.Value,
            //        ProfileText = x.ProfileText.Value,
            //        IsDeleted = x.IsDeleted.Value,

            //        ExhibitionTitles = x.ExhibitionTitles.Select(x => new ExhibitionTitleDetails
            //        {
            //            ExhibitionTitleId = x.Id.Value,
            //            AnimalId = x.AnimalId,
            //            Name = x.Name.Value,
            //            Date = x.Date.Value,
            //            IsDeleted = x.IsDeleted.Value,
            //        }).Where(x => x.IsDeleted == false)
            //        .ToList(),

            //        //Parrents = x.Parrents.Select(x => new ParrentDetails
            //        //{
            //        //    ParrentId = x.Id.Value,
            //        //    AnimalId = x.AnimalId,
            //        //    LitterId = x.LitterId,
            //        //    IsDeleted = x.IsDeleted.Value
            //        //}).Where(x => x.IsDeleted == false)
            //        //.ToList(),

            //        HealthRecord = new HealthRecordDetails
            //        {
            //            HealthRecordId = x.HealthRecord.Id.Value,
            //            AnimalId = x.HealthRecord.AnimalId,
            //            IsDeleted = x.HealthRecord.IsDeleted.Value
            //        }
            //    })
            //     .ToListAsync();
        }

        public async Task<AnimalDetails> GetAnimalByOwnerId(QueryModels.AnimalQueryModel.GetAllAnimalByOwnerId query)
        {
            return await _context.Animals.AsNoTracking()
                .Where(x => x.OwnerId == query.OwnerId)
                .Select(x => new AnimalDetails
                {
                    AnimalId = x.Id.Value,
                    OwnerId = x.OwnerId,
                    PedigreeName = x.PedigreeName.Value,
                    ShortName = x.ShortName.Value
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<AnimalDetails>> GetAllAnimalByOwnerId(QueryModels.AnimalQueryModel.GetAllAnimalByOwnerId query)
        {
            return await _context.Animals.AsNoTracking()
                .Where(x => x.OwnerId == query.OwnerId)
                .Select(x => new AnimalDetails
                {
                    AnimalId = x.Id.Value,
                    OwnerId = x.OwnerId,
                    PedigreeName = x.PedigreeName.Value,
                    ShortName = x.ShortName.Value
                })
                .ToListAsync();
        }

        public async Task<List<AnimalDetails>> GetAllAnimalByLitterId(QueryModels.AnimalQueryModel.GetAllAnimalByLitterId query)
        {
            return await _context.Animals.AsNoTracking()
                .Where(x => x.LitterId == query.LitterId)
                .Select(x => new AnimalDetails
                {
                    AnimalId = x.Id.Value,
                    OwnerId = x.OwnerId,
                    PedigreeName = x.PedigreeName.Value,
                    ShortName = x.ShortName.Value
                })
                .ToListAsync();
        }

        public async Task<AnimalDetails> GetPedigreeTreeByAnimalId(QueryModels.AnimalQueryModel.GetAnimalByAnimalId query)
        {
            return await _context.Animals.AsNoTracking()
                .Where(x => x.AnimalId == query.AnimalId)
                .Select(x => new AnimalDetails
                {
                    AnimalId = x.Id.Value,
                    OwnerId = x.OwnerId,
                    PedigreeName = x.PedigreeName.Value,
                    ShortName = x.ShortName.Value,

                    Litter = new LitterDetails
                    {
                        LitterId = x.Litter.LitterId,
                        BreedById = x.Litter.BreedById,
                        LitterName = x.Litter.LitterName.Value,
                        LitterBirthDate = x.Litter.LitterBirthDate.Value,
                        MatingDate = x.Litter.MatingDate.Value,
                        IsDeleted = x.Litter.IsDeleted.Value,

                        Parentings = x.Litter.Parentings.Select(z => new ParentingDetails
                        {
                            ParentingId = z.Id.Value,
                            AnimalId = z.AnimalId,
                            LitterId = z.LitterId,

                            Animal = new AnimalDetails 
                            {
                                AnimalId = z.Animal.AnimalId,
                                PedigreeName = z.Animal.PedigreeName.Value,
                                Gender = z.Animal.Gender.Value
                            },
                        }).ToList(),
                    }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<AnimalDetails> GetFullPedegreeTreeByAnimalId(QueryModels.AnimalQueryModel.GetAnimalByAnimalId query)
        {
            //child
            return await _context.Animals.AsNoTracking()
                .Where(x => x.AnimalId == query.AnimalId)
                .Select(child => new AnimalDetails
                {
                    AnimalId = child.Id.Value,
                    OwnerId = child.OwnerId,
                    SubRaceId = child.SubRaceId,
                    LitterId = child.LitterId,
                    RegNo = child.RegNo.Value,
                    PedigreeName = child.PedigreeName.Value,
                    ShortName = child.ShortName.Value,
                    BirthDate = child.BirthDate.Value,
                    DeathDate = child.DeathDate.Value,
                    Gender = child.Gender.Value,
                    Color = child.Color.Value,
                    WeightInKg = child.WeightInKg.Value,
                    IsBreedable = child.IsBreedable.Value,
                    ProfileText = child.ProfileText.Value,

                    Litter = new LitterDetails
                    {
                        LitterId = child.Litter.LitterId,
                        BreedById = child.Litter.BreedById,
                        LitterName = child.Litter.LitterName.Value,
                        LitterBirthDate = child.Litter.LitterBirthDate.Value,
                        MatingDate = child.Litter.MatingDate.Value,
                        IsDeleted = child.Litter.IsDeleted.Value,

                        //Parents
                        Parentings = child.Litter.Parentings.Select(parents => new ParentingDetails
                        {
                            ParentingId = parents.Id.Value,
                            AnimalId = parents.AnimalId,
                            LitterId = parents.LitterId,

                            Animal = new AnimalDetails
                            {
                                AnimalId = parents.Animal.AnimalId,
                                PedigreeName = parents.Animal.PedigreeName.Value,
                                Gender = parents.Animal.Gender.Value,

                                Litter = new LitterDetails
                                {
                                    LitterId = parents.Animal.Litter.LitterId,
                                    BreedById = parents.Animal.Litter.BreedById,
                                    LitterName = parents.Animal.Litter.LitterName.Value,
                                    LitterBirthDate = parents.Animal.Litter.LitterBirthDate.Value,
                                    MatingDate = parents.Animal.Litter.MatingDate.Value,
                                    IsDeleted = parents.Animal.Litter.IsDeleted.Value,

                                    //grandParents
                                    Parentings = parents.Animal.Litter.Parentings.Select(grandParents => new ParentingDetails
                                    {
                                        ParentingId = grandParents.Id.Value,
                                        AnimalId = grandParents.AnimalId,
                                        LitterId = grandParents.LitterId,

                                        Animal = new AnimalDetails
                                        {
                                            AnimalId = grandParents.Animal.Id.Value,
                                            OwnerId = grandParents.Animal.OwnerId,
                                            PedigreeName = grandParents.Animal.PedigreeName.Value,
                                            ShortName = grandParents.Animal.ShortName.Value
                                        }
                                    }).ToList(),
                                }
                            },
                        }).ToList(),
                    }
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<AnimalDetails>> GetAllParentingAnimals()
        {
            return await _context.Animals.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new AnimalDetails
                {
                    AnimalId = x.Id.Value,
                    OwnerId = x.OwnerId,
                    SubRaceId = x.SubRaceId,
                    LitterId = x.LitterId,
                    RegNo = x.RegNo.Value,
                    PedigreeName = x.PedigreeName.Value,
                    ShortName = x.ShortName.Value,
                    BirthDate = x.BirthDate.Value,
                    DeathDate = x.DeathDate.Value,
                    Gender = x.Gender.Value,
                    Color = x.Color.Value,
                    WeightInKg = x.WeightInKg.Value,
                    IsBreedable = x.IsBreedable.Value,
                    ProfileText = x.ProfileText.Value,
                    IsDeleted = x.IsDeleted.Value
                })
                 .ToListAsync();
        }
    }
}
