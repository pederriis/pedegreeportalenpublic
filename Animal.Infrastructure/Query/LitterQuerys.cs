using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.ParentingQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.LitterQuerysDto;
using static PedigreePortalen.Shared.AnimalMicroserviceDto.Querys.AnimalQuerysDto;

namespace Animal.Infrastructure.Query
{
    public class LitterQuerys
    {
        private readonly AnimalDbContext _context;

        public LitterQuerys(AnimalDbContext context)
        {
            _context = context;
        }

        public async Task<List<LitterDetails>> GetAllLitters()
        {
            return await _context.Litters.AsNoTracking()
                .Where(x => x.IsDeleted.Value == false)
                .Select(x => new LitterDetails
                {
                    LitterId = x.Id.Value,
                    BreedById = x.BreedById,
                    LitterName = x.LitterName.Value,
                    LitterBirthDate = x.LitterBirthDate.Value,
                    MatingDate = x.MatingDate.Value,
                    IsDeleted = x.IsDeleted.Value,

                    Parentings = x.Parentings.Select(x => new ParentingDetails
                    {
                        ParentingId = x.Id.Value,
                        AnimalId = x.AnimalId,
                        LitterId = x.LitterId,
                        IsDeleted = x.IsDeleted.Value
                    }).Where(x => x.IsDeleted == false).ToList(),

                    Animals = x.Animals.Select(x => new AnimalDetails
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

                    }).Where(x => x.IsDeleted == false).ToList()
                })
                 .ToListAsync();
        }

        public async Task<LitterDetails> GetLitterById(QueryModels.LitterQueryModel.GetLitterByLitterId query)
        {
            return await _context.Litters.AsNoTracking()
                .Where(x => x.LitterId == query.LitterId && x.IsDeleted.Value == false)
                .Select(x => new LitterDetails
                {
                    LitterId = x.Id.Value,
                    BreedById = x.BreedById,
                    LitterName = x.LitterName.Value,
                    LitterBirthDate = x.LitterBirthDate.Value,
                    MatingDate = x.MatingDate.Value,
                    IsDeleted = x.IsDeleted.Value,

                    Parentings = x.Parentings.Select(x => new ParentingDetails
                    {
                        ParentingId = x.Id.Value,
                        AnimalId = x.AnimalId,
                        LitterId = x.LitterId,
                        IsDeleted = x.IsDeleted.Value,

                        Animal = new AnimalDetails
                        {
                            AnimalId = x.Animal.Id.Value,
                            PedigreeName = x.Animal.PedigreeName.Value,
                            ShortName = x.Animal.ShortName.Value,
                            Gender = x.Animal.Gender.Value,
                        }
                    }).ToList(),

                    Animals = x.Animals.Select(x => new AnimalDetails
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

                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<LitterDetails>> GetAllLitterByOwnerId(QueryModels.LitterQueryModel.GetLitterByOwnerId query)
        {
            return await _context.Litters.AsNoTracking()
                .Where(x => x.BreedById == query.BreedById && x.IsDeleted.Value == false)
                .Select(x => new LitterDetails
                {
                    LitterId = x.Id.Value,
                    BreedById = x.BreedById,
                    LitterName = x.LitterName.Value,
                    LitterBirthDate = x.LitterBirthDate.Value,
                    MatingDate = x.MatingDate.Value,
                    IsDeleted = x.IsDeleted.Value
                })
                .ToListAsync();
        }

        public async Task<LitterDetails> GetParentingsByLitterId(QueryModels.LitterQueryModel.GetParentingsByLitterId query)
        {
            return await _context.Litters.AsNoTracking()
                .Where(x => x.LitterId == query.LitterId)
                .Select(x => new LitterDetails
                {
                    LitterId = x.Id.Value,
                    BreedById = x.BreedById,
                    LitterName = x.LitterName.Value,
                    LitterBirthDate = x.LitterBirthDate.Value,
                    MatingDate = x.MatingDate.Value,
                    IsDeleted = x.IsDeleted.Value,

                    Parentings = x.Parentings.Select(x => new ParentingDetails
                    {
                        ParentingId = x.Id.Value,
                        AnimalId = x.AnimalId,
                        LitterId = x.LitterId,
                        IsDeleted = x.IsDeleted.Value,

                        Animal = new AnimalDetails 
                        {
                            AnimalId = x.Animal.Id.Value,
                            PedigreeName = x.Animal.PedigreeName.Value,
                            ShortName = x.Animal.ShortName.Value,
                            Gender = x.Animal.Gender.Value,   
                        }
                    }).ToList(),
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<LitterDetails>> GetLitterAnimalsByLitterId(QueryModels.LitterQueryModel.GetLitterAnimalsByLitterId query)
        {
            return await _context.Litters.AsNoTracking()
                .Where(x => x.LitterId == query.LitterId)
                .Select(x => new LitterDetails
                {
                    LitterId = x.Id.Value,
                    BreedById = x.BreedById,
                    LitterName = x.LitterName.Value,
                    LitterBirthDate = x.LitterBirthDate.Value,
                    MatingDate = x.MatingDate.Value,
                    IsDeleted = x.IsDeleted.Value,

                    Animals = x.Animals.Select(x => new AnimalDetails
                    {
                        AnimalId = x.Id.Value,
                        PedigreeName = x.PedigreeName.Value,
                        ShortName = x.ShortName.Value,
                        Gender = x.Gender.Value,

                    }).ToList()
                })
                .ToListAsync();
        }
    }
}
